using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Script;
using UnityEngine;

public class WaitCarArrival : MonoBehaviour
{
    public PlayerData playerData;
    public GameObject player;
    public float delay = 5f;
    public GameObject livre;
    public GameObject ocupado;
    public List<SceneRef> notTriggerFrom;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        if (!notTriggerFrom.Contains(playerData.previousScene))
        {
            StartCoroutine(ExitCar());
            animator.SetBool("Parked", false);
        }
        else
        {
            animator.SetBool("Parked", true);
        }
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
