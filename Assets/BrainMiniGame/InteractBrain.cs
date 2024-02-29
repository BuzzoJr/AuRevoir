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
        GameObject.FindWithTag("Player").GetComponent<PlayerController>().GoTo(new Vector3(transform.position.x, transform.position.y, transform.position.z), null);

        yield return null;
        yield return new WaitUntil(() => !PlayerController.anim.GetBool("Walk"));
        player.SetActive(false);
        canvas.SetActive(true);
        canvasColision.SetActive(true);
        camMain.SetActive(false);
        camMiniGame.SetActive(true);
        gameObject.SetActive(false);
    }
}
