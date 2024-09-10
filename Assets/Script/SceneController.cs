using Assets.Script;
using Assets.Script.Dialog;
using Assets.Script.Locale;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public PlayerData playerData;
    public Transform playerPos;
    public List<GameObject> spawnPosition = new();
    public List<SceneRef> spawnReferece = new();

    [Header("FIRST TIME IN SCENE")]

    public AudioSource audioSource = null;
    public AudioClip backgroundMusic = null;
    public bool exactPosition = false;

    [SerializeField] private bool HasText = false;
    [ConditionalHide("HasText")] public TextGroup textGroup = TextGroup.DialogWakeUpCall;
    [ConditionalHide("HasText")] public TextInteractionType textInteractionType = TextInteractionType.Sequence;

    private void Awake()
    {
        playerData.previousScene = playerData.currentScene;
        playerData.currentScene = (SceneRef)Enum.Parse(typeof(SceneRef), SceneManager.GetActiveScene().name);

        GameManager.Instance.UpdateGameState(GameManager.GameState.Playing);
        bool needToActivate = playerPos.gameObject.activeSelf;

        if (needToActivate)
            playerPos.gameObject.SetActive(false);

        int spawnIndex = spawnReferece.IndexOf(playerData.previousScene);
        if (spawnIndex < 0 && spawnPosition.Count > spawnReferece.Count)
            spawnIndex = spawnPosition.Count - 1;

        if (spawnIndex >= 0)
        {
            if (exactPosition)
                playerPos.position = new Vector3(spawnPosition[spawnIndex].transform.position.x, spawnPosition[spawnIndex].transform.position.y, spawnPosition[spawnIndex].transform.position.z);
            else
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
        GameManager.Instance.UpdateGameState(GameManager.GameState.Interacting);

        while (Input.GetMouseButtonDown(0))
            yield return null;

        Dialog dialog = gameObject.AddComponent<Dialog>();
        dialog.Configure(textGroup, textInteractionType);

        yield return StartCoroutine(dialog.Execute(gameObject, (value) => { }));

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
