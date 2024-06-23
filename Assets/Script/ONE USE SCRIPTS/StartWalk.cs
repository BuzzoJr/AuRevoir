using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartWalk : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerController controller;
    public Transform destination;
    public float timeToWait = 5f;
    public float timeToWaitPiss = 5f;
    public AudioSource Piss;
    public float timeToWaitRestroom = 5f;
    public AudioSource RestroomAudio;
    void Start()
    {
        Invoke("setPosition", timeToWait);
        Invoke("piss", timeToWaitPiss);
        Invoke("restroom", timeToWaitRestroom);
    }


    public void setPosition()
    {
        controller.GoTo(destination.position, null);
    }
    public void piss()
    {
        Piss.enabled = true;
    }

    public void restroom()
    {
        RestroomAudio.enabled = true;
    }
}
