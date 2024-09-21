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

    private enum CursorTypes
    {
        None,
        Door,
        Click,
    }
    private CursorTypes current;
    private Dictionary<CursorTypes, Texture2D> textures = new();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        current = CursorTypes.None;
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);

        textures.Add(CursorTypes.Door, doorCursor);
        textures.Add(CursorTypes.Click, clickCursor);
    }

    void FixedUpdate()
    {
        if (inCutscene && GameManager.Instance.State == GameManager.GameState.Interacting)
        {
            Cursor.visible = false;
            return;
        }

        Cursor.visible = true;

        if (GameManager.Instance.State != GameManager.GameState.Playing || !cam.gameObject.activeSelf)
        {
            CursorUI();
            return;
        }

        if (IsCursorOverInventoryBag())
        {
            SetCursor(CursorTypes.Click);
            return;
        }

        var viewportPos = new Vector2((Input.mousePosition.x * 1920) / Screen.width, (Input.mousePosition.y * 1080) / Screen.height);
        Ray ray = cam.ScreenPointToRay(viewportPos);
        RaycastHit hitPoint;
        if (!Physics.Raycast(ray, out hitPoint))
        {
            SetCursor(CursorTypes.None);
            return;
        }

        if (hitPoint.transform.CompareTag("Door"))
            SetCursor(CursorTypes.Door);
        else if (hitPoint.transform.CompareTag("Interactable") || hitPoint.transform.CompareTag("Character"))
            SetCursor(CursorTypes.Click);
        else
            SetCursor(CursorTypes.None);
    }

    private bool IsCursorOverInventoryBag()
    {
        PointerEventData pointerData = new PointerEventData(EventSystem.current)
        {
            position = new Vector2((Input.mousePosition.x * 1920) / Screen.width, (Input.mousePosition.y * 1080) / Screen.height)
        };

        List<RaycastResult> raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, raycastResults);

        foreach (var result in raycastResults)
        {
            // Ensure we hit the UI layer
            if (result.gameObject.layer == LayerMask.NameToLayer("UI") && result.gameObject.TryGetComponent(out Button _))
                return true;
        }

        return false;
    }

    private void CursorUI()
    {
        PointerEventData pointerData = new PointerEventData(EventSystem.current)
        {
            position = new Vector2((Input.mousePosition.x * 1920) / Screen.width, (Input.mousePosition.y * 1080) / Screen.height)
        };

        List<RaycastResult> raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, raycastResults);

        List<string> buttonNames = new List<string> { "UseItem", "Close", "Items", "Documents", "Notes", "ItemList", "DocumentList" };

        foreach (var result in raycastResults)
        {
            // Ensure we hit the UI layer
            if (result.gameObject.layer == LayerMask.NameToLayer("UI"))
            {
                if (buttonNames.Contains(result.gameObject.name))
                {
                    SetCursor(CursorTypes.Click);
                    return;
                }
            }
        }

        SetCursor(CursorTypes.None);
    }

    private void SetCursor(CursorTypes type)
    {
        if (type == current)
            return;

        current = type;

        if (type == CursorTypes.None)
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            return;
        }

        Cursor.SetCursor(textures[type], Vector2.zero, CursorMode.Auto);
    }
}
