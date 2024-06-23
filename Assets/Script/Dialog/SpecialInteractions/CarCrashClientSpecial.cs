using Assets.Script.Interaction;
using UnityEngine;

public class CarCrashClientSpecial : MonoBehaviour, ISpecial
{
    // Colocar isso no minigame de sync
    // public PlayerData playerData;

    public void Special(GameObject who)
    {
        // Colocar isso no minigame de sync
        //playerData.steps.Add(GameSteps.CarCrashClientDownload);

        // Abrir mini game de sync
        Debug.Log("Abrir minigame de sync");
    }
}
