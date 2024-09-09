using Assets.Script;
using Assets.Script.Dialog;
using Assets.Script.Interaction;
using Assets.Script.Locale;
using System.Collections;
using UnityEngine;

public class LimitByStep : MonoBehaviour, ILimit
{
    public PlayerData playerData;
    public GameSteps step;
    public bool limitWhenHasStep = false;

    public bool shouldWalk = true;
    [SerializeField] private Vector3 CustomWalkOffset = Vector3.zero;

    [Header("Text Interaction")]
    public TextGroup textGroup = TextGroup.DialogWakeUpCall;
    public TextInteractionType textInteractionType = TextInteractionType.Dialog;
    private Dialog dialog;

    void Awake()
    {
        dialog = gameObject.AddComponent<Dialog>();
        dialog.Configure(textGroup, textInteractionType);
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
            var g = new GoTo();
            yield return StartCoroutine(g.GoToRoutine(new Vector3(dest.x + CustomWalkOffset.x, dest.y + CustomWalkOffset.y, dest.z + CustomWalkOffset.z), this.transform));

            // Action cancelled
            if (GameManager.Instance.State != GameManager.GameState.Interacting)
                yield break;
        }

        DialogAction result = DialogAction.None;
        yield return StartCoroutine(dialog.Execute(who, (value) => result = value));

        GameManager.Instance.UpdateGameState(GameManager.GameState.Playing);
        if (result == DialogAction.RemoveDialog)
            Destroy(this);
    }
}
