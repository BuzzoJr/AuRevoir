using System.Collections;
using System.Collections.Generic;
using Assets.Script.Interaction;
using UnityEngine;

public class InspectDoorSpecial : MonoBehaviour, ILookSpecial
{
    public GameObject magicEye;
    public Animator animator;
    public Animator animator2;
    public BaddreamController baddreamController;
    public float transitionDuration = 2f;

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

        // Wait for 1 second
        yield return new WaitForSeconds(transitionDuration);

        // Wait for a mouse click
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

        // Disable the MagicEye object
        magicEye.SetActive(false);
        animator.enabled = true;
        animator2.enabled = true;
        baddreamController.enabled = true;

        // Update game state to Playing
        GameManager.Instance.UpdateGameState(GameManager.GameState.Playing);
    }
}
