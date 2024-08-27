using Assets.Script;
using Assets.Script.Dialog;
using Assets.Script.Interaction;
using Assets.Script.Locale;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour, ILangConsumer
{
    public PlayerData playerData;
    public Transform playerPos;
    public List<GameObject> spawnPosition = new();
    public List<SceneRef> spawnReferece = new();
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
        playerData.previousScene = playerData.currentScene;
        playerData.currentScene = (SceneRef)Enum.Parse(typeof(SceneRef), SceneManager.GetActiveScene().name);

        GameManager.Instance.UpdateGameState(GameManager.GameState.Playing);
        bool needToActivate = playerPos.gameObject.activeSelf;

        if (dialogBox)
            dialogText = dialogBox.GetComponentInChildren<TMP_Text>();
        GameManager.Instance.showingDialog = false;

        if (needToActivate)
            playerPos.gameObject.SetActive(false);

        int spawnIndex = spawnReferece.IndexOf(playerData.previousScene);
        if (spawnIndex < 0 && spawnPosition.Count > spawnReferece.Count)
            spawnIndex = spawnPosition.Count - 1;

        if (spawnIndex >= 0)
        {
            playerPos.position = new Vector3(spawnPosition[spawnIndex].transform.position.x, playerPos.position.y, spawnPosition[spawnIndex].transform.position.z);
            playerPos.rotation = Quaternion.Euler(0f, spawnPosition[spawnIndex].transform.rotation.eulerAngles.y, 0f);
        }

        if (needToActivate)
            playerPos.gameObject.SetActive(true);

        // AutoSave
        if (SaveManager.Instance != null)
            SaveManager.Instance.SaveGame("autosave");
    }

    private void Start()
    {
        if (IsFirstTimeInScene(playerData.currentScene.ToString()))
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
            DeletarFigurantes();
        }

        stopRun(playerData.currentScene);
    }

    private bool IsFirstTimeInScene(string sceneName)
    {
        if (playerData.visitedScenes.Contains((SceneRef)Enum.Parse(typeof(SceneRef), sceneName)))
        {
            return false;
        }
        else
        {
            playerData.visitedScenes.Add((SceneRef)Enum.Parse(typeof(SceneRef), sceneName));
            return true;
        }
    }
    private void stopRun(SceneRef sceneName)
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

    private void DeletarFigurantes()
    {
        GameObject[] figurantes = GameObject.FindGameObjectsWithTag("Figurante");

        // Itera sobre cada objeto encontrado e o destroi
        foreach (GameObject figurante in figurantes)
        {
            Destroy(figurante);
        }
    }
}
