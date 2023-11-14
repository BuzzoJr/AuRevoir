using Assets.Script.Interaction;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class CutscenePlayer : MonoBehaviour, ILook
{
    public GameObject videocanvas;
    public VideoPlayer videoPlayer;
    public void Look(GameObject who)
    {
        StartCoroutine(PlayVideo());
    }

    private IEnumerator PlayVideo()
    {
        GameManager.Instance.UpdateGameState(GameManager.GameState.Interacting);

        videocanvas.SetActive(true);
        videoPlayer.Prepare();

        while(!videoPlayer.isPrepared)
        {
            yield return null;
        }

        videoPlayer.Play();

        while (videoPlayer.isPlaying)
        {
            yield return null;
        }
        videocanvas.SetActive(false);
        GameManager.Instance.UpdateGameState(GameManager.GameState.Playing);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
