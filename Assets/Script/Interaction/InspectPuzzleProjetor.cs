using System.Collections;
using System.Collections.Generic;
using Assets.Script.Interaction;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InspectPuzzleProjetor : MonoBehaviour, ILookSpecial
{
    public GameObject player;
    public Transform target;

    public void LookSpecial(GameObject who)
    {
        player.transform.LookAt(target);
        gameObject.GetComponent<BoxCollider>().enabled = false;
    }
}
