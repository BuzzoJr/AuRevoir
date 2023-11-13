using Assets.Script.Interaction;
using UnityEngine;

public class LabDiscussionSpecial : MonoBehaviour, ISpecial
{
    public DoorController door;

    public void Special(GameObject who)
    {
        door.SetLock(true);
    }
}
