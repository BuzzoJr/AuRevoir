using System.Collections.Generic;
using DG.Tweening.Core.Easing;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerControllerTron : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject trailPrefab;
    public GameManagerTron gameManager;
    private GameObject currentTrailSegment;
    private Vector3 lastPosition;
    private Vector3 initialSegmentScale;
    public AIControllerTron ai;
    public bool alive = true;
    public bool wait = false;
    private List<GameObject> trailList = new List<GameObject>();

    void Start()
    {
        lastPosition = transform.position;
        CreateNewTrailSegment();
    }

    void Update()
    {
        if (alive && !wait)
        {
            Debug.Log("Playing");
            HandleMovement();
            ExtendTrail();
        }else if (alive && wait)
        {
;
            if (Input.GetKeyDown(KeyCode.R))
            {
                gameManager.NextLevel();
            }
        }
        else
        {
            Debug.Log("waiting restart");
            if (Input.GetKeyDown(KeyCode.R))
            {
                gameManager.Restart();
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
        trailList.Add(currentTrailSegment.gameObject);
        initialSegmentScale = currentTrailSegment.transform.localScale;

        AlignTrailSegmentWithMovement();
    }

    void AlignTrailSegmentWithMovement()
    {
        // Rotate the trail segment to match the player's current direction
        currentTrailSegment.transform.rotation = transform.rotation;
    }

    void ExtendTrail()
    {
        // Calculate how far the player has moved since the last position
        float distanceMoved = Vector3.Distance(lastPosition, transform.position);

        // Adjust the scale of the current trail segment to extend it
        currentTrailSegment.transform.localScale = new Vector3(
            initialSegmentScale.x,
            initialSegmentScale.y,
            currentTrailSegment.transform.localScale.z + distanceMoved
        );

        // Update the position of the trail segment to keep it attached to the player's previous position
        currentTrailSegment.transform.Translate(Vector3.forward * (moveSpeed/2) * Time.deltaTime);
        // Update last position for the next frame
        lastPosition = transform.position;
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Wall") && collision.gameObject != currentTrailSegment)
        {
            alive = false;
            ai.wait = true;
            gameManager.GameOver();
            Debug.Log("Player morreu!");
        }
    }

    public void Move(float dir)
    {
        transform.Rotate(Vector3.up, dir);
        CreateNewTrailSegment();
    }

    private void OnDestroy()
    {
        foreach(GameObject obj in trailList)
        {
            Destroy(obj);
        }
        trailList.Clear();
    }
}
