using Assets.Script;
using Assets.Script.Interaction;
using UnityEngine;

public class PhoneSpecial : MonoBehaviour, ISpecial
{
    public PlayerData playerData;
    private AudioSource audioSource;
    [SerializeField] private AudioClip pickupPhone;
    public AudioClip IntroductionSong;
    public Inspect voicemailScript;
    public Light lightRinging;
    public Light lightVoicemail;

    void Awake()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    private void Start()
    {
        if (playerData.Steps.Contains(GameSteps.PhoneAnswered))
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

        audioSource.enabled = true;
    }

    public void Special(GameObject who)
    {
        audioSource.Stop();
        audioSource.loop = false;
        audioSource.PlayOneShot(pickupPhone);
        GameManager.Instance.UpdateSong(IntroductionSong);
        playerData.Steps.Add(GameSteps.PhoneAnswered);
        voicemailScript.enabled = true;
        lightRinging.enabled = false;
        lightVoicemail.enabled = true;
    }
}
