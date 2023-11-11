using Assets.Script.Interaction;
using System.Collections;
using System.Collections.Generic;
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
        PlayerController.navMeshAgent.destination = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        yield return null;
        yield return new WaitUntil(() => !PlayerController.anim.GetBool("Walk"));
        canvasObj.SetActive(true);
        camMain.SetActive(false);
        camPanel.SetActive(true);
        objInt.SetActive(false);
        playerMesh.SetActive(false);
    }

    public void exitPanel() {
        canvasObj.SetActive(false);
        camMain.SetActive(true);
        camPanel.SetActive(false);
        objInt.SetActive(true);
        playerMesh.SetActive(true);
    }
}
