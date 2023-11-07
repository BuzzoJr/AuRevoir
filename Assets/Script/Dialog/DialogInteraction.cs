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

    private Dialog dialog;

    void Awake()
    {
        dialog = gameObject.AddComponent<Dialog>();
        dialog.DialogBox = dialogBox;
        dialog.TextGroup = textGroup;
        dialog.DialogText = dialogBox.GetComponentInChildren<TMP_Text>();
    }

    public void Talk(GameObject who)
    {
        StartCoroutine(Execute(who));
    }

    IEnumerator Execute(GameObject who)
    {
        GameManager.Instance.UpdateGameState(GameManager.GameState.Interacting);
        if (shouldWalk)
        {
            PlayerController.navMeshAgent.destination = transform.position;
            yield return null;
            yield return new WaitUntil(() => !PlayerController.anim.GetBool("Walk"));
        }

        yield return StartCoroutine(dialog.Execute(who));
    }
}
