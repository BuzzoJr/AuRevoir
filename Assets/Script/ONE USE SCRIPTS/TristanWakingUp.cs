using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Script.Dialog;
using Assets.Script.Interaction;
using Assets.Script.Locale;
using TMPro;
using UnityEngine.UI;

public class TristanWakingUp : MonoBehaviour
{
    public TextGroup textGroup = TextGroup.DialogWakeUpCall;
    public bool isDialog = true;
    [SerializeField] private GameObject dialogBox;
    [SerializeField] private GameObject thinkingBox;

    public GameObject playableTristan; // Assign this in the Inspector
    public bool pesadelo = true;
    private Animator animator;
    private Dialog dialog;

    void Awake()
    {
        dialog = gameObject.AddComponent<Dialog>();
        dialog.DialogBox = dialogBox;
        dialog.TextGroup = textGroup;
        dialog.DialogText = dialogBox.GetComponentInChildren<TMP_Text>();
        dialog.DialogSpeaker = dialogBox.GetComponentInChildren<TMP_Text>();
        dialog.Portrait = dialogBox.transform.Find("Portrait").GetComponent<Image>();

        dialog.ThinkingBox = thinkingBox;
        dialog.ThinkingText = thinkingBox.GetComponentInChildren<TMP_Text>();
        dialog.ThinkingSpeaker = thinkingBox.GetComponentInChildren<TMP_Text>();

        Transform dialogSpeakerTransform = dialogBox.transform.Find("DialogSpeaker");
        dialog.DialogSpeaker = dialogSpeakerTransform.GetComponent<TMP_Text>();
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(Execute());
    }

    IEnumerator Execute()
    {
        GameManager.Instance.UpdateGameState(GameManager.GameState.Interacting);

        if(pesadelo) {
            yield return new WaitForSeconds(6.3f); //Wake + Idle 0.3f
            DialogAction result = DialogAction.None;
            yield return StartCoroutine(dialog.Execute(gameObject, (value) => result = value, isDialog));
        }
        else {
            yield return new WaitForSeconds(10f); //Scare + Layingdown
        }

        playableTristan.SetActive(true);
        GameManager.Instance.UpdateGameState(GameManager.GameState.Playing);
        Destroy(this.gameObject);
    }
}
