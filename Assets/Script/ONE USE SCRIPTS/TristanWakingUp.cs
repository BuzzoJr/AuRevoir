using Assets.Script;
using Assets.Script.Dialog;
using Assets.Script.Locale;
using System.Collections;
using UnityEngine;

public class TristanWakingUp : MonoBehaviour
{
    public GameObject playableTristan; // Assign this in the Inspector
    public bool pesadelo = true;
    public PlayerData playerData;

    [Header("Text Interaction")]
    public TextGroup textGroup = TextGroup.DialogWakeUpCall;
    public TextInteractionType textInteractionType = TextInteractionType.Dialog;
    public bool isDialog = true; // TODO: Depois de configurar os DialogTypes, remover este campo e usar o DialogType
    [SerializeField] private GameObject dialogBox;
    [SerializeField] private GameObject thinkingBox;
    private Dialog dialog;

    void Awake()
    {
        dialog = gameObject.AddComponent<Dialog>();
        dialog.Configure(dialogBox, thinkingBox, textGroup, textInteractionType);
    }

    void Start()
    {
        if (playerData.HasStep(GameSteps.AwakeBed))
        {
            playableTristan.SetActive(true);
            GameManager.Instance.UpdateGameState(GameManager.GameState.Playing);
            Destroy(gameObject);
        }
        else
        {
            StartCoroutine(Execute());
        }
    }

    IEnumerator Execute()
    {
        GameManager.Instance.UpdateGameState(GameManager.GameState.Interacting);
        CursorController.inCutscene = true;
        if (pesadelo)
        {
            yield return new WaitForSeconds(6.3f); //Wake + Idle 0.3f
            DialogAction result = DialogAction.None;
            yield return StartCoroutine(dialog.Execute(gameObject, (value) => result = value));
        }
        else
        {
            yield return new WaitForSeconds(9f); //Scare + Layingdown
        }

        playerData.AddStep(GameSteps.AwakeBed);
        playableTristan.SetActive(true);
        GameManager.Instance.UpdateGameState(GameManager.GameState.Playing);
        Destroy(gameObject);
    }
}
