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
        C8ExteriorLavanderia,
        SampleScene
    }
    public void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene("Scenes/"+moveRef.ToString());
    }
}
