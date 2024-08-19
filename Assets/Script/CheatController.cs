using Assets.Script;
using Assets.Script.Locale;
using System.Collections.Generic;
using System.Linq;
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

        switch (option)
        {
            case 0:
                // MENU
                SceneManager.LoadScene(0);
                break;

            case 1:
                // Bar's Bathroom
                LoadSceneWithPreviousData(1);
                break;

            case 2:
                // Bar
                LoadSceneWithPreviousData(2);
                break;

            case 3:
                // Bar after talking to Hank and Boss
                LoadSceneWithPreviousData(2, new List<GameSteps>() {
                        GameSteps.GetFirstMission,
                    });
                break;

            case 4:
                // Back street
                LoadSceneWithPreviousData(3, new List<GameSteps>() {
                        GameSteps.GetFirstMission,
                    });
                break;

            case 5:
                // Back street after cleared by police officer
                LoadSceneWithPreviousData(3, new List<GameSteps>() {
                        GameSteps.GetFirstMission,
                        GameSteps.CarCrashPoliceTalk,
                    });
                break;

            case 6:
                // Back street after downloading client
                LoadSceneWithPreviousData(3, new List<GameSteps>() {
                        GameSteps.GetFirstMission,
                        GameSteps.CarCrashPoliceTalk,
                        GameSteps.CarCrashClientDownload,
                    });
                break;

            case 7:
                // Bar ready to take the car
                LoadSceneWithPreviousData(2, new List<GameSteps>() {
                        GameSteps.GetFirstMission,
                        GameSteps.CarCrashPoliceTalk,
                        GameSteps.CarCrashClientDownload,
                    }, 3);
                break;

            case 8:
                // Office Garage
                LoadSceneWithPreviousData(4, new List<GameSteps>() {
                        GameSteps.GetFirstMission,
                        GameSteps.CarCrashPoliceTalk,
                        GameSteps.CarCrashClientDownload,
                    });
                break;

            case 9:
                // Office hall
                LoadSceneWithPreviousData(5, new List<GameSteps>() {
                        GameSteps.GetFirstMission,
                        GameSteps.CarCrashPoliceTalk,
                        GameSteps.CarCrashClientDownload,
                    });
                break;

            case 10:
                // Office
                LoadSceneWithPreviousData(6, new List<GameSteps>() {
                        GameSteps.GetFirstMission,
                        GameSteps.CarCrashPoliceTalk,
                        GameSteps.CarCrashClientDownload,
                    });
                break;

            case 11:
                // Office after talking to boss
                LoadSceneWithPreviousData(6, new List<GameSteps>() {
                        GameSteps.GetFirstMission,
                        GameSteps.CarCrashPoliceTalk,
                        GameSteps.CarCrashClientDownload,
                        GameSteps.BossFirstMission,
                    });
                break;

            case 12:
                // Office hall after talking to boss
                LoadSceneWithPreviousData(5, new List<GameSteps>() {
                        GameSteps.GetFirstMission,
                        GameSteps.CarCrashPoliceTalk,
                        GameSteps.CarCrashClientDownload,
                        GameSteps.BossFirstMission,
                    }, 6);
                break;

            case 13:
                // Upload room
                LoadSceneWithPreviousData(7, new List<GameSteps>() {
                        GameSteps.GetFirstMission,
                        GameSteps.CarCrashPoliceTalk,
                        GameSteps.CarCrashClientDownload,
                        GameSteps.BossFirstMission,
                    });
                break;

            case 14:
                // Nightmare bedroom
                LoadSceneWithPreviousData(8, new List<GameSteps>() {
                        GameSteps.GetFirstMission,
                        GameSteps.CarCrashPoliceTalk,
                        GameSteps.CarCrashClientDownload,
                        GameSteps.BossFirstMission,
                    });
                break;

            case 15:
                // Nightmare livingroom
                LoadSceneWithPreviousData(9, new List<GameSteps>() {
                        GameSteps.GetFirstMission,
                        GameSteps.CarCrashPoliceTalk,
                        GameSteps.CarCrashClientDownload,
                        GameSteps.BossFirstMission,
                    });
                break;

            case 16:
                // Bedroom
                LoadSceneWithPreviousData(10, new List<GameSteps>() {
                        GameSteps.GetFirstMission,
                        GameSteps.CarCrashPoliceTalk,
                        GameSteps.CarCrashClientDownload,
                        GameSteps.BossFirstMission,
                    });
                break;

            case 90:
                // EXTRA! Morge
                LoadSceneWithPreviousData(11);
                break;

            case 91:
                // EXTRA! Laboratory
                LoadSceneWithPreviousData(12);
                break;

            default:
                // ERROR
                PopUp($"Failed to read command '{details}'.",
                      new Vector2(250, 75),
                      2f);
                break;
        }
    }

    private void LoadSceneWithPreviousData(int scene, List<GameSteps> steps = null, int lastScene = 0)
    {
        // PLAYER DATA
        playerData.ResetData();

        if (scene >= 2)
        {
            string sceneName = "";

            for (int s = 1; s < scene; s++)
            {
                sceneName = GetSceneName(s);
                playerData.visitedScenes.Add(sceneName);
            }

            playerData.previousScene = sceneName;
        }

        if (lastScene > 0)
        {
            playerData.visitedScenes.Add(playerData.previousScene);
            playerData.previousScene = GetSceneName(lastScene);
        }

        if (steps != null)
            playerData.steps = steps;

        // ITEMS
        List<ItemGroup> groups = new();

        if (steps != null && steps.Contains(GameSteps.GetFirstMission))
            groups.Add(ItemGroup.KeyCard);

        // TODO: Reset inventory
        if (groups.Count > 0)
            AddItems(groups);

        // WARN
        PopUp($"Loading scene!",
              new Vector2(250, 45),
              2f);

        // LOAD
        SceneManager.LoadScene(scene);
    }

    private string GetSceneName(int scene)
    {
        return System.IO.Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(scene));
    }

    private void AddItems(List<ItemGroup> groups)
    {
        GameManager.Instance.inventoryObjects
            .Where(o => groups.Contains(o.group))
            .ToList()
            .ForEach(o =>
            {
                if (o.type == ItemType.Item)
                    Inventory.instance.AddItem(o, false);
                else
                    Documents.instance.AddDocument(o, false);
            });
    }

    /*

            switch (menu)
        {
            case 1:

                if (int.TryParse(details, out int scene) && scene > 0 && scene <= SceneManager.sceneCountInBuildSettings)
                {
                    PopUp($"Loading scene:\n" +
                        $"  - {scene}: {System.IO.Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(scene - 1))}",
                        new Vector2(250, 75),
                        2f);

                    SceneManager.LoadScene(scene - 1);
                }
                else
                {
                    PopUp($"Failed to load scene:\n" +
                        $"  - {details}.",
                        new Vector2(250, 75),
                        2f);
                }
                break;

            case 2:
                if (int.TryParse(details, out int step) && Enum.IsDefined(typeof(GameSteps), step))
                {
                    PopUp($"Adding step:\n" +
                        $"  - {step}: {(GameSteps)step}",
                        new Vector2(250, 75),
                        2f);

                    playerData.AddStep((GameSteps)step);
                }
                else
                {
                    PopUp($"Failed to add step:\n" +
                        $"  - {details}.",
                        new Vector2(250, 75),
                        2f);
                }
                break;

            default:
                PopUp("Cheating system deactivated!",
                    new Vector2(340, 45),
                    1f);
                break;
        }
    }
    
    private string GetSceneList()
    {
        string list = "";
        int digits = SceneManager.sceneCountInBuildSettings.ToString().Length;
        for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            list += string.Format($"\n  {{0,{digits}}} - {{1}}", i + 1, System.IO.Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(i)));
        }
        return list;
    }

    private string GetStepList()
    {
        string list = "";
        int digits = Enum.GetValues(typeof(GameSteps)).Cast<int>().ToList().Max().ToString().Length;
        foreach (GameSteps step in Enum.GetValues(typeof(GameSteps)))
        {
            list += string.Format($"\n  {{0,{digits}}} - {{1}}", (int)step, step.ToString());
        }
        return list;
    }*/
}
