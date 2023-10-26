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
        //StartCoroutine(CoroutineExample());
        StartCoroutine(Execute());
    }

    IEnumerator Execute()
    {
        if (shouldWalk)
        {
            PlayerController.navMeshAgent.destination = transform.position;
            yield return null;
            yield return new WaitUntil(() => !PlayerController.anim.GetBool("Walk"));
        }

        yield return StartCoroutine(dialog.Execute());
    }

    /*IEnumerator CoroutineExample()
    {
        PlayerController.navMeshAgent.destination = transform.position;
        yield return null;
        yield return new WaitUntil(() => !PlayerController.anim.GetBool("Walk"));

        dialogBox.SetActive(true);
        foreach (TextData data in Locale.Texts[textGroup])
        {
            dialogText.color = TextColorManager.textTypeColors[data.Type];
            dialogText.text = data.Type != TextType.Player ? data.Type + ": " + data.Text : data.Text;

            bool clicked = false;
            float delayTime = data.Delay > 0 ? data.Delay : 2.5f;
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
    }*/
}
