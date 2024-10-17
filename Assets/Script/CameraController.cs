using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject MainCamera;
    public GameObject Camera2;
    public List<Collider> collidersToEnable = new();
    public List<Collider> collidersToDisable = new();
    public AudioReverbFilter audioFilter;

    private Vector3 initialPosition;
    private Quaternion initialRotation;

    void Start()
    {
        initialPosition = MainCamera.transform.position;
        initialRotation = MainCamera.transform.rotation;

        foreach (Collider col in collidersToEnable)
            col.enabled = false;
        foreach (Collider col in collidersToDisable)
            col.enabled = true;
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            MainCamera.transform.position = Camera2.transform.position;
            MainCamera.transform.rotation = Camera2.transform.rotation;

            foreach (Collider col in collidersToEnable)
                col.enabled = true;
            foreach (Collider col in collidersToDisable)
                col.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerController>().CloseInteractionWheel();

            if(audioFilter != null)
                audioFilter.enabled = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            MainCamera.transform.position = initialPosition;
            MainCamera.transform.rotation = initialRotation;
            collision.gameObject.GetComponent<PlayerController>().CloseInteractionWheel();

            foreach (Collider col in collidersToEnable)
                col.enabled = false;
            foreach (Collider col in collidersToDisable)
                col.enabled = true;

            if(audioFilter != null)
                audioFilter.enabled = false;
        }
    }
}
