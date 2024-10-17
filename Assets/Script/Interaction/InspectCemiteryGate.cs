using System.Collections;
using System.Collections.Generic;
using Assets.Script.Interaction;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InspectCemiteryGate : MonoBehaviour, ILookSpecial
{
    public GameObject player, gate;
    public Transform target;

    public void LookSpecial(GameObject who)
    {
        player.transform.LookAt(target);
        StartCoroutine("Peephole");
    }

    private IEnumerator Peephole()
    {
        gate.GetComponent<Animator>().SetBool("Open", true);
        yield return new WaitForSeconds(4f);
        GameManager.Instance.UpdateGameState(GameManager.GameState.Playing);
        gate.GetComponent<BoxCollider>().enabled = false;
        GetComponent<LookClose>().CustomExitAnim();
    }
}
