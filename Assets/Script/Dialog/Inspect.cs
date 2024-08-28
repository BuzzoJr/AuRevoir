using Assets.Script.Dialog;
using Assets.Script.Interaction;
using Assets.Script.Locale;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Inspect : MonoBehaviour, ILook, ILangConsumer
{
    public bool shouldWalk = true;
    public TextGroup textGroup = TextGroup.DialogWakeUpCall;
    [SerializeField] private GameObject dialogBox;
    private TMP_Text dialogText;
    public GameObject ThinkingBox;
    public Transform lookAtObj;
    private TMP_Text DialogSpeaker { get; set; }
    [SerializeField] private bool HasText = true;
    [SerializeField] private Vector3 CustomWalkOffset = Vector3.zero;

    private TMP_Text ThinkingText;

    private int currentIndex = -1;

    private Image Portrait;
    private string currentSceneName;

    public void UpdateLangTexts()
    {
        if (currentIndex >= 0)
        {
            TextData data = Locale.Texts[textGroup][currentIndex];
            if (TextType.TristanThinking == data.Type)
            {
                dialogBox.SetActive(false);
                ThinkingBox.SetActive(true);
                ThinkingText.text = "* " + data.Text + " *";
            }
            else
            {
                dialogBox.SetActive(true);
                ThinkingBox.SetActive(false);
                //dialogText.color = TextColorManager.textTypeColors[data.Type];
                dialogText.text = data.Text;
                DialogSpeaker.color = TextColorManager.textTypeColors[data.Type];
                DialogSpeaker.text = Locale.Titles[data.Type];
                Portrait.sprite = PortraitManager.GetPortrait(currentSceneName, data.Type.ToString());
            }
        }
    }

    void OnDestroy()
    {
        Locale.UnregisterConsumer(this);
    }

    void Awake()
    {
        dialogText = dialogBox.GetComponentInChildren<TMP_Text>();
        ThinkingText = ThinkingBox.GetComponentInChildren<TMP_Text>();
        Transform dialogSpeakerTransform = dialogBox.transform.Find("DialogSpeaker");
        DialogSpeaker = dialogSpeakerTransform.GetComponent<TMP_Text>();
        currentSceneName = SceneManager.GetActiveScene().name;
        Portrait = dialogBox.transform.Find("Portrait").GetComponent<Image>();
    }

    void Start()
    {
        // Allow enable/disable on unity ui
    }

    void ILook.Look(GameObject who)
    {
        StartCoroutine(CoroutineExample());
    }

    IEnumerator CoroutineExample()
    {
        GameManager.Instance.UpdateGameState(GameManager.GameState.Interacting);

        if (shouldWalk)
        {
            var g = new GoTo();
            yield return StartCoroutine(g.GoToRoutine(new Vector3(transform.position.x + CustomWalkOffset.x, transform.position.y + CustomWalkOffset.y, transform.position.z + CustomWalkOffset.z), lookAtObj));

            // Action cancelled
            if (GameManager.Instance.State != GameManager.GameState.Interacting)
                yield break;
        }
        yield return null;

        if (HasText)
        {
            dialogBox.SetActive(true);
            Locale.RegisterConsumer(this);
            for (int i = 0; i < Locale.Texts[textGroup].Count; i++)
            {
                currentIndex = i;
                UpdateLangTexts();

                TextData data = Locale.Texts[textGroup][currentIndex];
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
            }
            Locale.UnregisterConsumer(this);
            dialogBox.SetActive(false);
            ThinkingBox.SetActive(false);
        }

        GameManager.Instance.UpdateGameState(GameManager.GameState.Playing);
        runSpecial();
    }

    private void runSpecial()
    {
        var special = GetComponent<ILookSpecial>();
        if (special != null)
            special.LookSpecial(gameObject);
    }
}
