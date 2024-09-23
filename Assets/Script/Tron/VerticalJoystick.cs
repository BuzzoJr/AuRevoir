using UnityEngine;

public class VerticalJoystick : MonoBehaviour
{
    public Transform joystick;  // Reference to the joystick object (the one to be rotated)
    public float maxRotationAngle = 30f;  // Maximum rotation angle the joystick can move
    public float activationAngle = 15f;  // Maximum rotation angle the joystick can move
    public float rotationSpeed = 30f;  // Sensitivity of the rotation
    public LayerMask miniGameLayer;  // Layer for the MiniGame
    public PlayerControllerTron player;
    public GameManagerTron gameManagerTron;

    public AudioClip move;
    public AudioClip release;

    private Camera mainCamera;
    private Vector3 initialMousePosition;
    private Quaternion initialRotation;
    private Quaternion currentRotation;
    private float releaseTimer = 0f;
    private float releaseDelay = 0.5f;
    private bool canRotate = false;  // Flag to check if joystick rotation is allowed
    private AudioSource audioSource;

    private Vector3 stickDir = Vector3.zero;

    private void Awake()
    {
        mainCamera = Camera.main;
        audioSource = GetComponent<AudioSource>();
        initialRotation = joystick.rotation;
    }

    private void Update()
    {
        ReturnJoystick();

        if (gameManagerTron.playing)
        {
            HandleJoystickRotation();
        }
        else if (currentRotation != initialRotation && releaseTimer <= 0)
        {
            releaseTimer = releaseDelay;
        }
    }

    private void HandleJoystickRotation()
    {
        // Detect when the mouse is clicked down
        if (Input.GetMouseButtonDown(0))
        {
            // Perform raycast to check if the joystick is hit
            var viewportPos = new Vector2((Input.mousePosition.x * 1920) / Screen.width, (Input.mousePosition.y * 1080) / Screen.height);
            Ray ray = mainCamera.ScreenPointToRay(viewportPos);
            if (Physics.Raycast(ray, out RaycastHit _, Mathf.Infinity, miniGameLayer))
            {
                initialMousePosition = GetMouseWorldPosition();
                ResetJoystick();
                canRotate = true;
            }
        }

        // If allowed and the mouse is being held down, rotate the joystick based on mouse movement
        if (Input.GetMouseButton(0) && canRotate)
        {
            Vector3 currentMousePosition = GetMouseWorldPosition();
            Vector3 mouseDelta = currentMousePosition - initialMousePosition;

            // Calculate the rotation angle based on the X-axis movement of the mouse
            float rotationAmountX = Mathf.Clamp(mouseDelta.x * rotationSpeed, -maxRotationAngle, maxRotationAngle);
            float rotationAmountZ = Mathf.Clamp(mouseDelta.z * rotationSpeed, -maxRotationAngle, maxRotationAngle);

            // Apply rotation based on mouse movement, pivoting from the bottom of the joystick
            joystick.rotation = initialRotation * Quaternion.Euler(rotationAmountZ, 0, rotationAmountX * -1);  // Rotating around X-axis
            currentRotation = joystick.rotation;
            CheckActivation();
        }

        // Reset rotation ability when mouse button is released
        if (Input.GetMouseButtonUp(0))
        {
            canRotate = false;
            releaseTimer = releaseDelay;
        }
    }

    private void ReturnJoystick()
    {
        if (releaseTimer <= 0)
            return;

        releaseTimer -= Time.deltaTime;
        if (releaseTimer < 0)
        {
            joystick.rotation = initialRotation;
            currentRotation = initialRotation;
            return;
        }

        joystick.rotation = Quaternion.Lerp(initialRotation, currentRotation, releaseTimer / releaseDelay);
    }

    private void ResetJoystick()
    {
        releaseTimer = 0;
        stickDir = Vector3.zero;
        joystick.rotation = initialRotation;
        currentRotation = initialRotation;
    }

    // Helper method to get the mouse position in world space
    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePosition = new Vector3((Input.mousePosition.x * 1920) / Screen.width, (Input.mousePosition.y * 1080) / Screen.height, 3f);
        return mainCamera.ScreenToWorldPoint(mousePosition);
    }

    private void CheckActivation()
    {
        float currentRotationHorizontal = joystick.localEulerAngles.z;
        float currentRotationVertical = joystick.localEulerAngles.x;

        // Normalize the angle to be between -180 and 180 degrees
        if (currentRotationHorizontal > 180)
            currentRotationHorizontal -= 360;

        if (currentRotationVertical > 180)
            currentRotationVertical -= 360;

        // Verify stick direction
        if (Mathf.Abs(currentRotationHorizontal) >= Mathf.Abs(currentRotationVertical))
        {
            // Horizontal
            if (currentRotationHorizontal > activationAngle)
            {
                stickDir = Vector3.left;
            }
            else if (currentRotationHorizontal < -activationAngle)
            {
                stickDir = Vector3.right;
            }
            else if (stickDir != Vector3.zero)
            {
                stickDir = Vector3.zero;
                audioSource.PlayOneShot(release);
            }
        }
        else
        {
            // Vertical
            if (currentRotationVertical > activationAngle)
            {
                stickDir = Vector3.forward;
            }
            else if (currentRotationVertical < -activationAngle)
            {
                stickDir = Vector3.back;
            }
            else if (stickDir != Vector3.zero)
            {
                stickDir = Vector3.zero;
                audioSource.PlayOneShot(release);
            }
        }

        if (player.RequestTurn(stickDir))
            audioSource.PlayOneShot(move);
    }
}
