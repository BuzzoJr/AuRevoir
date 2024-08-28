using UnityEngine;

public class AIControllerTron : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 5f;
    public float decisionTime = 1f; // Time between decisions
    public float raycastDistance = 5f;  // Distance for raycasting to detect walls
    public GameObject trailPrefab;

    private Vector3 lastPosition;
    private float timer;

    private enum Direction { Forward, Left, Right, None }
    private Direction currentDirection = Direction.Forward;

    void Start()
    {
        lastPosition = transform.position;
        timer = decisionTime;
    }

    void Update()
    {
        HandleMovement();
        //CreateTrail();
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            DecideNextMove();
            timer = decisionTime;
        }
    }

    void HandleMovement()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    void DecideNextMove()
    {
        // Try to predict and intercept player's path
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
            }
            else if (!IsNearWall(Direction.Right))
            {
                currentDirection = Direction.Right;
                transform.Rotate(Vector3.up, 90f);
            }
            else
            {
                // If no turn is possible, just go forward (or reverse logic to trap player)
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

    void CreateTrail()
    {
        if (Vector3.Distance(lastPosition, transform.position) >= 1f)
        {
            Instantiate(trailPrefab, lastPosition, Quaternion.identity);
            lastPosition = transform.position;
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        Debug.Log(collision);
        if (collision.gameObject.CompareTag("Wall"))
        {
            FindObjectOfType<GameManagerTron>().AddPointsForKillingAI();
            Debug.Log("IA morreu!");
            Time.timeScale = 0f;
        }
    }
}
