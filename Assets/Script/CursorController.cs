using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class CursorController : MonoBehaviour
{
    public static CursorController instance;
    [SerializeField] private Texture2D doorCursor;
    [SerializeField] private Texture2D clickCursor;
    public Camera cam;
    public bool inButton = false;
    private string currentCursor = "null";
    private string currentState;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        GameManager.OnGameStateChange += GameManagerOnGameStateChange;
    }

    void OnDestroy()
    {
        GameManager.OnGameStateChange -= GameManagerOnGameStateChange;
    }

    private void GameManagerOnGameStateChange(GameManager.GameState state)
    {
        currentState = state.ToString();
    }
    void Start() 
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        currentState = GameManager.Instance.State.ToString();
    }

    void FixedUpdate()
    {
        if (currentState == "Playing" && cam.gameObject.activeSelf)
        {
            if (inButton)
            {
                if (currentCursor != "clickCursor")
                {
                    Cursor.SetCursor(clickCursor, Vector2.zero, CursorMode.Auto);
                    currentCursor = "clickCursor";
                }
                return;
            }
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
                else if (hitPoint.transform.CompareTag("Interactable") || hitPoint.transform.CompareTag("Character"))
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
        else
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            currentCursor = "null";
        }
    }
}
