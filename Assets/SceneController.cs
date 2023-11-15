using Assets.Script.Dialog;
using Assets.Script.Interaction;
using Assets.Script.Locale;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public PlayerData playerData;
    public Transform playerPos;
    public List<GameObject> spawnPosition = new List<GameObject>();
    [Header("FIRST TIME IN SCENE")]
    [SerializeField] private bool HasText = false;
    public TextGroup textGroup = TextGroup.DialogWakeUpCall;
    [SerializeField] private GameObject dialogBox;
    private TMP_Text dialogText;
    public AudioSource audioSource = null;
    private void Awake()
    {
        if (dialogBox)
            dialogText = dialogBox.GetComponentInChildren<TMP_Text>();

        if (playerData.previousScene != null)
        {
            foreach (GameObject spawnPos in spawnPosition)
            {
                if (spawnPos.name == playerData.previousScene)
                {
                    playerPos.position = new Vector3(spawnPos.transform.position.x, playerPos.position.y, spawnPos.transform.position.z);
                    playerPos.rotation = Quaternion.Euler(0f, spawnPos.transform.rotation.eulerAngles.y, 0f);

                    break;
                }
            }
        }
        playerData.previousScene = SceneManager.GetActiveScene().name;

        if (playerData.previousScene == "C9InteriorLavanderia")
            playerData.laundryVisited = true;
    }

    private void Start()
    {
        if (GameManager.Instance.IsFirstTimeInScene(gameObject.scene.name))
        {
            if (audioSource != null)
                audioSource.Play();

            if (HasText)
                StartCoroutine(DoFirstTimeAction());
        }
        else
        {
            if (gameObject.scene.name == "C1Bedroom" && playerData.phoneAwnsered)
            {
                GameObject phone = GameObject.Find("answering-machine");
                if (phone != null)
                {
                    DialogInteraction dialogInteraction = phone.GetComponent<DialogInteraction>();
                    AudioSource audio = phone.GetComponent<AudioSource>();
                    if (dialogInteraction != null)
                        Destroy(dialogInteraction);
                    if (audio != null)
                        Destroy(audio);
                }
            }
        }
    }

    IEnumerator DoFirstTimeAction()
    {
        if (!dialogBox)
            yield break;

        GameManager.Instance.UpdateGameState(GameManager.GameState.Interacting);
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

            if (textGroup == TextGroup.LabDiscussion && data == Locale.Texts[textGroup][6])
            {
                var special = GetComponentInChildren<ISpecial>();
                if (special != null)
                    special.Special(playerPos.gameObject);
            }

        }
        dialogBox.SetActive(false);
        GameManager.Instance.UpdateGameState(GameManager.GameState.Playing);
    }
}
