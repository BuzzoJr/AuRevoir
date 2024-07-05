using Assets.Script;
using Assets.Script.Dialog;
using Assets.Script.Interaction;
using Assets.Script.Locale;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour, ILangConsumer
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
    public AudioClip backgroundMusic = null;

    private int currentIndex = -1;

    public void UpdateLangTexts()
    {
        if (currentIndex >= 0)
        {
            TextData data = Locale.Texts[textGroup][currentIndex];
            dialogText.color = TextColorManager.textTypeColors[data.Type];
            dialogText.text = data.Text;
        }
    }

    void OnDestroy()
    {
        Locale.UnregisterConsumer(this);
    }

    private void Awake()
    {
        bool needToActivate = playerPos.gameObject.activeSelf;

        if (dialogBox)
            dialogText = dialogBox.GetComponentInChildren<TMP_Text>();

        if(needToActivate)
            playerPos.gameObject.SetActive(false);

        if (playerData.previousScene != null)
        {
            foreach (GameObject spawnPos in spawnPosition)
            {
                if (spawnPos.name == playerData.previousScene || spawnPos.name == "Else")
                {
                    playerPos.position = new Vector3(spawnPos.transform.position.x, playerPos.position.y, spawnPos.transform.position.z);
                    playerPos.rotation = Quaternion.Euler(0f, spawnPos.transform.rotation.eulerAngles.y, 0f);

                    break;
                }
            }
        }

        if(needToActivate)
            playerPos.gameObject.SetActive(true);

        playerData.previousScene = SceneManager.GetActiveScene().name;

        if (playerData.previousScene == "C9InteriorLavanderia")
            playerData.AddStep(GameSteps.LaundryVisited);
    }

    private void Start()
    {
        if (IsFirstTimeInScene(gameObject.scene.name))
        {
            if (audioSource != null)
                audioSource.Play();

            if (backgroundMusic != null)
                GameManager.Instance.UpdateSong(backgroundMusic);

            if (HasText)
                StartCoroutine(DoFirstTimeAction());
        }
        else
        {
            if (gameObject.scene.name == "C1Bedroom" && playerData.HasStep(GameSteps.PhoneAnswered))
            {
                GameObject phone = GameObject.Find("answering-machine");
                if (phone != null)
                {
                    DialogInteraction dialogInteraction = phone.GetComponent<DialogInteraction>();
                    AudioSource audio = phone.GetComponent<AudioSource>();
                    if (dialogInteraction != null)
                        Destroy(dialogInteraction);
                    if (audio != null)
                        audio.clip = null;
                }
            }

            if (gameObject.scene.name == "C0HallOffice" && playerData.HasStep(GameSteps.BossFirstMission))
            {
                GameObject doorToUpload = GameObject.Find("Door Right");
                if (doorToUpload != null)
                    doorToUpload.GetComponentInChildren<DoorController>().SetLock(false);
            }
        }

        stopRun(gameObject.scene.name);
    }

    private bool IsFirstTimeInScene(string sceneName)
    {
        if (playerData.visitedScenes.Contains(sceneName))
        {
            return false;
        }
        else
        {
            playerData.visitedScenes.Add(sceneName);
            return true;
        }
    }
    private void stopRun(string sceneName)
    {
        if (playerData.IndoorScenes.Contains(sceneName))
        {
            PlayerController playerController = playerPos.GetComponent<PlayerController>();
            playerController.canRun = false;
        }

    }

    IEnumerator DoFirstTimeAction()
    {
        if (!dialogBox)
            yield break;

        GameManager.Instance.UpdateGameState(GameManager.GameState.Interacting);
        dialogBox.SetActive(true);
        Locale.RegisterConsumer(this);
        for (int i = 0; i < Locale.Texts[textGroup].Count; i++)
        {
            currentIndex = i;
            UpdateLangTexts();

            TextData data = Locale.Texts[textGroup][currentIndex];
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

            if (textGroup == TextGroup.LabDiscussion && i == 6)
            {
                var special = GetComponentInChildren<ISpecial>();
                if (special != null)
                    special.Special(playerPos.gameObject);
            }

        }
        if (textGroup == TextGroup.LabDiscussion)
        {
            var special = GetComponentInChildren<ISpecial>();
            if (special != null)
                special.Special(playerPos.gameObject);
        }
        Locale.UnregisterConsumer(this);
        dialogBox.SetActive(false);
        GameManager.Instance.UpdateGameState(GameManager.GameState.Playing);
    }
}
