using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private GameObject ply;

    void Start()
    {
        ply = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        transform.LookAt(ply.transform);
    }
}
