using UnityEngine;

public class CursorController : MonoBehaviour
{
    [SerializeField] private Texture2D doorCursor;
    [SerializeField] private Texture2D clickCursor;
    public Camera cam;
    private string currentCursor = "null";

    void Start() {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    void FixedUpdate()
    {
        var viewportPos = new Vector2((Input.mousePosition.x * 1920) / Screen.width, (Input.mousePosition.y * 1080) / Screen.height);
        Ray ray = cam.ScreenPointToRay(viewportPos);
        RaycastHit hitPoint;
        if (Physics.Raycast(ray, out hitPoint))
        {
            if (hitPoint.transform.CompareTag("Door"))
            {
                if (currentCursor != "doorCursor")
                {
                    Cursor.SetCursor(doorCursor, Vector2.zero, CursorMode.Auto);
                    currentCursor = "doorCursor";
                }
            }
            else if (hitPoint.transform.CompareTag("Interactable"))
            {
                if (currentCursor != "clickCursor")
                {
                    Cursor.SetCursor(clickCursor, Vector2.zero, CursorMode.Auto);
                    currentCursor = "clickCursor";
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
