using Assets.Script;
using Assets.Script.Interaction;
using UnityEngine;

public class UseRadioSpecial : MonoBehaviour, IUseSpecial
{
    public PlayerData playerData;
    public AudioSource radioMusic, radioSfx;
    public GameObject lightOn;

    void Awake()
    {
        if (playerData.HasStep(GameSteps.MafiaRadioOff))
            Stop();
        else
            Play();
    }

    public void UseSpecial(GameObject who)
    {
        if (lightOn.activeSelf)
        {
            Stop();

            if (radioSfx.clip != null)
                radioSfx.Play();

            playerData.AddStep(GameSteps.MafiaRadioOff);
        }
        else
        {
            Play();

            playerData.RemoveStep(GameSteps.MafiaRadioOff);
        }

        GameManager.Instance.UpdateGameState(GameManager.GameState.Playing);
    }

    public void Play()
    {
        lightOn.SetActive(true);
        radioMusic.time = Time.realtimeSinceStartup % radioMusic.clip.length;
        radioMusic.UnPause();
    }

    public void Stop()
    {
        lightOn.SetActive(false);
        radioMusic.Pause();
    }
}
