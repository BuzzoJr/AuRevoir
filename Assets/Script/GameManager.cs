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
        // Cheatcodes
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            // go to scene - hold shift and input the scene number (index in build)
            for (KeyCode k = KeyCode.Alpha0; k <= KeyCode.Alpha9; k++)
            {
                if (Input.GetKeyDown(k))
                    goToScene += k - KeyCode.Alpha0;
            }

            // reload scene - hold shift + R
            if (Input.GetKeyDown(KeyCode.R))
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else if (goToScene.Length > 0)
        {
            Debug.Log($"Cheatcode - go to scene: {goToScene} / {SceneManager.sceneCountInBuildSettings}");

            if (int.TryParse(goToScene, out int scene) && scene > 0 && scene < SceneManager.sceneCountInBuildSettings)
                SceneManager.LoadScene(scene - 1);

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
        Walking,
    }

    public void ResetData()
    {
        UpdateGameState(GameState.Playing);
    }
}
