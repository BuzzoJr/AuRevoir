using Assets.Script.Dialog;
using Assets.Script.Interaction;
using Assets.Script.Locale;
using System.Collections;
using UnityEngine;

public class InspectSequenced : MonoBehaviour, ILook
{
    public bool shouldWalk = true;
    [SerializeField] private Vector3 CustomWalkOffset = Vector3.zero;
    public Transform lookAtObj;

    [Header("Text Interaction")]
    public TextGroup textGroup = TextGroup.LaundryBody;
    private Dialog dialog;

    void Awake()
    {
        dialog = gameObject.AddComponent<Dialog>();
        dialog.Configure(textGroup, TextInteractionType.Sequence);
        StaticSequences.laundryCorpses = 0;
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
        yield return StartCoroutine(dialog.Execute(who, (value) => result = value, StaticSequences.laundryCorpses, StaticSequences.laundryCorpses + 1));

        StaticSequences.laundryCorpses++;

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
