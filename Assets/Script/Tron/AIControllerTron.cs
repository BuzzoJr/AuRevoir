using System.Collections.Generic;
using DG.Tweening.Core.Easing;
using UnityEngine;
using UnityEngine.UIElements;

public class AIControllerTron : MonoBehaviour
{
    public Transform player;
    public GameManagerTron gameManager;
    public float moveSpeed = 5f;
    public float decisionTime = 1f; // Time between decisions
    public float raycastDistance = 5f;  // Distance for raycasting to detect walls
    public GameObject trailPrefab;

    private GameObject currentTrailSegment;
    private Vector3 lastPosition;
    private Vector3 initialSegmentScale;
    private float timer;
    private PlayerControllerTron playerController;
    public bool alive = true;
    public bool wait = false;

    private enum Direction { Forward, Left, Right, None }
    private Direction currentDirection = Direction.Forward;
    private List<GameObject> trailList = new List<GameObject>();

    void Start()
    {
        lastPosition = transform.position;
        CreateNewTrailSegment();
        timer = decisionTime;
    }

    void Update()
    {
        if (alive && !wait)
        {
            HandleMovement();
            ExtendTrail();
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                DecideNextMove();
                timer = decisionTime;
            }
        }
    }

    void HandleMovement()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    void CreateNewTrailSegment()
    {
        // Instantiate a new trail segment at the current position
        currentTrailSegment = Instantiate(trailPrefab, lastPosition, transform.rotation);
        initialSegmentScale = currentTrailSegment.transform.localScale;
        trailList.Add(currentTrailSegment.gameObject);

        // Align the trail segment with the AI's current direction
        AlignTrailSegmentWithMovement();
    }

    void AlignTrailSegmentWithMovement()
    {
        // Rotate the trail segment to match the AI's current direction
        currentTrailSegment.transform.rotation = transform.rotation;
    }

    void ExtendTrail()
    {
        // Calculate how far the AI has moved since the last position
        float distanceMoved = Vector3.Distance(lastPosition, transform.position);

        // Adjust the scale of the current trail segment to extend it
        currentTrailSegment.transform.localScale = new Vector3(
            initialSegmentScale.x,
            initialSegmentScale.y,
            currentTrailSegment.transform.localScale.z + distanceMoved
        );

        // Update the position of the trail segment to keep it attached to the AI's previous position
        currentTrailSegment.transform.Translate(Vector3.forward * (moveSpeed / 2) * Time.deltaTime);

        // Update last position for the next frame
        lastPosition = transform.position;
    }

    void DecideNextMove()
    {
        // Try to predict and intercept the player's path
        Vector3 directionToPlayer = player.position - transform.position;
        float angleToPlayer = Vector3.Angle(transform.forward, directionToPlayer);

        if (angleToPlayer < 30f && !IsNearWall(Direction.Forward))
        {
            // Continue forward if aligned with player and path is clear
            currentDirection = Direction.Forward;
        }
        else
        {
            // Determine the best turn direction
            if (!IsNearWall(Direction.Left))
            {
                currentDirection = Direction.Left;
                transform.Rotate(Vector3.up, -90f);
                CreateNewTrailSegment();
            }
            else if (!IsNearWall(Direction.Right))
            {
                currentDirection = Direction.Right;
                transform.Rotate(Vector3.up, 90f);
                CreateNewTrailSegment();
            }
            else
            {
                // If no turn is possible, just go forward
                currentDirection = Direction.Forward;
            }
        }
    }

    bool IsNearWall(Direction direction)
    {
        Vector3 rayDirection = transform.forward;

        if (direction == Direction.Left)
        {
            rayDirection = -transform.right;
        }
        else if (direction == Direction.Right)
        {
            rayDirection = transform.right;
        }

        RaycastHit hit;
        if (Physics.Raycast(transform.position, rayDirection, out hit, raycastDistance))
        {
            if (hit.collider.CompareTag("Wall"))
            {
                return true;
            }
        }

        return false;
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Wall") && collision.gameObject != currentTrailSegment)
        {
            FindObjectOfType<GameManagerTron>().AddPointsForKillingAI();
            alive = false;
            player.GetComponent<PlayerControllerTron>().wait = true;
            gameManager.LeveWin();
            Debug.Log("IA morreu!");
        }
    }

    private void OnDestroy()
    {
        foreach (GameObject obj in trailList)
        {
            Destroy(obj);
        }
        trailList.Clear();
    }
}
