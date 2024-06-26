using Assets.Script.Interaction;
using System.Collections;
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

        var g = new GoTo();
        yield return StartCoroutine(g.GoToRoutine(new Vector3(transform.position.x + CustomWalkOffset.x, transform.position.y + CustomWalkOffset.y, transform.position.z + CustomWalkOffset.z), lookAt));

        // Action cancelled
        if (GameManager.Instance.State != GameManager.GameState.Interacting)
            yield break;

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
