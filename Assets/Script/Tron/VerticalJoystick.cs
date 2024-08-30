using UnityEngine;

public class VerticalJoystick : MonoBehaviour
{
    public Transform joystick;  // Reference to the joystick object (the one to be rotated)
    public float maxRotationAngle = 30f;  // Maximum rotation angle the joystick can move
    public float activationAngle = 15f;  // Maximum rotation angle the joystick can move
    public float rotationSpeed = 30f;  // Sensitivity of the rotation
    public LayerMask miniGameLayer;  // Layer for the MiniGame
    public PlayerControllerTron player;

    public AudioClip move;
    public AudioClip release;


    private Camera mainCamera;
    private Vector3 initialMousePosition;
    private Quaternion initialRotation;
    private bool canRotate = false;  // Flag to check if joystick rotation is allowed
    private bool active = false;
    private AudioSource audioSource;

    private void Awake()
    {
        mainCamera = Camera.main;
        audioSource = GetComponent<AudioSource>();  
    }

    private void Update()
    {
        HandleJoystickRotation();
    }

    private void HandleJoystickRotation()
    {
        // Detect when the mouse is clicked down
        if (Input.GetMouseButtonDown(0))
        {
            // Perform raycast to check if the joystick is hit
            var viewportPos = new Vector2((Input.mousePosition.x * 1920) / Screen.width, (Input.mousePosition.y * 1080) / Screen.height);
            Ray ray = mainCamera.ScreenPointToRay(viewportPos);
            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, miniGameLayer))
            {
                initialMousePosition = GetMouseWorldPosition();
                initialRotation = joystick.rotation;
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

            // Apply rotation based on mouse movement, pivoting from the bottom of the joystick
            joystick.rotation = initialRotation * Quaternion.Euler(0, 0, rotationAmountX * -1);  // Rotating around X-axis
            CheckActivation();
        }

        // Reset rotation ability when mouse button is released
        if (Input.GetMouseButtonUp(0))
        {
            canRotate = false;
        }
    }

    // Helper method to get the mouse position in world space
    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePosition = new Vector3((Input.mousePosition.x * 1920) / Screen.width, (Input.mousePosition.y * 1080) / Screen.height, 3f);
        return mainCamera.ScreenToWorldPoint(mousePosition);
    }

    private void CheckActivation()
    {

        float currentRotationAngle = joystick.localEulerAngles.z;

        // Normalize the angle to be between -180 and 180 degrees
        if (currentRotationAngle > 180)
            currentRotationAngle -= 360;


        // Check if the rotation exceeds the activation threshold
        if (currentRotationAngle > activationAngle || currentRotationAngle < -activationAngle)
        {
            if (!active)
            {
                audioSource.PlayOneShot(move);

                if (currentRotationAngle > 0)
                    player.Move(-90); //Left
                else
                    player.Move(90); //Right

                active = true;
            }
        }else if (active)
        {
            audioSource.PlayOneShot(release);
            active = false;
        }
    }
}
