using System.Collections;
using System.Collections.Generic;
using Assets.Script.Interaction;
using UnityEngine;
using UnityEngine.SceneManagement;
using Assets.Script;

public class InspectCemiteryGate : MonoBehaviour, ILookSpecial
{
    public GameObject player, gate;
    public Transform target;
    public GameSteps steps;
    public PlayerData playerData;

    void Start() {
        if(playerData.steps.Contains(steps)) {
            gate.GetComponent<Animator>().SetBool("Open", true);
            gate.GetComponent<BoxCollider>().enabled = false;
        }
    }

    public void LookSpecial(GameObject who)
    {
        player.transform.LookAt(target);
        StartCoroutine("Peephole");
    }

    private IEnumerator Peephole()
    {
        GetComponent<AudioSource>().Play();
        gate.GetComponent<Animator>().SetBool("Open", true);
        playerData.AddStep(steps);
        yield return new WaitForSeconds(4f);
        GameManager.Instance.UpdateGameState(GameManager.GameState.Playing);
        gate.GetComponent<BoxCollider>().enabled = false;
        GetComponent<LookClose>().CustomExitAnim();
    }
}
