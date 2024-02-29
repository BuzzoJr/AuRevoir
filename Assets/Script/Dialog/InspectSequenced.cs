using Assets.Script.Dialog;
using Assets.Script.Interaction;
using Assets.Script.Locale;
using System.Collections;
using TMPro;
using UnityEngine;

public class InspectSequenced : MonoBehaviour, ILook, ILangConsumer
{
    public bool shouldWalk = true;
    private TextGroup textGroup = TextGroup.LaundryBody;
    [SerializeField] private GameObject dialogBox;
    private TMP_Text dialogText;
    [SerializeField] private Vector3 CustomWalkOffset = Vector3.zero;

    public void UpdateLangTexts()
    {
        TextData data = Locale.Texts[textGroup][StaticSequences.laundryCorpses];
        dialogText.color = TextColorManager.textTypeColors[data.Type];
        dialogText.text = TextColorManager.TextSpeaker(data.Type, data.Text);
    }

    void OnDestroy()
    {
        Locale.UnregisterConsumer(this);
    }

    void Awake()
    {
        dialogText = dialogBox.GetComponentInChildren<TMP_Text>();
        StaticSequences.laundryCorpses = 0;
    }

    void ILook.Look(GameObject who)
    {
        StartCoroutine(CoroutineExample());
    }

    IEnumerator CoroutineExample()
    {
        GameManager.Instance.UpdateGameState(GameManager.GameState.Interacting);

        if (shouldWalk)
        {
            GameObject.FindWithTag("Player").GetComponent<PlayerController>().GoTo(new Vector3(transform.position.x + CustomWalkOffset.x, transform.position.y + CustomWalkOffset.y, transform.position.z + CustomWalkOffset.z), null);

            yield return null;
            yield return new WaitUntil(() => !PlayerController.anim.GetBool("Walk"));
        }
        yield return null;

        dialogBox.SetActive(true);
        Locale.RegisterConsumer(this);
        UpdateLangTexts();

        TextData data = Locale.Texts[textGroup][StaticSequences.laundryCorpses++];
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
        Locale.UnregisterConsumer(this);
        dialogBox.SetActive(false);
        GameManager.Instance.UpdateGameState(GameManager.GameState.Playing);
        tag = "Untagged";
        Destroy(this);
    }
}
