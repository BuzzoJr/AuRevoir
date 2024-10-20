using System.Collections;
using System.Collections.Generic;
using Assets.Script.Interaction;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UsePasswordSpecial : MonoBehaviour, ILookSpecial
{
    public GameObject magicEye;
    public GameObject defaultVolume;
    public GameObject horrorVolume;
    public GameObject animRoom;
    public GameObject player;
    public Transform target;
    public float transitionDuration = 2f;
    public float badDreamDuration = 7f;

    public void LookSpecial(GameObject who)
    {
        StartCoroutine("Peephole");
    }

    private IEnumerator Peephole()
    {
        // Enable the MagicEye object
        magicEye.SetActive(true);

        // Update game state to Interacting
        GameManager.Instance.UpdateGameState(GameManager.GameState.Interacting);
        CursorController.inCutscene = true;
        // Wait for 1 second
        yield return new WaitForSeconds(transitionDuration);

        // Wait for a mouse click
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

        // Disable the MagicEye object
        magicEye.SetActive(false);
        defaultVolume.SetActive(false);
        horrorVolume.SetActive(true);
        animRoom.GetComponent<Animator>().enabled = true;
        player.transform.LookAt(target);
        player.GetComponent<PlayerController>().enabled = false;
        player.GetComponent<Animator>().SetBool("Pain", true);

        yield return new WaitForSeconds(badDreamDuration);
        SceneManager.LoadScene("C1Bedroom");
    }
}
