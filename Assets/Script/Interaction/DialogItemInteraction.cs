using Assets.Script.Dialog;
using Assets.Script.Interaction;
using Assets.Script.Locale;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogItemInteraction : MonoBehaviour, IUseItem
{
    public bool shouldWalk = true;
    public bool shouldSit = false;

    public string targetItem;
    public TextGroup textGroupSuccess = TextGroup.DialogWakeUpCall;
    public TextGroup textGroupFail = TextGroup.DialogWakeUpCall;
    public bool isDialog = true;

    [SerializeField] private GameObject dialogBox;
    [SerializeField] private GameObject thinkingBox;
    [SerializeField] private Vector3 CustomWalkOffset = Vector3.zero;

    private Dialog dialog;

    void Awake()
    {
        dialog = gameObject.AddComponent<Dialog>();
        dialog.DialogBox = dialogBox;
        dialog.DialogText = dialogBox.GetComponentInChildren<TMP_Text>();
        dialog.DialogSpeaker = dialogBox.GetComponentInChildren<TMP_Text>();
        dialog.Portrait = dialogBox.transform.Find("Portrait").GetComponent<Image>();

        dialog.ThinkingBox = thinkingBox;
        dialog.ThinkingText = thinkingBox.GetComponentInChildren<TMP_Text>();
        dialog.ThinkingSpeaker = thinkingBox.GetComponentInChildren<TMP_Text>();

        Transform dialogSpeakerTransform = dialogBox.transform.Find("DialogSpeaker");
        dialog.DialogSpeaker = dialogSpeakerTransform.GetComponent<TMP_Text>();
    }

    public void UseItem(GameObject who)
    {
        if (targetItem == who.name)
            dialog.TextGroup = textGroupSuccess;
        else
            dialog.TextGroup = textGroupFail;

        StartCoroutine(Execute(who));
    }

    IEnumerator Execute(GameObject who)
    {
        GameManager.Instance.UpdateGameState(GameManager.GameState.Interacting);

        if (shouldWalk)
        {
            var g = new GoTo();
            yield return StartCoroutine(g.GoToRoutine(new Vector3(transform.position.x + CustomWalkOffset.x, transform.position.y + CustomWalkOffset.y, transform.position.z + CustomWalkOffset.z), this.transform));

            // Action cancelled
            if (GameManager.Instance.State != GameManager.GameState.Interacting)
                yield break;

            if (shouldSit)
            {
                PlayerController.anim.SetBool("Sit", true);
            }
        }

        DialogAction result = DialogAction.None;
        yield return StartCoroutine(dialog.Execute(who, (value) => result = value, isDialog));

        GameManager.Instance.UpdateGameState(GameManager.GameState.Playing);
        PlayerController.anim.SetBool("Sit", false);
        if (result == DialogAction.RemoveDialog)
            Destroy(this);
    }
}