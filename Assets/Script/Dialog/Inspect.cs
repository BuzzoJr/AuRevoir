using Assets.Script.Dialog;
using Assets.Script.Interaction;
using Assets.Script.Locale;
using System.Collections;
using UnityEngine;

public class Inspect : MonoBehaviour, ILook
{
    public bool shouldWalk = true;
    [SerializeField] private Vector3 CustomWalkOffset = Vector3.zero;
    public Transform lookAtObj;

    [Header("Text Interaction")]
    [SerializeField] private bool HasText = true;
    [ConditionalHide("HasText")] public TextGroup textGroup = TextGroup.DialogWakeUpCall;
    [ConditionalHide("HasText")] public TextInteractionType textInteractionType = TextInteractionType.Dialog;
    [ConditionalHide("HasText")] public bool isDialog = true; // TODO: Depois de configurar os DialogTypes, remover este campo e usar o DialogType
    [ConditionalHide("HasText")] [SerializeField] private GameObject dialogBox;
    [ConditionalHide("HasText")] [SerializeField] private GameObject thinkingBox;
    private Dialog dialog;

    void Awake()
    {
        if (HasText)
        {
            dialog = gameObject.AddComponent<Dialog>();
            dialog.Configure(dialogBox, thinkingBox, textGroup, textInteractionType);
        }
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
            yield return StartCoroutine(dialog.Execute(who, (value) => result = value));

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
