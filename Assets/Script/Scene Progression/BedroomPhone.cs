using Assets.Script;
using UnityEngine;

public class BedroomPhone : MonoBehaviour
{
    public PlayerData playerData;
    public Inspect voicemailScript;
    public Light lightRinging;
    public Light lightVoicemail;

    void Start()
    {
        if (playerData.steps.Contains(GameSteps.PhoneAnswered))
        {
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
        if (!playerData.steps.Contains(GameSteps.PhoneAnswered))
            playerData.steps.Add(GameSteps.PhoneAnswered);

        voicemailScript.enabled = true;
        lightRinging.enabled = false;
        lightVoicemail.enabled = true;
    }
}
