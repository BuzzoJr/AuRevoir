using Assets.Script;
using System;
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
    private int menu = 0;
    private string details = "";

    void Update()
    {
        if (!Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.RightShift))
        {
            if (reading)
            {
                for (int i = grid.childCount - 1; i >= 0; i--)
                    DestroyImmediate(grid.GetChild(i).gameObject);

                ExecuteCheat();
                menu = 0;
                reading = false;
            }

            return;
        }

        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl))
        {
            reading = true;
            PopUp("You have started the cheating the system.\n" +
                "Keep holding Shift to proceed.\n" +
                "Choose your cheating action:\n" +
                "  L - load a scene\n" +
                "  A - add a step",
                new Vector2(470, 155),
                3f);
        }

        if (!reading)
            return;

        if (menu == 0)
            MainMenu();
        else
        {
            for (KeyCode k = KeyCode.Alpha0; k <= KeyCode.Alpha9; k++)
            {
                if (Input.GetKeyDown(k))
                    details += k - KeyCode.Alpha0;
            }
        }
    }

    private void PopUp(string message, Vector2 size, float delay)
    {
        var instance = Instantiate(popUp, grid);
        instance.GetComponent<RectTransform>().sizeDelta = size;
        instance.GetComponentInChildren<TMP_Text>().text = message;
        Destroy(instance, delay);
    }

    private void ExecuteCheat()
    {
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

    private void MainMenu()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            menu = 1;
            PopUp("To load a scene, press the numbers that form the scene id and release Shift.\n" +
                "List of scenes:" + GetSceneList(),
                new Vector2(470, 75 + (30 * SceneManager.sceneCountInBuildSettings)),
                5f);
            details = "";
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            menu = 2;
            PopUp("To add a step, press the numbers that form the step id and release Shift.\n" +
                "List of steps:" + GetStepList(),
                new Vector2(470, 75 + (30 * Enum.GetValues(typeof(GameSteps)).Cast<int>().ToList().Count)),
                5f);
            details = "";
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
    }
}
