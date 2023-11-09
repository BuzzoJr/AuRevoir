using System.Collections;
using System.Collections.Generic;
using Assets.Script.Interaction;
using UnityEngine;

public class BossSpecial : MonoBehaviour, ISpecial
{
    private DoorController door;

    public void Special(GameObject who)
    {
        door.locked = false;
    }
}
