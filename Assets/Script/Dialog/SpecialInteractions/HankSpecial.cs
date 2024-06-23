using Assets.Script;
using Assets.Script.Interaction;
using UnityEngine;

public class HankSpecial : MonoBehaviour, ISpecial
{
    public PlayerData playerData;
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
            playerData.steps.Add(GameSteps.GetFirstMission);
        }
    }
}
