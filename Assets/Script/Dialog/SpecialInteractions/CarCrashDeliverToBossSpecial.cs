using Assets.Script;
using Assets.Script.Interaction;
using UnityEngine;

public class CarCrashDeliverToBossSpecial : MonoBehaviour, ISpecial
{
    public PlayerData playerData;

    public void Special(GameObject who)
    {
        playerData.AddStep(GameSteps.BossFirstMission);
    }
}
