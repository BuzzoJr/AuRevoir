using Assets.Script.Interaction;
using Assets.Script.Locale;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor.Rendering.PostProcessing;
using UnityEditor.Rendering;

namespace Assets.Script.Dialog
{
    public class Dialog : MonoBehaviour, ILangConsumer
    {
        public GameObject DialogBox { get; set; }
        public TMP_Text DialogText { get; set; }
        public TMP_Text DialogSpeaker { get; set; }
        public Image Portrait { get; set; }
        public TextGroup TextGroup { get; set; }

        public GameObject ThinkingBox { get; set; }
        public TMP_Text ThinkingText { get; set; }
        public TMP_Text ThinkingSpeaker { get; set; }

        int? selectedKey = null;

        private int currentIndex = -1;

        private AudioSource typingSound;
        private bool isTyping = false;
        private bool skip = false;

        void Start()
        {
            typingSound = DialogBox.GetComponent<AudioSource>();
        }
        void OnDestroy()
        {
            Locale.Locale.UnregisterConsumer(this);
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                skip = true;
            }
        }

        public IEnumerator Execute(GameObject who, System.Action<DialogAction> callback)
        {
            DialogAction result = DialogAction.None;

            DialogBox.SetActive(true);
            Locale.Locale.RegisterConsumer(this);

            yield return StartCoroutine(Execute(who, AllDialogs.Sequence[TextGroup], (value) => result = value));

            Locale.Locale.UnregisterConsumer(this);

            if(ThinkingBox != null)
                ThinkingBox.SetActive(false);

            DialogBox.SetActive(false);

            callback(result);
        }

        public IEnumerator Execute(GameObject who, List<object> seq, System.Action<DialogAction> callback)
        {
            DialogAction result = DialogAction.None;
            string currentSceneName = SceneManager.GetActiveScene().name;
            int pos = 0;
            while (pos < seq.Count)
            {
                if (seq[pos] is DialogAction action)
                {
                    if (action == DialogAction.Special)
                    {
                        var special = GetComponentInChildren<ISpecial>();
                        if (special != null)
                            special.Special(who);

                        pos += 1;
                        continue;
                    }
                    else
                    {
                        result = action;
                        break;
                    }
                }

                if (seq[pos] is int i)
                {
                    currentIndex = i;

                    TextData data = Locale.Locale.Texts[TextGroup][currentIndex];

                    Portrait.sprite = PortraitManager.GetPortrait(currentSceneName, data.Type.ToString());
                    bool clicked = false;
                    float delayTime = data.Delay > 0 ? data.Delay : AllDialogs.defaultDelay;
                    float elapsedTime = 0;
                    if (TextType.TristanThinking == data.Type)
                    {
                        DialogBox.SetActive(false);

                        if (ThinkingBox != null)
                        {
                            ThinkingBox.SetActive(true);
                            ThinkingText.text = "* " + TextColorManager.TextSpeaker(TextType.System, data.Text) + " *";
                        }
                    }
                    else
                    {
                        if (ThinkingBox != null)
                            ThinkingBox.SetActive(false);

                        DialogBox.SetActive(true);
                        DialogSpeaker.color = TextColorManager.textTypeColors[data.Type];
                        DialogSpeaker.text = data.Type.ToString();
                        yield return StartCoroutine(DisplayLine(data.Text));
                    }
                    while (elapsedTime < delayTime && !clicked)
                    {
                        if (Input.GetMouseButtonDown(0))
                        {
                            clicked = true;
                        }
                        elapsedTime += Time.deltaTime;
                        yield return null;
                    }
                    pos += 1;
                    continue;
                }

                // Dict = Opções de interação de diálogo
                if (seq[pos] is Dictionary<int, List<object>> options)
                {
                    yield return new WaitUntil(() => !Input.GetMouseButton(0));

                    GameObject seta = GameObject.Find("Seta");
                    if (seta != null)
                        seta.SetActive(false);

                    List<Button> optionButtons = new List<Button>();
                    optionButtons.Add(GameObject.Find("Option1").GetComponent<Button>());
                    optionButtons.Add(GameObject.Find("Option2").GetComponent<Button>());
                    optionButtons.Add(GameObject.Find("Option3").GetComponent<Button>());
                    int interaction = 0;
                    currentIndex = -1;
                    DialogText.text = "";
                    foreach (int key in options.Keys)
                    {
                        optionButtons[interaction].interactable = true;
                        TextMeshProUGUI buttonText = optionButtons[interaction].GetComponentInChildren<TextMeshProUGUI>();
                        optionButtons[interaction].onClick.AddListener(() => SelectKey(key));

                        TextData data = Locale.Locale.Texts[TextGroup][key];
                        buttonText.color = TextColorManager.textTypeColors[data.Type];
                        buttonText.text = TextColorManager.TextSpeaker(data.Type, data.Text);
                        interaction += 1;
                    }
                    Portrait.sprite = PortraitManager.GetPortrait(currentSceneName, TextType.Tristan.ToString());
                    DialogSpeaker.text = TextType.Tristan.ToString();

                    yield return new WaitUntil(() => selectedKey.HasValue);
                    int selected = (int)selectedKey; // Colocar a opção selecionada
                    selectedKey = null;

                    foreach (Button btn in optionButtons)
                    {
                        btn.interactable = false;
                    }

                    if (seta != null)
                        seta.SetActive(true);

                    yield return StartCoroutine(Execute(who, options[selected], (value) => result = value));

                    // Ações de controle
                    if (result == DialogAction.End)
                        break;

                    if (result != DialogAction.Repeat)
                        pos += 1;

                    result = DialogAction.None;
                    continue;
                }
            }

            callback(result);
        }

        private void SelectKey(int key)
        {
            selectedKey = key;
        }

        private IEnumerator DisplayLine(string line)
        {
            typingSound.Play();
            isTyping = true;
            DialogText.text = "";
            skip = false;

            for (int i = 0; i < line.Length; i++)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    skip = true;
                }

                if (skip)
                {
                    DialogText.text = line;
                    yield return new WaitForSeconds(0.1f);
                    break;
                }
                else
                {
                    DialogText.text += line[i];
                    yield return new WaitForSeconds(0.05f); // adjust this value to control typing speed
                }
            }
            typingSound.Stop();
            isTyping = false;
        }

        public void UpdateLangTexts()
        {
            throw new System.NotImplementedException();
        }
    }
}
