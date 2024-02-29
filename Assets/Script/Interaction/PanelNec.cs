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
        GameObject.FindWithTag("Player").GetComponent<PlayerController>().GoTo(new Vector3(transform.position.x, transform.position.y, transform.position.z), null);
        
        yield return null;
        yield return new WaitUntil(() => !PlayerController.anim.GetBool("Walk"));
        canvasObj.SetActive(true);
        camMain.SetActive(false);
        camPanel.SetActive(true);
        objInt.SetActive(false);
        playerMesh.SetActive(false);
    }

    public void exitPanel(bool finalExit = false) {
        canvasObj.SetActive(false);
        camMain.SetActive(true);
        camPanel.SetActive(false);

        if(!finalExit)
            objInt.SetActive(true);

        playerMesh.SetActive(true);
    }
}
