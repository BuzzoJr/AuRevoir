using Assets.Script.Interaction;
using System.Collections;
using UnityEngine;

public class InteractBrain : MonoBehaviour, IUse
{
    public GameObject camMain;
    public GameObject camMiniGame;
    public GameObject canvas;
    public GameObject canvasColision;
    public GameObject player;

    public void Use(GameObject who)
    {
        StartCoroutine(UseBrainMiniGame());
    }

    IEnumerator UseBrainMiniGame()
    {
        GameManager.Instance.UpdateGameState(GameManager.GameState.Interacting);

        var g = new GoTo();
        yield return StartCoroutine(g.GoToRoutine(new Vector3(transform.position.x, transform.position.y, transform.position.z), null));

        // Action cancelled
        if (GameManager.Instance.State != GameManager.GameState.Interacting)
            yield break;

        player.SetActive(false);
        canvas.SetActive(true);
        canvasColision.SetActive(true);
        camMain.SetActive(false);
        camMiniGame.SetActive(true);
        gameObject.SetActive(false);
    }
}
