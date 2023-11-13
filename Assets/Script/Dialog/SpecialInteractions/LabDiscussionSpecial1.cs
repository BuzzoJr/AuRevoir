using Assets.Script.Interaction;
using UnityEngine;

public class LabDiscussionSpecial1 : MonoBehaviour, ISpecial
{
    public DoorController door;

    public void Special(GameObject who)
    {
        door.SetLock(false);
    }
}
