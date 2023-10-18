using UnityEngine;

public class CursorController : MonoBehaviour
{
    [SerializeField] private Texture2D moveCursorRight;
    [SerializeField] private Texture2D moveCursorLeft;
    [SerializeField] private Texture2D interactCursor;
    public Camera cam;
    private string currentCursor = "null";

    void Start() {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    void FixedUpdate()
    {
        Vector3 mousePosition = Input.mousePosition;
        Ray ray = cam.ScreenPointToRay(mousePosition);
        RaycastHit hitPoint;
        if (Physics.Raycast(ray, out hitPoint))
        {
            if (hitPoint.transform.CompareTag("Door"))
            {
                if (mousePosition.x < Screen.width / 2)
                {
                    if (currentCursor != "moveCursorLeft")
                    {
                        Cursor.SetCursor(moveCursorLeft, Vector2.zero, CursorMode.Auto);
                        currentCursor = "moveCursorLeft";
                    }
                }
                else if (mousePosition.x >= Screen.width / 2)
                {
                    if (currentCursor != "moveCursorRight")
                    { 
                        Cursor.SetCursor(moveCursorRight, Vector2.zero, CursorMode.Auto);
                        currentCursor = "moveCursorRight";
                    }
                }
            }else if (hitPoint.transform.CompareTag("Interactable"))
            {
                if (currentCursor != "interactCursor")
                {
                    Cursor.SetCursor(interactCursor, Vector2.zero, CursorMode.Auto);
                    currentCursor = "interactCursor";
                }
            }
            else if(currentCursor != "null")
            {
                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                currentCursor = "null";
            }
        }

    }
}
