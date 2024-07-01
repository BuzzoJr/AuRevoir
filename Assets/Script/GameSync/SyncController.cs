using Assets.Script;
using Assets.Script.Dialog;
using Assets.Script.Locale;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SyncController : MonoBehaviour
{
    public TextGroup textGroup = TextGroup.CarCrashClient;
    [SerializeField] private GameObject dialogBox, thinkingBox;

    private Dialog dialog;

    public PlayerData playerData;
    public Animator mapAnim;
    public GameObject playerObj;
    public GameObject mainCamera;
    public GameObject childObj, canvasAll, canvasText, canvasBtn, maskObj, manHolog;

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

    public void EndSync()
    {
        StartCoroutine(ExitCoroutine());
    }

    IEnumerator ExitCoroutine()
    {
        canvasText.SetActive(false);
        canvasBtn.SetActive(false);
        canvasAll.GetComponent<Canvas>().sortingOrder = -5;
        yield return new WaitForSeconds(3f);
        maskObj.SetActive(true);
        yield return new WaitForSeconds(4f);
        manHolog.GetComponent<Animator>().enabled = true;

        playerData.AddStep(GameSteps.CarCrashClientDownload);

        DialogAction result = DialogAction.None;
        yield return StartCoroutine(dialog.Execute(playerObj, (value) => result = value));

        canvasAll.GetComponent<Canvas>().sortingOrder = 0;
        mapAnim.SetTrigger("Exit");
        yield return new WaitForSeconds(1f);

        childObj.SetActive(false);
        mainCamera.SetActive(true);
        GameManager.Instance.UpdateGameState(GameManager.GameState.Playing);
    }
}
