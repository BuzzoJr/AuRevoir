using System.Collections;
using System.Collections.Generic;
using Assets.Script.Interaction;
using UnityEngine;

public class LookClose : MonoBehaviour, ILook
{
    public bool shouldWalk = false;
    public Transform mainCamera;
    public Transform destinationCamera;
    public bool goBackToPlaying = true;

    public float transitionDuration = 2f;

    private Vector3 originalCamPos;
    private Quaternion originalCamRot;
    private bool close = false;
    [SerializeField] private Vector3 CustomWalkOffset = Vector3.zero;

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

        if (shouldWalk)
        {
            var g = new GoTo();
            yield return StartCoroutine(g.GoToRoutine(new Vector3(transform.position.x + CustomWalkOffset.x, transform.position.y + CustomWalkOffset.y, transform.position.z + CustomWalkOffset.z), null));

            // Action cancelled
            if (GameManager.Instance.State != GameManager.GameState.Interacting)
                yield break;
        }

        close = true;
        float elapsedTime = 0f;
        Vector3 originalPosition = mainCamera.position;
        Quaternion originalRotation = mainCamera.rotation;

        while (elapsedTime < transitionDuration)
        {
            mainCamera.position = Vector3.Lerp(originalPosition, destinationCamera.position, elapsedTime / transitionDuration);
            mainCamera.rotation = Quaternion.Slerp(originalRotation, destinationCamera.rotation, elapsedTime / transitionDuration);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the final position and rotation match exactly
        mainCamera.position = destinationCamera.position;
        mainCamera.rotation = destinationCamera.rotation;
        runSpecial();
    }

    IEnumerator OpenUp()
    {
        close = false;
        float elapsedTime = 0f;
        Vector3 originalPosition = mainCamera.position;
        Quaternion originalRotation = mainCamera.rotation;

        while (elapsedTime < transitionDuration)
        {
            mainCamera.position = Vector3.Lerp(originalPosition, originalCamPos, elapsedTime / transitionDuration);
            mainCamera.rotation = Quaternion.Slerp(originalRotation, originalCamRot, elapsedTime / transitionDuration);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the final position and rotation match exactly
        mainCamera.position = originalCamPos;
        mainCamera.rotation = originalCamRot;

        // Reset the game state to default or whatever is appropriate
        if(goBackToPlaying)
            GameManager.Instance.UpdateGameState(GameManager.GameState.Playing);
    }

    private void runSpecial()
    {
        var special = GetComponent<ILookSpecial>();
        if (special != null)
            special.LookSpecial(gameObject);
    }
}
