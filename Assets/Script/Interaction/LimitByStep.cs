using Assets.Script;
using Assets.Script.Dialog;
using Assets.Script.Interaction;
using Assets.Script.Locale;
using System.Collections;
using TMPro;
using UnityEngine;

public class LimitByStep : MonoBehaviour, ILimit, ILangConsumer
{
    public PlayerData playerData;
    public GameSteps step;
    public bool limitWhenHasStep = false;

    public bool shouldWalk = true;
    [SerializeField] private Vector3 CustomWalkOffset = Vector3.zero;

    public TextGroup textGroup;
    [SerializeField] private GameObject dialogBox;
    private TMP_Text dialogText;
    private TMP_Text DialogSpeaker { get; set; }
    private int currentIndex = -1;

    public void UpdateLangTexts()
    {
        if (currentIndex >= 0)
        {
            TextData data = Locale.Texts[textGroup][currentIndex];
            dialogText.text = TextColorManager.TextSpeaker(TextType.System, data.Text);
            DialogSpeaker.color = TextColorManager.textTypeColors[data.Type];
            DialogSpeaker.text = TextColorManager.TextSpeaker(data.Type, "");
        }
    }

    void OnDestroy()
    {
        Locale.UnregisterConsumer(this);
    }

    void Awake()
    {
        dialogText = dialogBox.GetComponentInChildren<TMP_Text>();
        Transform dialogSpeakerTransform = dialogBox.transform.Find("DialogSpeaker");
        DialogSpeaker = dialogSpeakerTransform.GetComponent<TMP_Text>();
    }

    public bool ShouldLimit(GameObject who)
    {
        // Limit interactions when the player:
        //  limitWhenHasStep == true -> have the step in playerData
        //  limitWhenHasStep == false -> doesn't have the step in playerData
        return (!playerData.HasStep(step) ^ limitWhenHasStep);
    }

    public void Limited(GameObject who)
    {
        StartCoroutine(Execute(who));
    }

    IEnumerator Execute(GameObject who)
    {
        GameManager.Instance.UpdateGameState(GameManager.GameState.Interacting);

        if (shouldWalk)
        {
            Vector3 dest = CompareTag("Door") ? transform.GetChild(0).position : transform.position;
            var g = new GoTo();
            yield return StartCoroutine(g.GoToRoutine(new Vector3(dest.x + CustomWalkOffset.x, dest.y + CustomWalkOffset.y, dest.z + CustomWalkOffset.z), this.transform));

            // Action cancelled
            if (GameManager.Instance.State != GameManager.GameState.Interacting)
                yield break;
        }

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

        GameManager.Instance.UpdateGameState(GameManager.GameState.Playing);
        RunSpecial();
    }

    private void RunSpecial()
    {
        var special = GetComponent<ILookSpecial>();
        if (special != null)
            special.LookSpecial(gameObject);
    }
}
