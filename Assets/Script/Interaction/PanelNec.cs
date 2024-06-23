using Assets.Script.Interaction;
using System.Collections;
using UnityEngine;

public class PanelNec : MonoBehaviour, IUse
{
    public GameObject canvasObj, camMain, camPanel, objInt, playerMesh;

    public void Use(GameObject who)
    {
        StartCoroutine(UsePanel());
    }

    IEnumerator UsePanel()
    {
        GameManager.Instance.UpdateGameState(GameManager.GameState.Interacting);

        var g = new GoTo();
        yield return StartCoroutine(g.GoToRoutine(new Vector3(transform.position.x, transform.position.y, transform.position.z), null));

        // Action cancelled
        if (GameManager.Instance.State != GameManager.GameState.Interacting)
            yield break;

        canvasObj.SetActive(true);
        camMain.SetActive(false);
        camPanel.SetActive(true);
        objInt.SetActive(false);
        playerMesh.SetActive(false);
    }

    public void exitPanel(bool finalExit = false)
    {
        GameManager.Instance.UpdateGameState(GameManager.GameState.Playing);
        canvasObj.SetActive(false);
        camMain.SetActive(true);
        camPanel.SetActive(false);

        if (!finalExit)
            objInt.SetActive(true);

        playerMesh.SetActive(true);
    }
}
