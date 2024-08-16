using Assets.Script;
using UnityEngine;

public class EndGameDoor : MonoBehaviour
{
    private DoorController door;
    public PlayerData playerData;
    // Start is called before the first frame update
    void Start()
    {
        if (playerData.HasStep(GameSteps.EndGame))
        {
            door = GetComponent<DoorController>();
            door.moveRef = SceneRef.EndScene;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
