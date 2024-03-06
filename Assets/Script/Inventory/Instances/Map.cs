using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Map : MonoBehaviour
{
    public static Map instance;

    private GameObject mapUI;

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
        mapUI = transform.GetChild(0).gameObject;
    }

    private void Update()
    {
        if (mapUI.activeSelf)
        {
            GameManager.Instance.UpdateGameState(GameManager.GameState.Menu);

            if (Input.GetKeyDown(KeyCode.Tab))
            {
                OpenMap(false);
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
                        switch (result.gameObject.name)
                        {
                            case "Close":
                                OpenMap(false);
                                break;
                            case "Items":
                                Inventory.instance.OpenInventory(true);
                                OpenMap(false);
                                break;
                            case "Documents":
                                Documents.instance.OpenDocuments(true);
                                OpenMap(false);
                                break;
                            case "Notes":
                                Notes.instance.OpenNotes(true);
                                OpenMap(false);
                                break;
                        }
                    }
                }
            }
        }
    }

    public void OpenMap(bool open = true)
    {
        mapUI.SetActive(open);
        if (mapUI.activeSelf)
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

    private void UpdateInfo()
    {

    }

    public void AddNote()
    {

    }


}