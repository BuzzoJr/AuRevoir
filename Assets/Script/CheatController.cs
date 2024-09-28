using Assets.Script;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheatController : MonoBehaviour
{
    public static CheatController Instance;

    public Transform grid;
    public GameObject popUp;

    public PlayerData playerData;

    private bool reading = false;
    private string details = "";

    public class GameData
    {
        public string previousScene;
        public List<string> visitedScenes = new();
        public List<GameSteps> steps = new();
        public List<string> IndoorScenes = new();
    }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Home))
        {
            reading = !reading;
            if (reading)
            {
                PopUp("You have started the cheating the system.\n" +
                      "Insert your desired destination and confirm by pressing 'HOME' again.\n" +
                      "Press 'DELETE' at any time to close.\n" +
                      "Choose your destination:\n" +
                      "   0 - Menu\n" +
                      "   1 - Bar's Bathroom\n" +
                      "   2 - Bar\n" +
                      "   3 - Bar after talking to Hank and Boss\n" +
                      "   4 - Back street\n" +
                      "   5 - Back street after cleared by police officer\n" +
                      "   6 - Back street after downloading client\n" +
                      "   7 - Bar ready to take the car\n" +
                      "   8 - Office Garage\n" +
                      "   9 - Office hall\n" +
                      "  10 - Office\n" +
                      "  11 - Office after talking to boss\n" +
                      "  12 - Office hall after talking to boss\n" +
                      "  13 - Upload room\n" +
                      "  14 - Nightmare bedroom\n" +
                      "  15 - Nightmare livingroom\n" +
                      "  16 - Bedroom\n"/* +
                      "  90 - EXTRA! Morge\n" +
                      "  91 - EXTRA! Laboratory"*/,
                      new Vector2(510, 625),//new Vector2(510, 685), // y+30 por linha adicionada
                      -1f); ;
            }
            else
            {
                RemovePopUps();
                ExecuteCheat();
                return;
            }

            details = "";
        }

        if (Input.GetKeyDown(KeyCode.Delete))
        {
            reading = false;
            RemovePopUps();
            return;
        }

        if (!reading)
            return;

        for (KeyCode k = KeyCode.Alpha0; k <= KeyCode.Alpha9; k++)
        {
            if (Input.GetKeyDown(k))
                details += k - KeyCode.Alpha0;
        }

        for (KeyCode k = KeyCode.Keypad0; k <= KeyCode.Keypad9; k++)
        {
            if (Input.GetKeyDown(k))
                details += k - KeyCode.Keypad0;
        }
    }
    private void RemovePopUps()
    {
        for (int i = grid.childCount - 1; i >= 0; i--)
            DestroyImmediate(grid.GetChild(i).gameObject);
    }

    private void PopUp(string message, Vector2 size, float delay)
    {
        var instance = Instantiate(popUp, grid);
        instance.GetComponent<RectTransform>().sizeDelta = size;
        instance.GetComponentInChildren<TMP_Text>().text = message;

        if (delay > 0)
            Destroy(instance, delay);
    }

    private void ExecuteCheat()
    {
        if (!int.TryParse(details, out int option))
        {
            PopUp($"Failed to read command '{details}'.",
                  new Vector2(250, 75),
                  2f);
            return;
        }

        RunCheat(option);
    }

    private void LoadSceneWithPreviousData(GameData data)
    {
        // WARN
        PopUp($"Loading scene!",
              new Vector2(250, 45),
              2f);

        GoToGameAt(data);
    }

    public void GoToGameAt(GameData data)
    {
        // Player Data
        playerData.ResetData();
        playerData.visitedScenes = data.visitedScenes;
        playerData.steps = data.steps;

        SceneManager.LoadScene(data.previousScene);
    }

    private void RunCheat(int option)
    {
        // Executa um método de nome dinâmico
        string methodName = $"RunCheat{option}";
        MethodInfo methodInfo = GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

        if (methodInfo != null)
        {
            methodInfo.Invoke(this, null); // O método está aqui no CheatController (this), e não precisa de parâmetro
            return;
        }

        // ERROR
        PopUp($"Failed to read command '{details}'.",
              new Vector2(250, 75),
              2f);
    }

    private void RunCheat0()
    {
        SceneManager.LoadScene("NewMenu");
    }

    private void RunCheat1()
    {
        LoadSceneWithPreviousData(new GameData()
        {
            previousScene = "C0BarBathroom",
            visitedScenes = new(),
            steps = new(),
        });
    }

    private void RunCheat2()
    {
        LoadSceneWithPreviousData(new GameData()
        {
            previousScene = "C0Bar",
            visitedScenes = new() { "C0BarBathroom" },
            steps = new(),
        });
    }

    private void RunCheat3()
    {
        LoadSceneWithPreviousData(new GameData()
        {
            previousScene = "C0Bar",
            visitedScenes = new() { "C0BarBathroom", "C0Bar" },
            steps = new() { GameSteps.GetFirstMission },
        });
    }

    private void RunCheat4()
    {
        LoadSceneWithPreviousData(new GameData()
        {
            previousScene = "C0Rua",
            visitedScenes = new() { "C0BarBathroom", "C0Bar" },
            steps = new() { GameSteps.GetFirstMission },
        });
    }

    private void RunCheat5()
    {
        LoadSceneWithPreviousData(new GameData()
        {
            previousScene = "C0Rua",
            visitedScenes = new() { "C0BarBathroom", "C0Bar", "C0Rua" },
            steps = new() { GameSteps.GetFirstMission, GameSteps.CarCrashPoliceTalk },
        });
    }

    private void RunCheat6()
    {
        LoadSceneWithPreviousData(new GameData()
        {
            previousScene = "C0Rua",
            visitedScenes = new() { "C0BarBathroom", "C0Bar", "C0Rua" },
            steps = new() { GameSteps.GetFirstMission, GameSteps.CarCrashPoliceTalk, GameSteps.CarCrashClientDownload },
        });
    }

    private void RunCheat7()
    {
        LoadSceneWithPreviousData(new GameData()
        {
            previousScene = "C0Bar",
            visitedScenes = new() { "C0BarBathroom", "C0Bar", "C0Rua" },
            steps = new() { GameSteps.GetFirstMission, GameSteps.CarCrashPoliceTalk, GameSteps.CarCrashClientDownload },
        });
    }

    private void RunCheat8()
    {
        LoadSceneWithPreviousData(new GameData()
        {
            previousScene = "C0OfficeGarage",
            visitedScenes = new() { "C0BarBathroom", "C0Bar", "C0Rua" },
            steps = new() { GameSteps.GetFirstMission, GameSteps.CarCrashPoliceTalk, GameSteps.CarCrashClientDownload },
        });
    }

    private void RunCheat9()
    {
        LoadSceneWithPreviousData(new GameData()
        {
            previousScene = "C0HallOffice",
            visitedScenes = new() { "C0BarBathroom", "C0Bar", "C0Rua", "C0OfficeGarage" },
            steps = new() { GameSteps.GetFirstMission, GameSteps.CarCrashPoliceTalk, GameSteps.CarCrashClientDownload },
        });
    }

    private void RunCheat10()
    {
        LoadSceneWithPreviousData(new GameData()
        {
            previousScene = "C3Office",
            visitedScenes = new() { "C0BarBathroom", "C0Bar", "C0Rua", "C0OfficeGarage", "C0HallOffice" },
            steps = new() { GameSteps.GetFirstMission, GameSteps.CarCrashPoliceTalk, GameSteps.CarCrashClientDownload },
        });
    }

    private void RunCheat11()
    {
        LoadSceneWithPreviousData(new GameData()
        {
            previousScene = "C3Office",
            visitedScenes = new() { "C0BarBathroom", "C0Bar", "C0Rua", "C0OfficeGarage", "C0HallOffice", "C3Office" },
            steps = new() { GameSteps.GetFirstMission, GameSteps.CarCrashPoliceTalk, GameSteps.CarCrashClientDownload, GameSteps.BossFirstMission },
        });
    }

    private void RunCheat12()
    {
        LoadSceneWithPreviousData(new GameData()
        {
            previousScene = "C0HallOffice",
            visitedScenes = new() { "C0BarBathroom", "C0Bar", "C0Rua", "C0OfficeGarage", "C0HallOffice", "C3Office" },
            steps = new() { GameSteps.GetFirstMission, GameSteps.CarCrashPoliceTalk, GameSteps.CarCrashClientDownload, GameSteps.BossFirstMission },
        });
    }

    private void RunCheat13()
    {
        LoadSceneWithPreviousData(new GameData()
        {
            previousScene = "C0UploadRoom",
            visitedScenes = new() { "C0BarBathroom", "C0Bar", "C0Rua", "C0OfficeGarage", "C0HallOffice", "C3Office" },
            steps = new() { GameSteps.GetFirstMission, GameSteps.CarCrashPoliceTalk, GameSteps.CarCrashClientDownload, GameSteps.BossFirstMission },
        });
    }

    private void RunCheat14()
    {
        LoadSceneWithPreviousData(new GameData()
        {
            previousScene = "C0Bedroom",
            visitedScenes = new() { "C0BarBathroom", "C0Bar", "C0Rua", "C0OfficeGarage", "C0HallOffice", "C3Office", "C0UploadRoom" },
            steps = new() { GameSteps.GetFirstMission, GameSteps.CarCrashPoliceTalk, GameSteps.CarCrashClientDownload, GameSteps.BossFirstMission },
        });
    }

    private void RunCheat15()
    {
        LoadSceneWithPreviousData(new GameData()
        {
            previousScene = "C0Livingroom",
            visitedScenes = new() { "C0BarBathroom", "C0Bar", "C0Rua", "C0OfficeGarage", "C0HallOffice", "C3Office", "C0UploadRoom", "C0Bedroom" },
            steps = new() { GameSteps.GetFirstMission, GameSteps.CarCrashPoliceTalk, GameSteps.CarCrashClientDownload, GameSteps.BossFirstMission },
        });
    }

    private void RunCheat16()
    {
        LoadSceneWithPreviousData(new GameData()
        {
            previousScene = "C1Bedroom",
            visitedScenes = new() { "C0BarBathroom", "C0Bar", "C0Rua", "C0OfficeGarage", "C0HallOffice", "C3Office", "C0UploadRoom", "C0Bedroom", "C0Livingroom" },
            steps = new() { GameSteps.GetFirstMission, GameSteps.CarCrashPoliceTalk, GameSteps.CarCrashClientDownload, GameSteps.BossFirstMission },
        });
    }
}
