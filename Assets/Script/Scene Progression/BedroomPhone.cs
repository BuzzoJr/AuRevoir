using Assets.Script;
using UnityEngine;

public class BedroomPhone : MonoBehaviour
{
    public PlayerData playerData;
    public Inspect voicemailScript;
    public DialogInteraction dialogInteraction;
    public AudioSource audioRinging;
    public Light lightRinging;
    public Light lightVoicemail;

    void Start()
    {
        if (playerData.HasStep(GameSteps.PhoneAnswered))
        {
            if (dialogInteraction != null)
                Destroy(dialogInteraction);
            if (audioRinging != null)
                audioRinging.clip = null;

            voicemailScript.enabled = true;
            lightRinging.enabled = false;
            lightVoicemail.enabled = true;
        }
        else
        {
            voicemailScript.enabled = false;
            lightVoicemail.enabled = false;
            lightRinging.enabled = true;
        }
    }

    public void PhoneAnswered()
    {
        playerData.AddStep(GameSteps.PhoneAnswered);

        voicemailScript.enabled = true;
        lightRinging.enabled = false;
        lightVoicemail.enabled = true;
    }
}
