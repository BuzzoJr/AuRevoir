using Assets.Script.Interaction;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PhoneSpecial : MonoBehaviour, ISpecial
{
    private AudioSource audioSource;
    [SerializeField] private AudioClip pickupPhone;
    public AudioClip IntroductionSong;

    //DEMO ONLY
    public bool DEMO = false;
    public GameObject allCanvas;
    public RectTransform dialog;

    void Awake()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    private void Start()
    {
        audioSource.enabled = true;

        if(DEMO)
            dialog.localScale = Vector3.zero;
    }

    public void Special(GameObject who)
    {
        audioSource.Stop();
        audioSource.loop = false;
        audioSource.PlayOneShot(pickupPhone);

        if(DEMO) {  //FIM DA DEMO
            allCanvas.SetActive(true);
        }
        else {
            GameManager.Instance.UpdateSong(IntroductionSong);
            GetComponent<BedroomPhone>().PhoneAnswered();
        }
    }

    public void GoToMenu() {
        SceneManager.LoadScene(0);
    }
}
