using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEditor.PlayerSettings;

public class PlayerController : MonoBehaviour
{
    public Camera cam;
    public Transform destination;
    private NavMeshAgent navMeshAgent;
    private Rigidbody rb;
    private AudioSource audioSource;
    private Animator anim;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
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
            var viewportPos = new Vector2((Input.mousePosition.x * 1920 )/ Screen.width, (Input.mousePosition.y * 1080) / Screen.height);

            Ray ray = cam.ScreenPointToRay(viewportPos);
            RaycastHit hitPoint;
            if(Physics.Raycast(ray, out hitPoint)) 
            {
                if(hitPoint.transform.CompareTag("Floor") )
                {
                    destination.position = hitPoint.point;
                    navMeshAgent.destination = hitPoint.point;
                }
                else if (hitPoint.transform.CompareTag("Door"))
                {
                    destination.position = hitPoint.transform.GetChild(0).transform.position;
                    navMeshAgent.destination = hitPoint.transform.GetChild(0).transform.position;
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
}
