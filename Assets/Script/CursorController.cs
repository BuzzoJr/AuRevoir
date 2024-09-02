using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CursorController : MonoBehaviour
{
    //Controla qual icone de cursor está sendo utilizado
    public static bool inCutscene = false;
    public static CursorController instance;
    [SerializeField] private Texture2D doorCursor;
    [SerializeField] private Texture2D clickCursor;
    public Camera cam;
    public bool inButton = false;
    private string currentCursor = "null";
    //private GameManager.GameState currentState;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        //GameManager.OnGameStateChange += GameManagerOnGameStateChange;
    }

    //void OnDestroy()
    //{
    //    GameManager.OnGameStateChange -= GameManagerOnGameStateChange;
    //}

    //private void GameManagerOnGameStateChange(GameManager.GameState state)
    //{
    //    currentState = state;
    //}

    void Start()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    void FixedUpdate()
    {
        if (inCutscene && GameManager.Instance.State == GameManager.GameState.Interacting)
        {
            Cursor.visible = false;
            return;
        }
        else
        {
            Cursor.visible = true;
        }

        if (GameManager.Instance.State == GameManager.GameState.Playing && cam.gameObject.activeSelf)
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
                else if (currentCursor != "null")
                {
                    Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                    currentCursor = "null";
                }
            }
        }
        else
        {
            CursorUI();
        }
    }

    private void CursorUI()
    {
        PointerEventData pointerData = new PointerEventData(EventSystem.current)
        {
            position = new Vector2((Input.mousePosition.x * 1920) / Screen.width, (Input.mousePosition.y * 1080) / Screen.height)
        };

        List<RaycastResult> raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, raycastResults);

        List<string> buttonNames = new List<string> { "UseItem", "Close", "Items", "Documents", "Notes", "ItemList" };

        foreach (var result in raycastResults)
        {
            // Ensure we hit the UI layer
            if (result.gameObject.layer == LayerMask.NameToLayer("UI"))
            {
                if (buttonNames.Contains(result.gameObject.name))
                {
                    inButton = true;
                    break;
                }
                else
                {
                    inButton = false;
                }
            }
        }

        if (inButton)
        {
            if (currentCursor != "clickCursor")
            {
                Cursor.SetCursor(clickCursor, Vector2.zero, CursorMode.Auto);
                currentCursor = "clickCursor";
            }
        }
        else
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            currentCursor = "null";
        }
    }
}
