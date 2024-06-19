using System.Collections;
using System.Collections.Generic;
using Assets.Script.Interaction;
using UnityEngine;

public class HankSpecial : MonoBehaviour, ISpecial
{
    public AudioSource audioSource;
    public AudioClip pickup;

    public void Special(GameObject who)
    {
        if (!audioSource.isPlaying)
            audioSource.Play();
        else
        {
            audioSource.loop = false;
            audioSource.Stop();
            audioSource.PlayOneShot(pickup);
        }
    }
}
