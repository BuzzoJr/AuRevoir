using Assets.Script.Dialog;
using Assets.Script.Interaction;
using Assets.Script.Locale;
using System.Collections;
using TMPro;
using UnityEngine;

public class PhoneDialog : MonoBehaviour, ITalk
{
    public bool shouldWalk = true;
    public TextGroup textGroup = TextGroup.DialogWakeUpCall;
    [SerializeField] private GameObject dialogBox;
    private AudioSource audioSource;
    [SerializeField] private AudioClip pickupPhone;

    private Dialog dialog;

    void Awake()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        dialog = gameObject.AddComponent<Dialog>();
        dialog.DialogBox = dialogBox;
        dialog.TextGroup = textGroup;
        dialog.DialogText = dialogBox.GetComponentInChildren<TMP_Text>();
    }

    private void Start()
    {
        audioSource.enabled = true;
    }

    public void Talk(GameObject who)
    {
        StartCoroutine(Execute());
    }

    IEnumerator Execute()
    {
        GameManager.Instance.UpdateGameState(GameManager.GameState.Interacting);
        if (shouldWalk)
        {
            PlayerController.navMeshAgent.destination = transform.position;
            yield return null;
            yield return new WaitUntil(() => !PlayerController.anim.GetBool("Walk"));
        }
        audioSource.Stop();
        audioSource.loop = false;
        audioSource.PlayOneShot(pickupPhone);
        yield return StartCoroutine(dialog.Execute());
        Destroy(this);
    }
}
