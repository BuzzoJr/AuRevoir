using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepRunningOnSceneChange : MonoBehaviour {

    void Awake()
    {
        DontDestroyOnLoad(gameObject);   
    }
}
