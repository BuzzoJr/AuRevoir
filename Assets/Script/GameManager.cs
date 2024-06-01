using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState State;

    public static event System.Action<GameState> OnGameStateChange;

    private AudioSource AudioInstance { get; set; }

    private string goToScene = "";

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

    void Update()
    {
        // Cheatcode go to scene - hold shift and input the scene number (index in build)
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            for (KeyCode k = KeyCode.Alpha0; k <= KeyCode.Alpha9; k++)
            {
                if (Input.GetKeyDown(k))
                    goToScene += k.ToString().Replace("Alpha", "");
            }
        }
        else if (goToScene.Length > 0)
        {
            Debug.Log($"Cheatcode - go to scene: {goToScene}");

            if (int.TryParse(goToScene, out int scene))
                SceneManager.LoadScene(scene);

            goToScene = "";
        }
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
