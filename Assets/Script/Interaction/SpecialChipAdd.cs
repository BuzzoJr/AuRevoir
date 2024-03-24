using Assets.Script;
using Assets.Script.Interaction;
using UnityEngine;

public class SpecialChipAdd : MonoBehaviour, ISpecial
{
    public PlayerData playerData;
    [SerializeField] private DoorController labDoor;

    public void Special(GameObject who)
    {
        if (!playerData.steps.Contains(GameSteps.EndGame))
            playerData.steps.Add(GameSteps.EndGame);
        labDoor.SetLock(false);
    }
}
