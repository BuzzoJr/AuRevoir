using Assets.Script;
using Assets.Script.Interaction;
using UnityEngine;

public class CarCrashPoliceSpecial : MonoBehaviour, ISpecial
{
    public PlayerData playerData;

    public void Special(GameObject who)
    {
        playerData.steps.Add(GameSteps.CarCrashPoliceTalk);
    }
}
