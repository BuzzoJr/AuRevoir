using Assets.Script;
using Assets.Script.Dialog;
using Assets.Script.Locale;
using System.Collections;
using UnityEngine;

public class AreaLimitByStep : MonoBehaviour
{
    public PlayerData playerData;
    public GameSteps step;
    public bool limitWhenHasStep = false;

    public Transform outOfLimit;

    [Header("Text Interaction")]
    [SerializeField] private bool HasText = true;
    [ConditionalHide("HasText")] public TextGroup textGroup = TextGroup.DialogWakeUpCall;
    [ConditionalHide("HasText")] public TextInteractionType textInteractionType = TextInteractionType.Dialog;
    private Dialog dialog;

    void Awake()
    {
        if (HasText)
        {
            dialog = gameObject.AddComponent<Dialog>();
            dialog.Configure(textGroup, textInteractionType);
        }
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
        yield return StartCoroutine(dialog.Execute(who, (value) => result = value));

        GameManager.Instance.UpdateGameState(GameManager.GameState.Playing);
        if (result == DialogAction.RemoveDialog)
            Destroy(this);
    }
}
