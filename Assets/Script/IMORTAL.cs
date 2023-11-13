using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IMORTAL : MonoBehaviour {

    void Awake()
    {
        DontDestroyOnLoad(gameObject);   
    }
}
