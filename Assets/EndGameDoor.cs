using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameDoor : MonoBehaviour
{
    private DoorController door;
    public PlayerData playerData;
    // Start is called before the first frame update
    void Start()
    {
        if (playerData.EndGame)
        {
            door = GetComponent<DoorController>();
            door.moveRef = DoorController.SceneRef.EndScene;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
