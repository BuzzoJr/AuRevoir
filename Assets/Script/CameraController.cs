using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject MainCamera;
    public GameObject Camera2;

    private Vector3 initialPosition;
    private Quaternion initialRotation;

    void Start()
    {
        initialPosition = MainCamera.transform.position;
        initialRotation = MainCamera.transform.rotation;
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            MainCamera.transform.position = Camera2.transform.position;
            MainCamera.transform.rotation = Camera2.transform.rotation;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            MainCamera.transform.position = initialPosition;
            MainCamera.transform.rotation = initialRotation;
        }
    }
}
