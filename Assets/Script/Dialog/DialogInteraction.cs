using Assets.Script.Dialog;
using Assets.Script.Interaction;
using Assets.Script.Locale;
using System.Collections;
using TMPro;
using UnityEngine;

public class DialogInteraction : MonoBehaviour, ITalk
{
    public bool shouldWalk = true;
    public TextGroup textGroup = TextGroup.DialogWakeUpCall;
    [SerializeField] private GameObject dialogBox;
    [SerializeField] private Vector3 CustomWalkOffset = Vector3.zero;

    private Dialog dialog;

    void Awake()
    {
        dialog = gameObject.AddComponent<Dialog>();
        dialog.DialogBox = dialogBox;
        dialog.TextGroup = textGroup;
        dialog.DialogText = dialogBox.GetComponentInChildren<TMP_Text>();
        dialog.DialogSpeaker = dialogBox.GetComponentInChildren<TMP_Text>();

        Transform dialogSpeakerTransform = dialogBox.transform.Find("DialogSpeaker");
        dialog.DialogSpeaker = dialogSpeakerTransform.GetComponent<TMP_Text>();
    }

    public void Talk(GameObject who)
    {
        dialog.TextGroup = textGroup;
        StartCoroutine(Execute(who));
    }

    IEnumerator Execute(GameObject who)
    {
        GameManager.Instance.UpdateGameState(GameManager.GameState.Interacting);

        if (shouldWalk)
        {
            GameObject.FindWithTag("Player").GetComponent<PlayerController>().GoTo(new Vector3(transform.position.x + CustomWalkOffset.x, transform.position.y + CustomWalkOffset.y, transform.position.z + CustomWalkOffset.z), null);

            yield return null;
            yield return new WaitUntil(() => !PlayerController.anim.GetBool("Walk"));
        }

        DialogAction result = DialogAction.None;
        yield return StartCoroutine(dialog.Execute(who, (value) => result = value));

        GameManager.Instance.UpdateGameState(GameManager.GameState.Playing);

        if (result == DialogAction.RemoveDialog)
            Destroy(this);
    }
}
