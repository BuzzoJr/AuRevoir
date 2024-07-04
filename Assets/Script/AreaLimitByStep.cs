using Assets.Script;
using Assets.Script.Dialog;
using Assets.Script.Locale;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AreaLimitByStep : MonoBehaviour
{
    public PlayerData playerData;
    public GameSteps step;
    public bool limitWhenHasStep = false;

    public Transform outOfLimit;

    public bool HasText = false;

    public TextGroup textGroup;
    [SerializeField] private GameObject dialogBox;
    [SerializeField] private GameObject thinkingBox;

    public bool isDialog = true;
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

    public bool ShouldLimit()
    {
        // Limit interactions when the player:
        //  limitWhenHasStep == true -> have the step in playerData
        //  limitWhenHasStep == false -> doesn't have the step in playerData
        return (!playerData.HasStep(step) ^ limitWhenHasStep);
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerController player;
        if (!other.TryGetComponent(out player))
            return;

        if (!ShouldLimit())
            return;

        GameManager.Instance.UpdateGameState(GameManager.GameState.Interacting);
        player.GoTo(outOfLimit.position);

        dialog.TextGroup = textGroup;
        StartCoroutine(Execute(player.gameObject));
    }

    IEnumerator Execute(GameObject who)
    {
        GameManager.Instance.UpdateGameState(GameManager.GameState.Interacting);

        DialogAction result = DialogAction.None;
        yield return StartCoroutine(dialog.Execute(who, (value) => result = value, isDialog));

        GameManager.Instance.UpdateGameState(GameManager.GameState.Playing);
        if (result == DialogAction.RemoveDialog)
            Destroy(this);
    }
}
