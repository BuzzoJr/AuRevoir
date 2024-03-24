using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState State;

    public static event System.Action<GameState> OnGameStateChange;

    private AudioSource AudioInstance { get; set; }

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
    }

    void Start()
    {
        UpdateGameState(GameState.Playing);
    }

    public void UpdateGameState(GameState newState)
    {
        State = newState;

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

    public void ResetData()
    {
        UpdateGameState(GameState.Playing);
    }
}
