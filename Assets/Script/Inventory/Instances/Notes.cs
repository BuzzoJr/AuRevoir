using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Notes : MonoBehaviour
{
    public static Notes instance;
    // public List<Notes> notes = new List<Notes>();
    [Header("Clickable Item List")]
    private List<GameObject> notesNavigation = new List<GameObject>();
    [SerializeField] private GameObject notesNavigationParent;
    [SerializeField] private GameObject notesNavigationPrefab;

    private GameObject notesUI;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        notesUI = transform.GetChild(0).gameObject;
    }

    private void Update()
    {
        if (notesUI.activeSelf)
        {
            GameManager.Instance.UpdateGameState(GameManager.GameState.Menu);

            if (Input.GetKeyDown(KeyCode.Tab))
            {
                OpenNotes(false);
            }

            if (Input.GetMouseButtonDown(0))
            {
                // Use the mouse position directly for the PointerEventData
                PointerEventData pointerData = new PointerEventData(EventSystem.current)
                {
                    position = new Vector2((Input.mousePosition.x * 1920) / Screen.width, (Input.mousePosition.y * 1080) / Screen.height)
                };

                // Raycast using the event system and mouse position
                List<RaycastResult> raycastResults = new List<RaycastResult>();
                EventSystem.current.RaycastAll(pointerData, raycastResults);

                foreach (var result in raycastResults)
                {
                    // Ensure we hit the UI layer
                    if (result.gameObject.layer == LayerMask.NameToLayer("UI"))
                    {
                        if (notesNavigation.Contains(result.gameObject))
                        {
                            UpdateInfo(notesNavigation.IndexOf(result.gameObject));
                            break;
                        }
                        switch (result.gameObject.name)
                        {
                            case "Close":
                                OpenNotes(false);
                                break;
                            case "Items":
                                Inventory.instance.OpenInventory(true);
                                OpenNotes(false);
                                break;
                            case "Documents":
                                Documents.instance.OpenDocuments(true);
                                OpenNotes(false);
                                break;
                        }
                    }
                }
            }
        }
    }

    public void OpenNotes(bool open = true, int index = 0)
    {
        notesUI.SetActive(open);
        if (notesUI.activeSelf)
        {
            GameManager.Instance.UpdateGameState(GameManager.GameState.Menu);
            UpdateInfo();
        }
        else
        {
            StartCoroutine(WaitMouseReleaseToPlay());
        }
    }

    private IEnumerator WaitMouseReleaseToPlay()
    {
        yield return new WaitUntil(() => !Input.GetMouseButton(0));
        GameManager.Instance.UpdateGameState(GameManager.GameState.Playing);
    }

    private void UpdateInfo(int index = 0)
    {

    }

    public void AddNote()
    {

    }


}