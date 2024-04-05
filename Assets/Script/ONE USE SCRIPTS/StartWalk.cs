using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartWalk : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerController controller;
    public Transform destination;
    public float timeToWait = 5f;
    void Start()
    {
        Invoke("setPosition", timeToWait);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setPosition()
    {
        controller.GoTo(destination.position, null);
    }
}
