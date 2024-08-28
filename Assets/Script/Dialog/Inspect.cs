using Assets.Script.Dialog;
using Assets.Script.Interaction;
using Assets.Script.Locale;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inspect : MonoBehaviour, ILook
{
    public bool shouldWalk = true;
    public TextGroup textGroup = TextGroup.DialogWakeUpCall;
    public bool isDialog = true;
    [SerializeField] private GameObject dialogBox;
    [SerializeField] private GameObject thinkingBox;
    [SerializeField] private Vector3 CustomWalkOffset = Vector3.zero;
    public Transform lookAtObj;
    [SerializeField] private bool HasText = true;

    private Dialog dialog;

    void Awake()
    {
        dialog = gameObject.AddComponent<Dialog>();
        dialog.DialogBox = dialogBox;
        dialog.TextGroup = textGroup;
        dialog.DialogText = dialogBox.GetComponentInChildren<TMP_Text>();
        dialog.DialogSpeaker = dialogBox.GetComponentInChildren<TMP_Text>();
        dialog.Portrait = dialogBox.transform.Find("Portrait").GetComponent<Image>();

        dialog.ThinkingBox = thinkingBox;
        dialog.ThinkingText = thinkingBox.GetComponentInChildren<TMP_Text>();
        dialog.ThinkingSpeaker = thinkingBox.GetComponentInChildren<TMP_Text>();

        Transform dialogSpeakerTransform = dialogBox.transform.Find("DialogSpeaker");
        dialog.DialogSpeaker = dialogSpeakerTransform.GetComponent<TMP_Text>();
    }

    void Start()
    {
        // Allow enable/disable on unity ui
    }

    void ILook.Look(GameObject who)
    {
        StartCoroutine(CoroutineExample(who));
    }

    IEnumerator CoroutineExample(GameObject who)
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

        DialogAction result = DialogAction.None;
        if (HasText)
            yield return StartCoroutine(dialog.Execute(who, (value) => result = value, isDialog));

        GameManager.Instance.UpdateGameState(GameManager.GameState.Playing);
        runSpecial();

        if (result == DialogAction.RemoveDialog)
            Destroy(this);
    }

    private void runSpecial()
    {
        var special = GetComponent<ILookSpecial>();
        if (special != null)
            special.LookSpecial(gameObject);
    }
}
