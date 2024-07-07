using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject MainCamera;
    public GameObject Camera2;
    public List<Collider> colliders2 = new();

    private Vector3 initialPosition;
    private Quaternion initialRotation;

    void Start()
    {
        initialPosition = MainCamera.transform.position;
        initialRotation = MainCamera.transform.rotation;

        foreach (Collider col in colliders2)
            col.enabled = false;
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            MainCamera.transform.position = Camera2.transform.position;
            MainCamera.transform.rotation = Camera2.transform.rotation;

            foreach (Collider col in colliders2)
                col.enabled = true;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerController>().CloseInteractionWheel();
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            MainCamera.transform.position = initialPosition;
            MainCamera.transform.rotation = initialRotation;
            collision.gameObject.GetComponent<PlayerController>().CloseInteractionWheel();

            foreach (Collider col in colliders2)
                col.enabled = false;
        }
    }
}
