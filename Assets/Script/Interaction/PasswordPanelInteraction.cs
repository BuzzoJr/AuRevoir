using Assets.Script.Interaction;
using UnityEngine;

public class PasswordPanelInteraction : MonoBehaviour, IUse
{
    public DoorController door;
    public Light light;
    public Canvas canvas;

    public void Use(GameObject who)
    {
        if (door.locked)
        {
            door.SetLock(false);
            light.color = Color.green;
            Destroy(this);
        }
    }
}
