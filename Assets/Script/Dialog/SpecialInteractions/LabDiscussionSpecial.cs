using System;
using System.Collections;
using Assets.Script.Interaction;
using UnityEngine;

public class LabDiscussionSpecial : MonoBehaviour, ISpecial
{
    public DoorController door;
    public AudioSource loopLab;
    public AudioSource loopSong;
    public AudioSource doorAudio;
    private int i = 0;

    public void Special(GameObject who)
    {
        if (i++ == 0)
        {
            doorAudio.Play();
            door.SetLock(true);
        }
        else
            StartCoroutine(WaitForLoopToEndThenPlay());
    }

    IEnumerator WaitForLoopToEndThenPlay()
    {
        loopLab.loop = false;

        yield return new WaitWhile(() => loopLab.isPlaying);

        loopSong.Play();
    }
}
