using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerTron : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject trailPrefab;
    public GameManagerTron gameManager;
    private GameObject currentTrailSegment;
    public AIControllerTron ai;
    public bool alive = true;
    public bool wait = false;
    private List<GameObject> trailList = new List<GameObject>();

    private Vector3 positionInitial;
    private Vector3 positionTurn;
    private Vector3 direction = Vector3.forward;
    private Vector3 directionTarget = Vector3.forward;
    private Vector3 scaleTrail;

    private float cellSize = 1f;

    void Start()
    {
        positionInitial = transform.position;
        positionTurn = transform.position;
        scaleTrail = trailPrefab.transform.localScale;
        CreateNewTrailSegment();
    }

    void CreateNewTrailSegment()
    {
        // Instantiate a new trail segment at the current position
        currentTrailSegment = Instantiate(trailPrefab, transform.position, transform.rotation);
        trailList.Add(currentTrailSegment.gameObject);
    }

    void Update()
    {
        if (alive && !wait)
            return;

        if (alive && wait)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                gameManager.NextLevel();
            }

            return;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            gameManager.Restart();
        }
    }

    void FixedUpdate()
    {
        if (!alive || wait)
            return;

        HandleMovement();
    }

    void HandleMovement()
    {
        float move = moveSpeed / 60f;

        // Should Turn
        if (direction != directionTarget)
        {
            Vector3 position = transform.position - positionInitial;
            Vector3 currentCell = new Vector3(Mathf.Floor(position.x / cellSize), Mathf.Floor(position.y / cellSize), Mathf.Floor(position.z / cellSize)) * cellSize;
            Vector3 nextCell = currentCell + (direction * cellSize);

            // Check player will change cell on the next move
            float moveToNextCell = Vector3.Distance(nextCell, position);
            if (moveToNextCell > cellSize)
                moveToNextCell -= cellSize;

            if (move >= moveToNextCell)
            {
                transform.Translate(direction * moveToNextCell);
                ExtendTrail();
                move -= moveToNextCell;

                // Apply Turn
                direction = directionTarget;
                CreateNewTrailSegment();
                positionTurn = transform.position;
            }
        }

        if (move > 0f)
        {
            transform.Translate(direction * move);
            ExtendTrail();
        }
    }

    void ExtendTrail()
    {
        // Adjust the scale of the current trail segment to extend it
        Vector3 scale = transform.position - positionTurn;
        currentTrailSegment.transform.localScale = new Vector3(Mathf.Max(Mathf.Abs(scale.x) + (Mathf.Abs(direction.x) * scaleTrail.x), scaleTrail.x),
                                                               Mathf.Max(Mathf.Abs(scale.y) + (Mathf.Abs(direction.y) * scaleTrail.y), scaleTrail.y),
                                                               Mathf.Max(Mathf.Abs(scale.z) + (Mathf.Abs(direction.z) * scaleTrail.z), scaleTrail.z));

        // Update the position of the trail segment to keep it attached to the player's previous position
        currentTrailSegment.transform.position = (positionTurn + transform.position) / 2;
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Wall") && collision.gameObject != currentTrailSegment)
        {
            alive = false;
            ai.wait = true;
            gameManager.GameOver();
        }
    }

    public bool RequestTurn(Vector3 dir)
    {
        if (dir == directionTarget)
            return false;

        if (direction == Vector3.forward || direction == Vector3.back)
        {
            if (dir == Vector3.right || dir == Vector3.left)
            {
                directionTarget = dir;
                return true;
            }

            return false;
        }

        if (dir == Vector3.forward || dir == Vector3.back)
        {
            directionTarget = dir;
            return true;
        }

        return false;
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
