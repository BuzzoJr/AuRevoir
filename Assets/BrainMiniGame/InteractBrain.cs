using Assets.Script.Interaction;
using Assets.Script.Locale;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractBrain : MonoBehaviour, IUse
{
    public GameObject camMain;
    public GameObject camMiniGame;
    public GameObject canvas;
    public GameObject player;

    public void Use(GameObject who)
    {
        StartCoroutine(UseBrainMiniGame());
    }

    IEnumerator UseBrainMiniGame()
    {
        GameManager.Instance.UpdateGameState(GameManager.GameState.Interacting);
        PlayerController.navMeshAgent.destination = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        yield return null;
        yield return new WaitUntil(() => !PlayerController.anim.GetBool("Walk"));
        player.SetActive(false);
        canvas.SetActive(true);
        camMain.SetActive(false);
        camMiniGame.SetActive(true);
        gameObject.SetActive(false);
    }
}
