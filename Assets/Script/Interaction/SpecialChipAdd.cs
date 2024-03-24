using System.Collections;
using System.Collections.Generic;
using Assets.Script.Interaction;
using UnityEngine;

public class SpecialChipAdd : MonoBehaviour, ISpecial
{
    public PlayerData playerData;
    [SerializeField] private DoorController labDoor;

    public void Special(GameObject who)
    {
        playerData.EndGame = true;
        labDoor.SetLock(false);
    }
}
