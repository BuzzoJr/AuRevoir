using Assets.Script.Interaction;
using System.Collections;
using UnityEngine;

public class DoorInteraction : MonoBehaviour, IUseItem
{
    //Recebe um item para abrir a porta
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

    public bool UseItem(GameObject who)
    {
        if (targetItem == who.name)
        {
            StartCoroutine(CoroutineExample());
            return true;
        }

        m_AudioSource.PlayOneShot(errorClip);
        return false;
    }

    IEnumerator CoroutineExample()
    {
        GameManager.Instance.UpdateGameState(GameManager.GameState.Interacting);
        if (shouldWalk)
        {
            var g = new GoTo();
            yield return StartCoroutine(g.GoToRoutine(new Vector3(transform.position.x + CustomWalkOffset.x, transform.position.y + CustomWalkOffset.y, transform.position.z + CustomWalkOffset.z), targetTransform));

            // Action cancelled
            if (GameManager.Instance.State != GameManager.GameState.Interacting)
                yield break;
        }

        m_AudioSource.Play();
        door.locked = false;

        if (animator != null)
            animator.SetBool("OpenDoor", true);

        GameManager.Instance.UpdateGameState(GameManager.GameState.Playing);
    }
}
