using Assets.Script;
using Assets.Script.Locale;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheatController : MonoBehaviour
{
    public Transform grid;
    public GameObject popUp;

    public PlayerData playerData;

    private bool reading = false;
    private string details = "";

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
                      "  16 - Bedroom\n" +
                      "  90 - EXTRA! Morge\n" +
                      "  91 - EXTRA! Laboratory",
                      new Vector2(510, 685),
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

    private void LoadSceneWithPreviousData(SaveData data)
    {
        // WARN
        PopUp($"Loading scene!",
              new Vector2(250, 45),
              2f);

        SaveManager.Instance.LoadGameData(data);
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
        SceneManager.LoadScene(SceneRef.NewMenu.ToString());
    }

    private void RunCheat1()
    {
        LoadSceneWithPreviousData(new SaveData()
        {
            currentScene = SceneRef.B_BarBathroom,
            previousScene = SceneRef.B_BarBathroom,
            visitedScenes = new(),
            steps = new(),
            items = new(),
        });
    }

    private void RunCheat2()
    {
        LoadSceneWithPreviousData(new SaveData()
        {
            currentScene = SceneRef.B_Bar,
            previousScene = SceneRef.B_BarBathroom,
            visitedScenes = new() { SceneRef.B_BarBathroom },
            steps = new(),
            items = new(),
        });
    }

    private void RunCheat3()
    {
        LoadSceneWithPreviousData(new SaveData()
        {
            currentScene = SceneRef.B_Bar,
            previousScene = SceneRef.B_BarBathroom,
            visitedScenes = new() { SceneRef.B_BarBathroom, SceneRef.B_Bar },
            steps = new() { GameSteps.GetFirstMission },
            items = new() { ItemGroup.KeyCard },
        });
    }

    private void RunCheat4()
    {
        LoadSceneWithPreviousData(new SaveData()
        {
            currentScene = SceneRef.B_Rua,
            previousScene = SceneRef.B_Bar,
            visitedScenes = new() { SceneRef.B_BarBathroom, SceneRef.B_Bar },
            steps = new() { GameSteps.GetFirstMission },
            items = new() { ItemGroup.KeyCard },
        });
    }

    private void RunCheat5()
    {
        LoadSceneWithPreviousData(new SaveData()
        {
            currentScene = SceneRef.B_Rua,
            previousScene = SceneRef.B_Bar,
            visitedScenes = new() { SceneRef.B_BarBathroom, SceneRef.B_Bar, SceneRef.B_Rua },
            steps = new() { GameSteps.GetFirstMission, GameSteps.CarCrashPoliceTalk },
            items = new() { ItemGroup.KeyCard },
        });
    }

    private void RunCheat6()
    {
        LoadSceneWithPreviousData(new SaveData()
        {
            currentScene = SceneRef.B_Rua,
            previousScene = SceneRef.B_Bar,
            visitedScenes = new() { SceneRef.B_BarBathroom, SceneRef.B_Bar, SceneRef.B_Rua },
            steps = new() { GameSteps.GetFirstMission, GameSteps.CarCrashPoliceTalk, GameSteps.CarCrashClientDownload },
            items = new() { ItemGroup.KeyCard },
        });
    }

    private void RunCheat7()
    {
        LoadSceneWithPreviousData(new SaveData()
        {
            currentScene = SceneRef.B_Bar,
            previousScene = SceneRef.B_Rua,
            visitedScenes = new() { SceneRef.B_BarBathroom, SceneRef.B_Bar, SceneRef.B_Rua },
            steps = new() { GameSteps.GetFirstMission, GameSteps.CarCrashPoliceTalk, GameSteps.CarCrashClientDownload },
            items = new() { ItemGroup.KeyCard },
        });
    }

    private void RunCheat8()
    {
        LoadSceneWithPreviousData(new SaveData()
        {
            currentScene = SceneRef.O_OfficeGarage,
            previousScene = SceneRef.B_Bar,
            visitedScenes = new() { SceneRef.B_BarBathroom, SceneRef.B_Bar, SceneRef.B_Rua },
            steps = new() { GameSteps.GetFirstMission, GameSteps.CarCrashPoliceTalk, GameSteps.CarCrashClientDownload },
            items = new() { ItemGroup.KeyCard },
        });
    }

    private void RunCheat9()
    {
        LoadSceneWithPreviousData(new SaveData()
        {
            currentScene = SceneRef.O_HallOffice,
            previousScene = SceneRef.O_OfficeGarage,
            visitedScenes = new() { SceneRef.B_BarBathroom, SceneRef.B_Bar, SceneRef.B_Rua, SceneRef.O_OfficeGarage },
            steps = new() { GameSteps.GetFirstMission, GameSteps.CarCrashPoliceTalk, GameSteps.CarCrashClientDownload },
            items = new() { ItemGroup.KeyCard },
        });
    }

    private void RunCheat10()
    {
        LoadSceneWithPreviousData(new SaveData()
        {
            currentScene = SceneRef.O_Office,
            previousScene = SceneRef.O_HallOffice,
            visitedScenes = new() { SceneRef.B_BarBathroom, SceneRef.B_Bar, SceneRef.B_Rua, SceneRef.O_OfficeGarage, SceneRef.O_HallOffice },
            steps = new() { GameSteps.GetFirstMission, GameSteps.CarCrashPoliceTalk, GameSteps.CarCrashClientDownload },
            items = new() { ItemGroup.KeyCard },
        });
    }

    private void RunCheat11()
    {
        LoadSceneWithPreviousData(new SaveData()
        {
            currentScene = SceneRef.O_Office,
            previousScene = SceneRef.O_HallOffice,
            visitedScenes = new() { SceneRef.B_BarBathroom, SceneRef.B_Bar, SceneRef.B_Rua, SceneRef.O_OfficeGarage, SceneRef.O_HallOffice, SceneRef.O_Office },
            steps = new() { GameSteps.GetFirstMission, GameSteps.CarCrashPoliceTalk, GameSteps.CarCrashClientDownload, GameSteps.CarCrashBossTalk },
            items = new() { ItemGroup.KeyCard },
        });
    }

    private void RunCheat12()
    {
        LoadSceneWithPreviousData(new SaveData()
        {
            currentScene = SceneRef.O_HallOffice,
            previousScene = SceneRef.O_Office,
            visitedScenes = new() { SceneRef.B_BarBathroom, SceneRef.B_Bar, SceneRef.B_Rua, SceneRef.O_OfficeGarage, SceneRef.O_HallOffice, SceneRef.O_Office },
            steps = new() { GameSteps.GetFirstMission, GameSteps.CarCrashPoliceTalk, GameSteps.CarCrashClientDownload, GameSteps.CarCrashBossTalk },
            items = new() { ItemGroup.KeyCard },
        });
    }

    private void RunCheat13()
    {
        LoadSceneWithPreviousData(new SaveData()
        {
            currentScene = SceneRef.O_UploadRoom,
            previousScene = SceneRef.O_HallOffice,
            visitedScenes = new() { SceneRef.B_BarBathroom, SceneRef.B_Bar, SceneRef.B_Rua, SceneRef.O_OfficeGarage, SceneRef.O_HallOffice, SceneRef.O_Office },
            steps = new() { GameSteps.GetFirstMission, GameSteps.CarCrashPoliceTalk, GameSteps.CarCrashClientDownload, GameSteps.CarCrashBossTalk },
            items = new() { ItemGroup.KeyCard },
        });
    }

    private void RunCheat14()
    {
        LoadSceneWithPreviousData(new SaveData()
        {
            currentScene = SceneRef.AP_BedroomBadDream,
            previousScene = SceneRef.O_UploadRoom,
            visitedScenes = new() { SceneRef.B_BarBathroom, SceneRef.B_Bar, SceneRef.B_Rua, SceneRef.O_OfficeGarage, SceneRef.O_HallOffice, SceneRef.O_Office, SceneRef.O_UploadRoom },
            steps = new() { GameSteps.GetFirstMission, GameSteps.CarCrashPoliceTalk, GameSteps.CarCrashClientDownload, GameSteps.CarCrashBossTalk },
            items = new() { ItemGroup.KeyCard },
        });
    }

    private void RunCheat15()
    {
        LoadSceneWithPreviousData(new SaveData()
        {
            currentScene = SceneRef.AP_LivingroomBadDream,
            previousScene = SceneRef.AP_BedroomBadDream,
            visitedScenes = new() { SceneRef.B_BarBathroom, SceneRef.B_Bar, SceneRef.B_Rua, SceneRef.O_OfficeGarage, SceneRef.O_HallOffice, SceneRef.O_Office, SceneRef.O_UploadRoom, SceneRef.AP_BedroomBadDream },
            steps = new() { GameSteps.GetFirstMission, GameSteps.CarCrashPoliceTalk, GameSteps.CarCrashClientDownload, GameSteps.CarCrashBossTalk },
            items = new() { ItemGroup.KeyCard },
        });
    }

    private void RunCheat16()
    {
        LoadSceneWithPreviousData(new SaveData()
        {
            currentScene = SceneRef.AP_Bedroom,
            previousScene = SceneRef.AP_LivingroomBadDream,
            visitedScenes = new() { SceneRef.B_BarBathroom, SceneRef.B_Bar, SceneRef.B_Rua, SceneRef.O_OfficeGarage, SceneRef.O_HallOffice, SceneRef.O_Office, SceneRef.O_UploadRoom, SceneRef.AP_BedroomBadDream, SceneRef.AP_LivingroomBadDream },
            steps = new() { GameSteps.GetFirstMission, GameSteps.CarCrashPoliceTalk, GameSteps.CarCrashClientDownload, GameSteps.CarCrashBossTalk },
            items = new() { ItemGroup.KeyCard },
        });
    }

    private void RunCheat90()
    {
        LoadSceneWithPreviousData(new SaveData()
        {
            currentScene = SceneRef.CC_Necroterio,
            previousScene = SceneRef.NewMenu,
            visitedScenes = new(),
            steps = new(),
            items = new(),
        });
    }

    private void RunCheat91()
    {
        LoadSceneWithPreviousData(new SaveData()
        {
            currentScene = SceneRef.LAB_Laboratory,
            previousScene = SceneRef.NewMenu,
            visitedScenes = new(),
            steps = new(),
            items = new(),
        });
    }
}
