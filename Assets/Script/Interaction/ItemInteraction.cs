using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Script.Interaction;
using Assets.Script.Dialog;
using Assets.Script.Locale;
using UnityEditor.Rendering;

public class ItemInteraction : MonoBehaviour, IUseItem
{
    private AudioSource m_AudioSource;
    public bool shouldWalk = false;
    public string targetItem;
    [SerializeField] private AudioClip errorClip;
    [SerializeField] private Animator animator = null;
    [SerializeField] private DoorController door;
    [SerializeField] private Vector3 CustomWalkOffset = Vector3.zero;
    public void UseItem(GameObject who)
    {
        if (targetItem == who.name)
            StartCoroutine(CoroutineExample());
        else
            m_AudioSource.PlayOneShot(errorClip);
    }

    // Start is called before the first frame update

    IEnumerator CoroutineExample()
    {
        GameManager.Instance.UpdateGameState(GameManager.GameState.Interacting);
        if (shouldWalk)
        {
            PlayerController.navMeshAgent.destination = new Vector3(transform.position.x + CustomWalkOffset.x, transform.position.y + CustomWalkOffset.y, transform.position.z + CustomWalkOffset.z);
            yield return null;
            yield return new WaitUntil(() => !PlayerController.anim.GetBool("Walk"));
        }
        m_AudioSource.Play();
        door.locked = false;
        if(animator != null)
            animator.SetBool("OpenApartamentDoor", true);

        GameManager.Instance.UpdateGameState(GameManager.GameState.Playing);
    }
    void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
