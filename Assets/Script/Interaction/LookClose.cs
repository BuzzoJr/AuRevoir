using System.Collections;
using System.Collections.Generic;
using Assets.Script.Interaction;
using UnityEngine;

public class LookClose : MonoBehaviour, ILook
{
    public Transform mainCamera;
    public Transform destinationCamera;

    private Vector3 originalCamPos;
    private Quaternion originalCamRot;
    private bool close = false;


    void Start()
    {
        originalCamPos = mainCamera.position;
        originalCamRot = mainCamera.rotation;
    }
    public void Look(GameObject who)
    {
        StartCoroutine(CloseUp());
    }

    void Update()
    {
        if (close && Input.GetMouseButtonDown(0))
        {
            StartCoroutine(OpenUp());
        }
    }
    IEnumerator CloseUp()
    {
        GameManager.Instance.UpdateGameState(GameManager.GameState.Interacting);
        close = true;
        float elapsedTime = 0f;
        Vector3 originalPosition = mainCamera.position;
        Quaternion originalRotation = mainCamera.rotation;

        while (elapsedTime < 1f)
        {
            mainCamera.position = Vector3.Lerp(originalPosition, destinationCamera.position, elapsedTime / 1f);
            mainCamera.rotation = Quaternion.Slerp(originalRotation, destinationCamera.rotation, elapsedTime / 1f);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the final position and rotation match exactly
        mainCamera.position = destinationCamera.position;
        mainCamera.rotation = destinationCamera.rotation;
    }

    IEnumerator OpenUp()
    {
        close = false;
        float elapsedTime = 0f;
        Vector3 originalPosition = mainCamera.position;
        Quaternion originalRotation = mainCamera.rotation;

        while (elapsedTime < 1f)
        {
            mainCamera.position = Vector3.Lerp(originalPosition, originalCamPos, elapsedTime / 1f);
            mainCamera.rotation = Quaternion.Slerp(originalRotation, originalCamRot, elapsedTime / 1f);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the final position and rotation match exactly
        mainCamera.position = originalCamPos;
        mainCamera.rotation = originalCamRot;

        // Reset the game state to default or whatever is appropriate
        GameManager.Instance.UpdateGameState(GameManager.GameState.Playing);
    }


}
