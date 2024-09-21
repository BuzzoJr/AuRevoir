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
    private bool canRotate = false;  // Flag to check if joystick rotation is allowed
    private AudioSource audioSource;

    private Direction stickDir = Direction.Center;
    private Direction playerDir = Direction.Up;

    private enum Direction
    {
        Center,
        Up,
        Down,
        Left,
        Right,
    }

    private void Awake()
    {
        mainCamera = Camera.main;
        audioSource = GetComponent<AudioSource>();
        initialRotation = joystick.rotation;
    }

    private void Update()
    {
        if (gameManagerTron.playing)
        {
            HandleJoystickRotation();
        }
        else
        {
            playerDir = Direction.Up;
            ResetJoystick();
        }
    }

    private void ResetJoystick()
    {
        stickDir = Direction.Center;
        joystick.rotation = initialRotation;
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
            CheckActivation();
        }

        // Reset rotation ability when mouse button is released
        if (Input.GetMouseButtonUp(0))
        {
            canRotate = false;
            ResetJoystick();
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
                stickDir = Direction.Left;
            }
            else if (currentRotationHorizontal < -activationAngle)
            {
                stickDir = Direction.Right;
            }
            else if (stickDir != Direction.Center)
            {
                stickDir = Direction.Center;
                audioSource.PlayOneShot(release);
            }
        }
        else
        {
            // Vertical
            if (currentRotationVertical > activationAngle)
            {
                stickDir = Direction.Up;
            }
            else if (currentRotationVertical < -activationAngle)
            {
                stickDir = Direction.Down;
            }
            else if (stickDir != Direction.Center)
            {
                stickDir = Direction.Center;
                audioSource.PlayOneShot(release);
            }
        }

        // Apply turn if available
        if (stickDir != Direction.Center && playerDir != stickDir && DirectionIsHorizontal(playerDir) != DirectionIsHorizontal(stickDir))
        {
            TurnPlayer(stickDir);
        }
    }

    private bool DirectionIsHorizontal(Direction dir)
    {
        return dir == Direction.Right || dir == Direction.Left;
    }

    private void TurnPlayer(Direction direction)
    {
        switch (playerDir)
        {
            case Direction.Up:
                if (direction == Direction.Right)
                    player.Move(90);
                else
                    player.Move(-90);
                break;

            case Direction.Down:
                if (direction == Direction.Right)
                    player.Move(-90);
                else
                    player.Move(90);
                break;

            case Direction.Right:
                if (direction == Direction.Down)
                    player.Move(90);
                else
                    player.Move(-90);
                break;

            case Direction.Left:
                if (direction == Direction.Down)
                    player.Move(-90);
                else
                    player.Move(90);
                break;
        }

        playerDir = direction;

        audioSource.PlayOneShot(move);
    }
}
