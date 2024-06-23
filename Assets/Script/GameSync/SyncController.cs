using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Script;
using Assets.Script.Dialog;
using Assets.Script.Interaction;
using Assets.Script.Locale;
using TMPro;
using UnityEngine.UI;

public class SyncController : MonoBehaviour
{
    public TextGroup textGroup = TextGroup.CarCrashClient;
    [SerializeField] private GameObject dialogBox;

    private Dialog dialog;

    public PlayerData playerData;
    public Animator mapAnim;
    public GameObject playerObj;
    public GameObject mainCamera;
    public GameObject childObj;

    void Awake()
    {
        dialog = gameObject.AddComponent<Dialog>();
        dialog.DialogBox = dialogBox;
        dialog.TextGroup = textGroup;
        dialog.DialogText = dialogBox.GetComponentInChildren<TMP_Text>();
        dialog.DialogSpeaker = dialogBox.GetComponentInChildren<TMP_Text>();
        dialog.Portrait = dialogBox.transform.Find("Portrait").GetComponent<Image>();

        Transform dialogSpeakerTransform = dialogBox.transform.Find("DialogSpeaker");
        dialog.DialogSpeaker = dialogSpeakerTransform.GetComponent<TMP_Text>();
    }

    public void EndSync() {
        StartCoroutine(ExitCoroutine());
    }

    IEnumerator ExitCoroutine()
    {
        yield return new WaitForSeconds(3f);
        mapAnim.SetTrigger("Exit");
        yield return new WaitForSeconds(0.5f);
        childObj.SetActive(false);
        mainCamera.SetActive(true);

        if (!playerData.steps.Contains(GameSteps.CarCrashClientDownload))
            playerData.steps.Add(GameSteps.CarCrashClientDownload);

        DialogAction result = DialogAction.None;
        yield return StartCoroutine(dialog.Execute(playerObj, (value) => result = value));

        GameManager.Instance.UpdateGameState(GameManager.GameState.Playing);

    }
}
