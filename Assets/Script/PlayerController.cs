using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public Camera cam;
    public Transform destination;
    private NavMeshAgent navMeshAgent;
    private Rigidbody rb;
    private AudioSource audioSource;
    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitPoint;
            if(Physics.Raycast(ray, out hitPoint)) 
            {
                destination.position = hitPoint.point;
                navMeshAgent.destination = hitPoint.point;


            }
        }

        if ((int)navMeshAgent.destination.x != (int)transform.position.x || (int)navMeshAgent.destination.z != (int)transform.position.z)
        {
            audioSource.enabled = true;
        }
        else
        {
            audioSource.enabled = false;
        }
    }
}
