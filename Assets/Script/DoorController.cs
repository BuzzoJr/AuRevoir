using System;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DoorController : MonoBehaviour
{
    public SceneRef moveRef = SceneRef.C1Bedroom;
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
            SceneManager.LoadScene("Scenes/"+moveRef.ToString());
        }
    }
}
