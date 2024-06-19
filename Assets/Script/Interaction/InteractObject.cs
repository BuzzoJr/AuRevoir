using System.Collections;
using System.Collections.Generic;
using Assets.Script.Dialog;
using Assets.Script.Interaction;
using Assets.Script.Locale;
using UnityEngine;

public class InteractObject : MonoBehaviour, IUse
{
    public bool shouldSit = false;
    public Transform lookAt;
    [SerializeField] private Vector3 CustomWalkOffset = Vector3.zero;

    public void Use(GameObject who)
    {
        StartCoroutine(Interact());
    }

    IEnumerator Interact()
    {
        GameManager.Instance.UpdateGameState(GameManager.GameState.Interacting);
        GameObject.FindWithTag("Player").GetComponent<PlayerController>().GoTo(new Vector3(transform.position.x + CustomWalkOffset.x, transform.position.y + CustomWalkOffset.y, transform.position.z + CustomWalkOffset.z), lookAt);
        yield return null;
        yield return new WaitUntil(() => !PlayerController.anim.GetBool("Walk"));
        Debug.Log("StoppedWalking");
        if (shouldSit)
        {
            PlayerController.anim.SetBool("Sit", true);
            PlayerController.anim.SetBool("SitIdle2", true);
        }

        runSpecial();
    }

    private void runSpecial()
    {
        var special = GetComponent<IUseSpecial>();
        if (special != null)
            special.UseSpecial(gameObject);
        else
        {
            GameManager.Instance.UpdateGameState(GameManager.GameState.Playing);
            PlayerController.anim.SetBool("Sit", false);
            PlayerController.anim.SetBool("SitIdle2", false);
        }
    }

}
