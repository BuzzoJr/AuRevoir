using System.Collections;
using System.Collections.Generic;
using Assets.Script.Interaction;
using NavKeypad;
using UnityEngine;

public class ZoomIntoPuzzle : MonoBehaviour, IUse
{
    public bool shouldWalk = false;
    public Transform mainCamera;
    public Transform destinationCamera;
    public bool goBackToPlaying = true;
    public Collider exitCollider;
    public float transitionDuration = 2f;

    public List<Collider> collidersToEnable = new();
    public List<Collider> collidersToDisable = new();

    public List<GameObject> objectsToEnable = new();
    public List<GameObject> objectsToDisable = new();

    private Vector3 originalCamPos;
    private Quaternion originalCamRot;
    private bool close = false;
    [SerializeField] private Vector3 CustomWalkOffset = Vector3.zero;

    void Start()
    {
        originalCamPos = mainCamera.position;
        originalCamRot = mainCamera.rotation;
    }

    public void Use(GameObject who)
    {
        StartCoroutine(CloseUp());
    }

    public void ExitPuzzle()
    {
        StartCoroutine(OpenUp());
    }

    void Update()
    {
        if (close && Input.GetMouseButtonDown(0))
        {
            var viewportPos = new Vector2((Input.mousePosition.x * 1920) / Screen.width, (Input.mousePosition.y * 1080) / Screen.height);
            Ray ray = Camera.main.ScreenPointToRay(viewportPos);
            if (Physics.Raycast(ray, out var hit))
            {
                if (hit.collider == exitCollider)
                {
                    StartCoroutine(OpenUp());
                }
            }

        }
    }

    IEnumerator CloseUp()
    {
        GameManager.Instance.UpdateGameState(GameManager.GameState.Interacting);

        if (shouldWalk)
        {
            var g = new GoTo();
            yield return StartCoroutine(g.GoToRoutine(new Vector3(transform.position.x + CustomWalkOffset.x, transform.position.y + CustomWalkOffset.y, transform.position.z + CustomWalkOffset.z), this.transform));

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

        foreach (Collider col in collidersToEnable)
            col.enabled = true;
        foreach (Collider col in collidersToDisable)
            col.enabled = false;

        foreach (GameObject obj in objectsToEnable)
            obj.SetActive(true);
        foreach (GameObject obj in objectsToDisable)
            obj.SetActive(false);

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

        foreach (Collider col in collidersToEnable)
            col.enabled = false;
        foreach (Collider col in collidersToDisable)
            col.enabled = true;

        foreach (GameObject obj in objectsToEnable)
            obj.SetActive(false);
        foreach (GameObject obj in objectsToDisable)
            obj.SetActive(true);

        // Ensure the final position and rotation match exactly
        mainCamera.position = originalCamPos;
        mainCamera.rotation = originalCamRot;

        // Reset the game state to default or whatever is appropriate
        if(goBackToPlaying)
            GameManager.Instance.UpdateGameState(GameManager.GameState.Playing);
    }

    private void runSpecial()
    {
        var special = GetComponent<IUseSpecial>();
        if (special != null)
            special.UseSpecial(gameObject);
    }
}
