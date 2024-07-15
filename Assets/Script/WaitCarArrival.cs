using System.Collections;
using UnityEngine;

public class WaitCarArrival : MonoBehaviour
{
    public GameObject player;
    public float delay = 5f;
    public GameObject livre;
    public GameObject ocupado;

    void Start()
    {
        StartCoroutine(ExitCar());
    }

    IEnumerator ExitCar()
    {
        yield return null;
        player.SetActive(false);
        GameManager.Instance.UpdateGameState(GameManager.GameState.Interacting);
        CursorController.inCutscene = true;
        yield return new WaitForSeconds(delay);
        livre.SetActive(false);
        ocupado.SetActive(true);
        player.SetActive(true);
        player.GetComponent<Animator>().SetTrigger("ExitCar");
        yield return new WaitForSeconds(4f);
        CursorController.inCutscene = false;
        GameManager.Instance.UpdateGameState(GameManager.GameState.Playing);
    }
}
