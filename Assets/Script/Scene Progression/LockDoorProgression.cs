using Assets.Script;
using UnityEngine;

public class LockDoorProgression : MonoBehaviour
{
    public PlayerData playerData;

    public DoorController door;
    public GameSteps step;
    public bool lockBeforeStep = true;

    void Start()
    {
        door.SetLock(playerData.HasStep(step) ^ lockBeforeStep);
    }
}
