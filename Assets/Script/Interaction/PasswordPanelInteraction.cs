using Assets.Script.Interaction;
using System.Collections;
using TMPro;
using UnityEngine;
using Assets.Script;

public class PasswordPanelInteraction : MonoBehaviour
{
    public DoorController door;
    public PlayerData playerData;
    public Animator animDoor;
    public GameSteps steps1;

    void Awake() {
        if (playerData.steps.Contains(steps1)) {
            door.locked = false;
            gameObject.tag = "Untagged";
        }
    }

    public void Unlock()
    {
        door.SetLock(false);
        playerData.AddStep(GameSteps.PasswordSewer);
        Destroy(this);
    }
}
