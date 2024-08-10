using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class AndarFigurante : MonoBehaviour
{
    NavMeshAgent myNavMeshAgent;
    [Header("Movement by one point")]
    public Transform target;
    [Header("Movement by Waypoint")]
    public bool moveByWaypoint = false;
    private int currentWaypointIndex = -1; // Index of the current waypoint
    public List<Transform> waypoints; // List of waypoints for the path, nothing will happen if = 0

    public float delayToStartWalking;
    private AudioSource walkingSound;
    private bool startedWalking = false;

    void Start()
    {
        myNavMeshAgent = GetComponent<NavMeshAgent>();
        Invoke("StartWalking", delayToStartWalking);
        walkingSound = GetComponent<AudioSource>();


    }

    private void StartWalking()
    {
        startedWalking = true;
        walkingSound.enabled = true;
        if (waypoints != null && waypoints.Count > 0 && moveByWaypoint)
        {
            GoToNextWaypoint();
            Debug.Log("Waypoint");
        }
        else
        {
            myNavMeshAgent.SetDestination(target.position);
        }
    }

    private void Update()
    {
        if (startedWalking)
        {
            if ((int)myNavMeshAgent.destination.x == (int)transform.position.x && (int)myNavMeshAgent.destination.z == (int)transform.position.z)
            {
                Debug.Log("Chegou em um destino");
                if (waypoints != null && waypoints.Count > 0 && moveByWaypoint)
                {
                    GoToNextWaypoint();
                }
            }
        }
    }

    private void GoToNextWaypoint()
    {
        // Loop back to the first waypoint if all are reached
        currentWaypointIndex = (currentWaypointIndex +1) % waypoints.Count;
        Debug.Log(currentWaypointIndex);
        myNavMeshAgent.SetDestination(waypoints[currentWaypointIndex].position);
    }
}