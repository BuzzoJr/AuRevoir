using Assets.Script.Interaction;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Camera cam;
    public Transform destination;

    public static NavMeshAgent navMeshAgent;
    private AudioSource audioSource;
    public static Animator anim;
    private GameObject interactionWheel;
    private ITalk talk;
    private IUse use;
    private ILook look;
    private Button useChild;
    private Button lookChild;
    private Button talkChild;
    private GameManager.GameState currentState = GameManager.GameState.Playing;

    public Transform lookAtTarget;
    private float rotationSpeed = 500f;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        audioSource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        GameManager.OnGameStateChange += GameManagerOnGameStateChange;
    }
    void OnDestroy()
    {
        GameManager.OnGameStateChange -= GameManagerOnGameStateChange;
    }

    void Start()
    {
        GameObject canvas = GameObject.Find("Canvas");
        if (canvas != null)
        {
            Transform interactionWheelTransform = canvas.transform.Find("WheelInteraction");
            if (interactionWheelTransform != null)
            {
                interactionWheel = interactionWheelTransform.gameObject;
            }
            else Debug.LogWarning("WheelInteraction not found!");
        }
        else Debug.LogWarning("Canvas not found!");
    }

    private void GameManagerOnGameStateChange(GameManager.GameState state)
    {
        currentState = state;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && cam.gameObject.activeSelf)
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                //Previne o bug the fechar o intereaction sheen mesmo quando clica no bot�o, pq o raycast registra colis�o antes com outra coisa
                return;
            }
            var viewportPos = new Vector2((Input.mousePosition.x * 1920) / Screen.width, (Input.mousePosition.y * 1080) / Screen.height);

            Ray ray = cam.ScreenPointToRay(viewportPos);
            if (currentState == GameManager.GameState.Playing && Physics.Raycast(ray, out RaycastHit hitPoint))
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
                            OpenInteractionWheel(hitPoint.transform.gameObject);
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

            if (lookAtTarget)
            {
                Vector3 lookDirection = lookAtTarget.position - transform.position;
                lookDirection.y = 0f;

                Quaternion targetRotation = Quaternion.LookRotation(lookDirection);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, targetRotation.eulerAngles.y, 0), Time.deltaTime * rotationSpeed);

                if (targetRotation == transform.rotation)
                {
                    lookAtTarget = null;
                }

            }
        }
    }

    public void GoTo(Vector3 dest, Transform LookAtTarget = null)
    {
        lookAtTarget = LookAtTarget;
        destination.position = dest;
        navMeshAgent.destination = dest;
    }

    private void OpenInteractionWheel(GameObject target)
    {
        interactionWheel.transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        interactionWheel.SetActive(true);
        useChild = interactionWheel.transform.Find("Use").GetComponent<Button>();
        lookChild = interactionWheel.transform.Find("Inspect").GetComponent<Button>();
        talkChild = interactionWheel.transform.Find("Talk").GetComponent<Button>();

        use = target.GetComponentsInChildren<IUse>().FirstOrDefault(c => c is not MonoBehaviour m || m.enabled);
        if (use is not null)
        {
            useChild.onClick.RemoveListener(UseEvent);
            useChild.interactable = true;
            useChild.onClick.AddListener(UseEvent);
        }

        look = target.GetComponentsInChildren<ILook>().FirstOrDefault(c => c is not MonoBehaviour m || m.enabled);
        if (look is not null)
        {
            lookChild.onClick.RemoveListener(LookEvent);
            lookChild.interactable = true;
            lookChild.onClick.AddListener(LookEvent);
        }

        talk = target.GetComponentsInChildren<ITalk>().FirstOrDefault(c => c is not MonoBehaviour m || m.enabled);
        if (talk is not null)
        {
            talkChild.onClick.RemoveListener(TalkEvent);
            talkChild.interactable = true;
            talkChild.onClick.AddListener(TalkEvent);
        }
        if (use is null && look is null && talk is null)
            Debug.LogWarning("N�o tem intera��o poss�vel nesse objeto!");
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
        if (interactionWheel.activeSelf)
        {
            useChild.interactable = false;
            lookChild.interactable = false;
            talkChild.interactable = false;
            interactionWheel.SetActive(false);
        }
    }
}
