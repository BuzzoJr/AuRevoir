using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState State;

    public static event System.Action<GameState> OnGameStateChange;

    private AudioSource AudioInstance;

    public AudioClip LavanderiaClip;

    private HashSet<string> visitedScenes = new HashSet<string>();

    private string currentSceneName;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            // Destroy this GameManager object, since it's a duplicate
            Destroy(gameObject);
        }
        else if (Instance == null)
        {
            // Set this GameManager object as the singleton instance
            Instance = this;

            // Mark this GameManager object to persist between scene changes
            DontDestroyOnLoad(gameObject);
        }
        AudioInstance = GetComponent<AudioSource>();
        currentSceneName = SceneManager.GetActiveScene().name;
        if(currentSceneName == "MainMenu")
        {
            Destroy(GameObject.Find("MusicEnd"));
        }
    }

    void Start()
    {
        UpdateGameState(GameState.Playing);
    }

    public void UpdateGameState(GameState newState)
    {
        State = newState;

        switch (newState)
        {
            case GameState.Menu:
                break;
            case GameState.Interacting:
                break;
            case GameState.Playing:
                break;
        }

        OnGameStateChange?.Invoke(newState);
    }

    public void UpdateSong(AudioClip newSong)
    {
        AudioInstance.PlayOneShot(newSong);
    }

    public enum GameState
    {
        Menu,
        Interacting,
        Playing,
    }

    public bool IsFirstTimeInScene(string sceneName)
    {
        if (visitedScenes.Contains(sceneName))
        {
            return false;
        }
        else
        {
            if (sceneName == "C8ExteriorLavanderia")
                AudioInstance.PlayOneShot(LavanderiaClip);
            else if (sceneName == "C12Necroterio")
                AudioInstance.PlayOneShot(LavanderiaClip);
            visitedScenes.Add(sceneName);
            return true;
        }
    }
}
