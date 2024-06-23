using Assets.Script;
using Assets.Script.Interaction;
using UnityEngine;

public class CarCrashPoliceSpecial : MonoBehaviour, ISpecial
{
    public PlayerData playerData;

    public void Special(GameObject who)
    {

        if (!playerData.steps.Contains(GameSteps.CarCrashPoliceTalk))
            playerData.steps.Add(GameSteps.CarCrashPoliceTalk);
    }
}
