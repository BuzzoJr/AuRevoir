using Assets.Script.Dialog;
using Assets.Script.Interaction;
using Assets.Script.Locale;
using System.Collections;
using UnityEngine;

public class DialogItemInteraction : MonoBehaviour, IUseItem
{
    public bool shouldWalk = true;
    public bool shouldSit = false;

    public string targetItem;
    [SerializeField] private Vector3 CustomWalkOffset = Vector3.zero;


    [Header("Text Interaction")]
    public TextGroup textGroupSuccess = TextGroup.DialogWakeUpCall;
    public TextInteractionType textInteractionTypeSuccess = TextInteractionType.Dialog;
    public TextGroup textGroupFail = TextGroup.DialogWakeUpCall;
    public TextInteractionType textInteractionTypeFail = TextInteractionType.Dialog;
    public bool isDialog = true; // TODO: Depois de configurar os DialogTypes, remover este campo e usar o DialogType
    [SerializeField] private GameObject dialogBox;
    [SerializeField] private GameObject thinkingBox;
    private Dialog dialog;

    void Awake()
    {
        dialog = gameObject.AddComponent<Dialog>();
        dialog.Configure(dialogBox, thinkingBox, textGroupSuccess, textInteractionTypeSuccess);
    }

    public void UseItem(GameObject who)
    {
        if (targetItem == who.name)
        {
            dialog.TextGroup = textGroupSuccess;
            dialog.Type = textInteractionTypeSuccess;
        }
        else
        {
            dialog.TextGroup = textGroupFail;
            dialog.Type = textInteractionTypeFail;
        }

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