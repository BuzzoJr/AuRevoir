using Assets.Script.Interaction;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.Events;
using static UnityEngine.GraphicsBuffer;

public class PlayerController : MonoBehaviour
{
    public Camera cam;
    public Transform destination;

    public static NavMeshAgent navMeshAgent;
    private AudioSource audioSource;
    public static Animator anim;
    [SerializeField] private GameObject interactionWheel;
    private ITalk talk;
    private IUse use;
    private ILook look;
    private Button useChild;
    private Button lookChild;
    private Button talkChild;


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
                        CloseInteractionWheel();
                        break;

                    case "Door":
                        GoTo(hitPoint.transform.GetChild(0).transform.position);
                        CloseInteractionWheel();
                        break;

                    case "Character":
                    case "Interactable":
                    case "Object":
                        if (!interactionWheel.activeSelf)
                            OpenInteractionWheel(hitPoint.transform.gameObject, viewportPos);
                        else 
                            CloseInteractionWheel();
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

    private void OpenInteractionWheel(GameObject target, Vector2 position)
    {
        interactionWheel.transform.position = position;
        interactionWheel.SetActive(true);
        useChild = interactionWheel.transform.Find("Use").GetComponent<Button>();
        lookChild = interactionWheel.transform.Find("Inspect").GetComponent<Button>();
        talkChild = interactionWheel.transform.Find("Talk").GetComponent<Button>();

        use = target.GetComponentInChildren<IUse>();
        if (use is not null)
        {
            useChild.interactable = true;
            useChild.onClick.AddListener(UseEvent);
        }

        look = target.GetComponentInChildren<ILook>();
        if (look is not null)
        {
            lookChild.interactable = true;
            lookChild.onClick.AddListener(LookEvent);
        }

        talk = target.GetComponentInChildren<ITalk>();
        if (talk is not null)
        {
            talkChild.interactable = true;
            talkChild.onClick.AddListener(TalkEvent);
        }
        if (use is null && look is null && talk is null)
            Debug.LogWarning("Não tem interação possível nesse objeto!");
    }
    
    void TalkEvent()
    {
        talk.Talk(gameObject);
        CloseInteractionWheel();
    }

    void LookEvent()
    {
        look.Look(gameObject);
        CloseInteractionWheel();
    }
    void UseEvent()
    {
        use.Use(gameObject);
        CloseInteractionWheel();
    }

    void CloseInteractionWheel()
    {
        useChild.interactable = false;
        lookChild.interactable = false;
        talkChild.interactable = false;
        interactionWheel.SetActive(false);
    }
}
