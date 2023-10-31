using System;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class DoorController : MonoBehaviour
{
    public SceneRef moveRef = SceneRef.C1Bedroom;
    public GameObject transObj, globalObj;

    public enum SceneRef
    {
        C1Bedroom,
        C2Livingroom,
        C7Beco,
        C8ExteriorLavanderia,
        C9InteriorLavanderia,
        C10Transicao,
        SampleScene
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(transObj != null)
                StartCoroutine(delayTransition());
            else
                SceneManager.LoadScene("Scenes/"+moveRef.ToString());
        }
    }

    IEnumerator delayTransition()
    {
        globalObj.SetActive(false);
        transObj.SetActive(true);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Scenes/"+moveRef.ToString());
    }
}
