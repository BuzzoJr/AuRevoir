using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public Camera cam;
    public Transform destination;

    private NavMeshAgent navMeshAgent;
    private AudioSource audioSource;
    private Animator anim;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        audioSource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }

    void Start()
    {
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var viewportPos = new Vector2((Input.mousePosition.x * 1920) / Screen.width, (Input.mousePosition.y * 1080) / Screen.height);

            Ray ray = cam.ScreenPointToRay(viewportPos);
            if (Physics.Raycast(ray, out RaycastHit hitPoint))
            {
                switch (hitPoint.transform.tag)
                {
                    case "Floor":
                        GoTo(hitPoint.point);
                        break;

                    case "Door":
                        GoTo(hitPoint.transform.GetChild(0).transform.position);
                        break;

                    case "Character":
                        GoTo(hitPoint.transform.position);
                        break;

                    case "Interactable":
                    case "Object":
                        OpenInteractionWheel();
                        GoTo(hitPoint.transform.position); // Remove
                        break;
                }
            }
        }

        if ((int)navMeshAgent.destination.x != (int)transform.position.x || (int)navMeshAgent.destination.z != (int)transform.position.z)
        {
            audioSource.enabled = true;
            anim.SetBool("Walk", true);
        }
        else
        {
            audioSource.enabled = false;
            anim.SetBool("Walk", false);
        }
    }

    private void GoTo(Vector3 dest)
    {
        destination.position = dest;
        navMeshAgent.destination = dest;
    }

    private void OpenInteractionWheel()
    {
        Debug.Log("OpenInteractionWheel at " + Input.mousePosition);
        // Input.mousePosition
    }
}
