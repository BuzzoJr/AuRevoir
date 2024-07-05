using System.Collections;
using UnityEngine;

public class WaitCarArrival : MonoBehaviour
{
    public GameObject player;
    public float delay = 5f;

    void Start()
    {
        StartCoroutine(ExitCar());
    }

    IEnumerator ExitCar()
    {
        GameManager.Instance.UpdateGameState(GameManager.GameState.Interacting);

        player.SetActive(false);

        yield return new WaitForSeconds(delay);

        player.SetActive(true);

        GameManager.Instance.UpdateGameState(GameManager.GameState.Playing);
    }
}
