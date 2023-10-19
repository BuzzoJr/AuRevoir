using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public PlayerData playerData;
    public Transform playerPos;
    public List<GameObject> spawnPosition = new List<GameObject>();
    private void Awake()
    {
        if(playerData.previousScene != null)
        {
            foreach (GameObject spawnPos in spawnPosition)
            {
                if (spawnPos.name == playerData.previousScene)
                {
                    playerPos.position = new Vector3(spawnPos.transform.position.x, playerPos.position.y, spawnPos.transform.position.z);
                    playerPos.rotation = Quaternion.Euler(0f, spawnPos.transform.rotation.eulerAngles.y, 0f);

                    break; 
                }
            }
        }
        playerData.previousScene = SceneManager.GetActiveScene().name;
    }
}
