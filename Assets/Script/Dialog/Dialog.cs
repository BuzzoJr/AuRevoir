using Assets.Script.Interaction;
using Assets.Script.Locale;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script.Dialog
{
    public class Dialog : MonoBehaviour, ILangConsumer
    {
        public GameObject DialogBox { get; set; }
        public TMP_Text DialogText { get; set; }
        public TextGroup TextGroup { get; set; }

        int? selectedKey = null;

        private int currentIndex = -1;

        public void UpdateLangTexts()
        {
            if (currentIndex >= 0)
            {
                TextData data = Locale.Locale.Texts[TextGroup][currentIndex];
                DialogText.color = TextColorManager.textTypeColors[data.Type];
                DialogText.text = TextColorManager.TextSpeaker(data.Type, data.Text);
            }
        }

        void OnDestroy()
        {
            Locale.Locale.UnregisterConsumer(this);
        }

        public IEnumerator Execute(GameObject who, System.Action<DialogAction> callback)
        {
            DialogAction result = DialogAction.None;

            DialogBox.SetActive(true);
            Locale.Locale.RegisterConsumer(this);

            yield return StartCoroutine(Execute(who, AllDialogs.Sequence[TextGroup], (value) => result = value));

            Locale.Locale.UnregisterConsumer(this);
            DialogBox.SetActive(false);

            callback(result);
        }

        public IEnumerator Execute(GameObject who, List<object> seq, System.Action<DialogAction> callback)
        {
            DialogAction result = DialogAction.None;

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
                    UpdateLangTexts();

                    TextData data = Locale.Locale.Texts[TextGroup][currentIndex];
                    bool clicked = false;
                    float delayTime = data.Delay > 0 ? data.Delay : AllDialogs.defaultDelay;
                    float elapsedTime = 0;

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
    }
}
