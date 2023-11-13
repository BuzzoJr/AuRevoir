using Assets.Script.Dialog;
using Assets.Script.Interaction;
using Assets.Script.Locale;
using System.Collections;
using TMPro;
using UnityEngine;

public class UseItemDialog : MonoBehaviour, IUseItem
{
    public bool shouldWalk = true;
    public string targetItem1;
    public TextGroup textGroup1 = TextGroup.DialogWakeUpCall;
    public string targetItem2;
    public TextGroup textGroup2 = TextGroup.DialogWakeUpCall;
    private TextGroup textGroup = TextGroup.DialogWakeUpCall;
    [SerializeField] private GameObject dialogBox;
    private TMP_Text dialogText;
    [SerializeField] private Vector3 CustomWalkOffset = Vector3.zero;

    void Awake()
    {
        dialogText = dialogBox.GetComponentInChildren<TMP_Text>();
    }

    public void UseItem(GameObject who)
    {
        if (who.name == targetItem1)
        {
            textGroup = textGroup1;
            StartCoroutine(CoroutineExample());
            return;
        }

        if (who.name == targetItem2)
        {
            textGroup = textGroup2;
            StartCoroutine(CoroutineExample());
            return;
        }
    }

    IEnumerator CoroutineExample()
    {
        GameManager.Instance.UpdateGameState(GameManager.GameState.Interacting);

        if (shouldWalk)
        {
            PlayerController.navMeshAgent.destination = new Vector3(transform.position.x + CustomWalkOffset.x, transform.position.y + CustomWalkOffset.y, transform.position.z + CustomWalkOffset.z);

            yield return null;
            yield return new WaitUntil(() => !PlayerController.anim.GetBool("Walk"));
        }
        yield return null;

        dialogBox.SetActive(true);
        foreach (TextData data in Locale.Texts[textGroup])
        {
            dialogText.color = TextColorManager.textTypeColors[data.Type];
            dialogText.text = TextColorManager.TextSpeaker(data.Type, data.Text);

            bool clicked = false;
            float delayTime = data.Delay > 0 ? data.Delay : AllDialogs.defaultDelay;
            float elapsedTime = 0;

            while (elapsedTime < delayTime && !clicked)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    clicked = true;
                }
                elapsedTime += Time.deltaTime;
                yield return null;
            }
        }
        dialogBox.SetActive(false);
        GameManager.Instance.UpdateGameState(GameManager.GameState.Playing);
    }
}
