using Assets.Script.Interaction;
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
                        OpenInteractionWheel(hitPoint.transform.gameObject);
                        GoTo(hitPoint.transform.position);
                        break;

                    case "Interactable":
                    case "Object":
                        OpenInteractionWheel(hitPoint.transform.gameObject);
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

    private void OpenInteractionWheel(GameObject target)
    {
        Debug.Log("Vamos mostrar a roda de interações?");

        IUse use = target.GetComponentInChildren<IUse>();
        if (use is not null)
            use.Use(gameObject);

        ILook look = target.GetComponentInChildren<ILook>();
        if (look is not null)
            Debug.Log("- Mostrar a opção de Olhar");

        ITalk talk = target.GetComponentInChildren<ITalk>();
        if (talk is not null)
            talk.Talk(gameObject);

        if (use is null && look is null && talk is null)
            Debug.LogError("Não tem interação possível nesse objeto!");
    }
}
