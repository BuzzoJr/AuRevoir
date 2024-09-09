using Assets.Script.Dialog;
using Assets.Script.Interaction;
using Assets.Script.Locale;
using System.Collections;
using UnityEngine;

public class DialogInteraction : MonoBehaviour, ITalk
{
    public bool shouldWalk = true;
    public bool shouldSit = false;
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
        yield return StartCoroutine(dialog.Execute(who, (value) => result = value));

        GameManager.Instance.UpdateGameState(GameManager.GameState.Playing);
        PlayerController.anim.SetBool("Sit", false);

        if (result == DialogAction.RemoveDialog)
            Destroy(this);
    }
}
