using Assets.Script;
using Assets.Script.Dialog;
using Assets.Script.Locale;
using System.Collections;
using UnityEngine;

public class SyncController : MonoBehaviour
{
    public PlayerData playerData;
    public Animator mapAnim;
    public GameObject playerObj;
    public GameObject mainCamera;
    public GameObject childObj, canvasAll, canvasText, canvasBtn, maskObj, manHolog;
    public AudioSource audioOff;

    [Header("Text Interaction")]
    public TextGroup textGroup = TextGroup.CarCrashClient;
    public TextInteractionType textInteractionType = TextInteractionType.Dialog;
    [SerializeField] private GameObject dialogBox;
    [SerializeField] private GameObject thinkingBox;
    private Dialog dialog;

    void Awake()
    {
        dialog = gameObject.AddComponent<Dialog>();
        dialog.Configure(dialogBox, thinkingBox, textGroup, textInteractionType);
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
        manHolog.GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(4f);

        StartCoroutine(StutterAnimation(manHolog.GetComponent<Animator>()));

        playerData.AddStep(GameSteps.CarCrashClientDownload);

        DialogAction result = DialogAction.None;
        yield return StartCoroutine(dialog.Execute(playerObj, (value) => result = value));

        canvasAll.GetComponent<Canvas>().sortingOrder = 0;
        mapAnim.SetTrigger("Exit");
        audioOff.Play();
        yield return new WaitForSeconds(1f);

        childObj.SetActive(false);
        mainCamera.SetActive(true);

        playerObj.GetComponent<Animator>().SetBool("Crouch", false);
        yield return new WaitForSeconds(5f);

        GameManager.Instance.UpdateGameState(GameManager.GameState.Playing);
    }

    IEnumerator StutterAnimation(Animator animator)
    {
        while (childObj.activeSelf)
        {
            yield return new WaitForSeconds(Random.Range(3f, 10f));
            manHolog.GetComponent<Animator>().speed = 0;
            yield return new WaitForSeconds(Random.Range(0.25f, 0.5f));
            manHolog.GetComponent<Animator>().speed = 1;
            yield return new WaitForSeconds(Random.Range(0.25f, 0.5f));
            manHolog.GetComponent<Animator>().speed = 0;
            yield return new WaitForSeconds(Random.Range(0.25f, 0.5f));
            manHolog.GetComponent<Animator>().speed = 1;
        }
    }
}
