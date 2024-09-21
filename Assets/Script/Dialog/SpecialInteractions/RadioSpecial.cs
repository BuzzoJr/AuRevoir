using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Script.Interaction;

public class RadioSpecial : MonoBehaviour, IUseSpecial
{
    public AudioSource radioMusic, radioSfx;
    public GameObject lightOn;

    public void UseSpecial(GameObject who)
    {
        if(lightOn.activeSelf) {
            lightOn.SetActive(false);
            radioMusic.Stop();
            radioSfx.Play();
        }
        else {
            lightOn.SetActive(true);
            radioMusic.Play();
        }

        GameManager.Instance.UpdateGameState(GameManager.GameState.Playing);
    }
}
