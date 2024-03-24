using Assets.Script;
using Assets.Script.Interaction;
using UnityEngine;

public class PhoneSpecial : MonoBehaviour, ISpecial
{
    public PlayerData playerData;
    private AudioSource audioSource;
    [SerializeField] private AudioClip pickupPhone;
    public AudioClip IntroductionSong;

    void Awake()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    private void Start()
    {
        audioSource.enabled = true;
    }

    public void Special(GameObject who)
    {
        audioSource.Stop();
        audioSource.loop = false;
        audioSource.PlayOneShot(pickupPhone);
        GameManager.Instance.UpdateSong(IntroductionSong);
        playerData.Steps.Add(GameSteps.PhoneAnswered);
    }
}
