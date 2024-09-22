using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    const string SAVEFILE_EXTENSION = ".aus";

    public static SaveManager Instance { get; private set; }

    public PlayerData playerData;

    private List<string> saveFiles;

    private SaveFileHandler fileHandler;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this);

#if UNITY_EDITOR
        fileHandler = new SaveFileHandler(Path.Combine(Application.persistentDataPath, "saves"), false);
#else
        fileHandler = new SaveFileHandler(Path.Combine(Application.persistentDataPath, "saves"), true);
#endif
    }

    private void Start()
    {
        UpdateFiles();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
            Debug.Log("saveFiles:\n" + string.Join('\n', saveFiles));

        if (Input.GetKeyDown(KeyCode.S))
            SaveGame("teste");

        if (Input.GetKeyDown(KeyCode.L))
            Debug.Log("LoadGame(\"teste\") = " + LoadGame("teste"));

        if (Input.GetKeyDown(KeyCode.E))
            Debug.Log("SaveExists(\"teste\") = " + SaveExists("teste"));
    }

    public void UpdateFiles()
    {
        saveFiles = fileHandler.ListFiles().Where(f => Path.GetExtension(f) == SAVEFILE_EXTENSION).Select(f => Path.GetFileNameWithoutExtension(f)).ToList();
    }

    public bool SaveExists(string saveName)
    {
        return saveFiles.Contains(saveName);
    }

    public void SaveGame(string saveName)
    {
        SaveData data = new()
        {
            currentScene = playerData.currentScene,
            previousScene = playerData.previousScene,
            visitedScenes = playerData.visitedScenes,
            steps = playerData.steps,
            items = playerData.items,
            teddybearScenes = playerData.teddybearScenes,
        };

        fileHandler.SaveFile(data, saveName + SAVEFILE_EXTENSION);
        UpdateFiles();
    }

    public bool LoadGame(string saveName)
    {
        if (!saveFiles.Contains(saveName))
            return false;

        SaveData data = fileHandler.LoadFile(saveName + SAVEFILE_EXTENSION);
        if (data == null)
            return false;

        LoadGameData(data);

        return true;
    }

    public bool VerificaSaveGame(string saveName)
    { //Verifica se ja existe algum arquivo de save
        if (!saveFiles.Contains(saveName))
            return false;

        SaveData data = fileHandler.LoadFile(saveName + SAVEFILE_EXTENSION);
        if (data == null)
            return false;

        return true;
    }

    public void LoadGameData(SaveData data)
    {
        // Player Data
        playerData.ResetData();
        playerData.currentScene = data.previousScene;  // Vai virar previous scene assim que carregar a cena
        playerData.visitedScenes = data.visitedScenes;
        playerData.steps = data.steps;
        playerData.items = data.items;
        playerData.teddybearScenes = data.teddybearScenes;

        SceneManager.LoadScene(data.currentScene.ToString());
    }
}
