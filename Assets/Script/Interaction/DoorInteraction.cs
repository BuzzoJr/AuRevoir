using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Script.Interaction;
using Assets.Script.Dialog;
using Assets.Script.Locale;
using UnityEditor.Rendering;

public class DoorInteraction : MonoBehaviour, IUseItem
{
    private AudioSource m_AudioSource;
    public bool shouldWalk = false;
    public string targetItem;
    [SerializeField] private AudioClip errorClip;
    [SerializeField] private Transform targetTransform = null;
    [SerializeField] private Animator animator = null;
    [SerializeField] private DoorController door;
    [SerializeField] private Vector3 CustomWalkOffset = Vector3.zero;

    void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }
    public void UseItem(GameObject who)
    {
        if (targetItem == who.name)
            StartCoroutine(CoroutineExample());
        else
            m_AudioSource.PlayOneShot(errorClip);
    }

    IEnumerator CoroutineExample()
    {
        GameManager.Instance.UpdateGameState(GameManager.GameState.Interacting);
        if (shouldWalk)
        {
            GameObject.FindWithTag("Player").GetComponent<PlayerController>().GoTo(new Vector3(transform.position.x + CustomWalkOffset.x, transform.position.y + CustomWalkOffset.y, transform.position.z + CustomWalkOffset.z), targetTransform);
            yield return null;
            yield return new WaitUntil(() => !PlayerController.anim.GetBool("Walk"));
        }

        m_AudioSource.Play();
        door.locked = false;

        if(animator != null)
            animator.SetBool("OpenDoor", true);

        GameManager.Instance.UpdateGameState(GameManager.GameState.Playing);
    }
}
