using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamLookAt : MonoBehaviour
{
    private GameObject player;

    void Start()
    {
        FindPlayerWithTag();
    }

    void Update()
    {
        if (player != null)
        {
            transform.LookAt(player.transform);
        }
    }

    void FindPlayerWithTag()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            Debug.LogError("Player not found. Make sure the player has the tag 'Player'");
        }
    }
}
