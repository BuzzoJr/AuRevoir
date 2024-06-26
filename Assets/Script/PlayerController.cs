using Assets.Script.Interaction;
using System.Collections.Generic;
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
    private Transform lastTarget;

    private GameManager.GameState currentState = GameManager.GameState.Playing;

    private float lastClickTime = 0f;
    private float doubleClickThreshold = 0.25f;
    public float originalWalkPitch = 1.08f;
    public float originalRunningPitch = 1.25f;
    private bool running = false;

    [System.NonSerialized] public bool canRun = true;
    [System.NonSerialized] public Transform lookAtTarget;

    [Header("Movement by Waypoint")]
    public bool moveByWaypoint = false;
    private int currentWaypointIndex = 0; // Index of the current waypoint
    public List<Transform> waypoints; // List of waypoints for the path, nothing will happen if = 0

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

        // Set the initial destination to the first waypoint if available
        if (waypoints != null && waypoints.Count > 0 && moveByWaypoint)
        {
            GoToNextWaypoint();
        }
    }

    private void GameManagerOnGameStateChange(GameManager.GameState state)
    {
        currentState = state;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && cam.gameObject.activeSelf)
        {
            if (GameManager.Instance.State == GameManager.GameState.Walking)
            {
                // Cancel walking to interaction
                GameManager.Instance.UpdateGameState(GameManager.GameState.Playing);
                GoTo(transform.position);
                anim.SetBool("Walk", false);
                anim.SetBool("Run", false);
            }
            else
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
                    lastTarget = hitPoint.transform;
                    //Debug.Log(lastTarget.gameObject.name);
                    switch (lastTarget.tag)
                    {
                        case "Floor":
                        case "Door":
                            if (!CheckInteractionLimit(lastTarget))
                            {
                                bool isDoubleClick = Time.time - lastClickTime < doubleClickThreshold;
                                lastClickTime = Time.time;

                                if (isDoubleClick && canRun)
                                    running = true;
                                else
                                    running = false;

                                GoTo(lastTarget.tag == "Door" ? lastTarget.GetChild(0).position : hitPoint.point);
                                CloseInteractionWheel();
                            }
                            break;
                        case "Character":
                        case "Interactable":
                        case "Object":
                            if (!interactionWheel.activeSelf)
                                OpenInteractionWheel(lastTarget.gameObject);
                            else
                                CloseInteractionWheel();
                            break;
                    }
                }
            }

        }

        if ((int)navMeshAgent.destination.x != (int)transform.position.x || (int)navMeshAgent.destination.z != (int)transform.position.z)
        {
            audioSource.enabled = true;
            if (!running)
            {
                navMeshAgent.speed = 5;
                audioSource.pitch = originalWalkPitch;
                anim.SetBool("Walk", true);
                anim.SetBool("Run", false);
            }
            else
            {
                audioSource.pitch = originalRunningPitch;
                navMeshAgent.speed = Mathf.Lerp(navMeshAgent.speed, 10f, Time.deltaTime * 8f);
                anim.SetBool("Run", true);
                anim.SetBool("Walk", false);
            }

            if (navMeshAgent.velocity.sqrMagnitude > Mathf.Epsilon)
            {
                Vector3 direction = navMeshAgent.velocity.normalized;
                Quaternion lookRotation = Quaternion.LookRotation(direction);
                lookRotation.x = 0;
                lookRotation.z = 0;
                navMeshAgent.transform.rotation = Quaternion.Lerp(navMeshAgent.transform.rotation, lookRotation, Time.deltaTime * 5f);
            }
        }
        else
        {
            audioSource.enabled = false;
            anim.SetBool("Walk", false);
            anim.SetBool("Run", false);
            navMeshAgent.speed = 5;
            running = false;

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

            // Check if we reached the current waypoint and go to the next
            if (waypoints != null && waypoints.Count > 0 && moveByWaypoint)
            {
                GoToNextWaypoint();
            }
        }
    }

    private bool CheckInteractionLimit(Transform target)
    {
        // Limitar interação
        foreach (ILimit limiter in target.GetComponentsInChildren<ILimit>())
        {
            if (limiter.ShouldLimit(gameObject))
            {
                limiter.Limited(gameObject);
                return true;
            }
        }

        return false;
    }

    private void GoToNextWaypoint()
    {
        if (waypoints == null || waypoints.Count == 0)
            return;

        // Loop back to the first waypoint if all are reached
        currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Count;
        GoTo(waypoints[currentWaypointIndex].position);
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
        if (lastTarget && !CheckInteractionLimit(lastTarget))
            talk.Talk(gameObject);

        CloseInteractionWheel();
    }

    void LookEvent()
    {
        if (lastTarget && !CheckInteractionLimit(lastTarget))
            look.Look(gameObject);

        CloseInteractionWheel();
    }

    void UseEvent()
    {
        if (lastTarget && !CheckInteractionLimit(lastTarget))
            use.Use(gameObject);

        CloseInteractionWheel();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (moveByWaypoint)
            GoToNextWaypoint();
    }

    public void CloseInteractionWheel()
    {
        if (interactionWheel.activeSelf)
        {
            useChild.interactable = false;
            lookChild.interactable = false;
            talkChild.interactable = false;
            interactionWheel.SetActive(false);
        }
        lastTarget = null;
    }
}
