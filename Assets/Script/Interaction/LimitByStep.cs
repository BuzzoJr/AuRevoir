using Assets.Script;
using Assets.Script.Dialog;
using Assets.Script.Interaction;
using Assets.Script.Locale;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LimitByStep : MonoBehaviour, ILimit
{
    public PlayerData playerData;
    public GameSteps step;
    public bool inverted = false;

    public bool shouldWalk = true;
    [SerializeField] private Vector3 CustomWalkOffset = Vector3.zero;

    public TextGroup textGroup;
    [SerializeField] private GameObject dialogBox;

    private Dialog dialog;

    void Awake()
    {
        dialog = gameObject.AddComponent<Dialog>();
        dialog.DialogBox = dialogBox;
        dialog.TextGroup = textGroup;
        dialog.DialogText = dialogBox.GetComponentInChildren<TMP_Text>();
        dialog.DialogSpeaker = dialogBox.GetComponentInChildren<TMP_Text>();
        dialog.Portrait = dialogBox.transform.Find("Portrait").GetComponent<Image>();

        Transform dialogSpeakerTransform = dialogBox.transform.Find("DialogSpeaker");
        dialog.DialogSpeaker = dialogSpeakerTransform.GetComponent<TMP_Text>();
    }

    public bool ShouldLimit(GameObject who)
    {
        // Se não tiver passado pelo step, não permite que o player realize uma interação
        return (!playerData.steps.Contains(step) ^ inverted);
    }

    public void Limited(GameObject who)
    {
        // Dialog mostrando mensagem sobre o limite
        dialog.TextGroup = textGroup;
        StartCoroutine(Execute(who));
    }

    IEnumerator Execute(GameObject who)
    {
        GameManager.Instance.UpdateGameState(GameManager.GameState.Interacting);

        if (shouldWalk)
        {
            Vector3 dest = CompareTag("Door") ? transform.GetChild(0).position : transform.position;
            GameObject.FindWithTag("Player").GetComponent<PlayerController>().GoTo(new Vector3(dest.x + CustomWalkOffset.x, dest.y + CustomWalkOffset.y, dest.z + CustomWalkOffset.z), this.transform);
            yield return null;
            yield return new WaitUntil(() => !PlayerController.anim.GetBool("Walk") && !PlayerController.anim.GetBool("Run"));
        }

        DialogAction result = DialogAction.None;
        yield return StartCoroutine(dialog.Execute(who, (value) => result = value));

        GameManager.Instance.UpdateGameState(GameManager.GameState.Playing);
        if (result == DialogAction.RemoveDialog)
            Destroy(this);
    }
}
