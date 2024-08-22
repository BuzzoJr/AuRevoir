using Assets.Script;
using Assets.Script.Locale;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Inventory : MonoBehaviour, ILangConsumer
{
    public static Inventory instance;
    public List<Item> items = new List<Item>();
    [Header("Clickable Item List")]
    private List<GameObject> itemNavigation = new List<GameObject>();
    [SerializeField] private GameObject itemNavigationParent;
    [SerializeField] private GameObject itemNavigationPrefab;
    [Header("UI Text")]
    [SerializeField] private TMP_Text ItemName;
    [SerializeField] private TMP_Text ItemDetails;
    [SerializeField] private GameObject useText;
    [Header("Reference Points")]
    [SerializeField] private GameObject ItemDetailsParent;
    [SerializeField] private GameObject inventoryBag;
    [Header("Item Circle")]
    [SerializeField] private Transform itemsParent;
    [SerializeField] private float radius = 20f;
    [SerializeField] private float rotationDuration = 1.0f;

    private AudioSource audioSource;
    private bool isRotating = false;
    private GameObject inventoryUI;
    private int currentItem = 0;
    private TMP_Text interactItem;
    private TMP_Text itemNavigationText;
    private GameManager.GameState currentState = GameManager.GameState.Playing;

    public void UpdateLangTexts()
    {
        ItemName.text = Locale.Texts[TextGroup.Inventory][0].Text;
        ItemDetails.text = Locale.Texts[TextGroup.Inventory][0].Text;

        if (items.Count > 0)
        {
            for (int i = 0; i < items.Count; i++)
            {
                itemNavigation[i].GetComponentInChildren<TMP_Text>().text = Locale.Item[items[i].itemID].Name;
            }

            Item item = items[currentItem];
            ItemData itemData = Locale.Item[item.itemID];

            ItemName.text = itemData.Name;

            if (item.itemMousePrefab != null)
            {
                useText.SetActive(true);
                interactItem.text = Locale.Texts[TextGroup.Inventory][1].Text;
            }
            else if (itemData.Details != null)
            {
                useText.SetActive(true);
                interactItem.text = Locale.Texts[TextGroup.Inventory][2].Text;
                ItemDetails.text = itemData.Details;
            }
            else
            {
                useText.SetActive(false);
            }
        }
    }

    void OnDestroy()
    {
        Locale.UnregisterConsumer(this);
        GameManager.OnGameStateChange -= GameManagerOnGameStateChange;
    }

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

        Locale.RegisterConsumer(this);

        audioSource = GetComponent<AudioSource>();
        inventoryUI = transform.GetChild(0).gameObject;
        UpdateLangTexts();
        interactItem = useText.GetComponentInChildren<TMP_Text>();
        GameManager.OnGameStateChange += GameManagerOnGameStateChange;
    }

    private void GameManagerOnGameStateChange(GameManager.GameState state)
    {
        currentState = state;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (currentState == GameManager.GameState.Playing)
                OpenInventory(true);
            else
                OpenInventory(false);
        }
        if (inventoryUI.activeSelf)
        {
            GameManager.Instance.UpdateGameState(GameManager.GameState.Menu);
            if (Input.GetMouseButtonDown(0))
            {
                if (ItemDetailsParent.activeSelf)
                    ItemDetailsParent.SetActive(false);
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
                        if (itemNavigation.Contains(result.gameObject))
                        {
                            RotateToItem(itemNavigation.IndexOf(result.gameObject));
                            break;
                        }
                        switch (result.gameObject.name)
                        {
                            case "UseItem":
                                Item item = items[currentItem];
                                if (item.itemMousePrefab != null)
                                {
                                    Instantiate(item.itemMousePrefab, Vector3.zero, Quaternion.identity);
                                    inventoryUI.SetActive(false);
                                    GameManager.Instance.UpdateGameState(GameManager.GameState.Interacting);
                                }
                                else if (Locale.Item[item.itemID].Details != null)
                                {
                                    ItemDetailsParent.SetActive(true);
                                }
                                break;
                            case "Close":
                                OpenInventory(false);
                                break;
                            case "Documents":
                                Documents.instance.OpenDocuments(true);
                                OpenInventory(false);
                                break;
                            case "Notes":
                                Notes.instance.OpenNotes(true);
                                OpenInventory(false);
                                break;
                        }
                    }
                }
            }
        }
        inventoryBag.SetActive(CanOpenInventory());
    }

    private bool CanOpenInventory()
    {
        List<string> blockInventoryInScenes = new()
        {
            SceneRef.NewMenu.ToString(),
            SceneRef.AP_BedroomBadDream.ToString(),
            SceneRef.AP_LivingroomBadDream.ToString(),
        };

        return currentState == GameManager.GameState.Playing &&
            !blockInventoryInScenes.Contains(SceneManager.GetActiveScene().name);
    }

    public void OpenInventory(bool open = true, int index = 0)
    {
        if (open && !CanOpenInventory())
            return;

        inventoryUI.SetActive(open);
        GameObject ply = GameObject.FindWithTag("Player");

        if (open)
            ply.GetComponent<PlayerController>().CloseInteractionWheel();

        if (inventoryUI.activeSelf)
        {
            GameManager.Instance.UpdateGameState(GameManager.GameState.Menu);
            if (index != 0)
                currentItem = items.Count - 1;
            ClearItems();
            PopulateCircle(currentItem);
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
        foreach (var navText in itemNavigation)
        {
            itemNavigationText = navText.GetComponentInChildren<TMP_Text>();
            itemNavigationText.color = Color.grey;
        }
        if (items.Count != 0)
        {
            ItemName.text = Locale.Item[items[currentItem].itemID].Name;
            itemNavigationText = itemNavigation[currentItem].GetComponentInChildren<TMP_Text>();
            itemNavigationText.color = Color.white;
            UpdateLangTexts();
        }
    }

    public void AddItem(InventoryObject obj, bool openInventory = true)
    {
        if (obj.type != ItemType.Item)
            return;

        AddItem(new Item(obj.group, obj.prefab, obj.mousePrefab), openInventory);
    }

    public void AddItem(Item item, bool openInventory = true)
    {
        if (items.Any(existingItem => existingItem.itemID == item.itemID))
            return;

        items.Add(item);
        int index = items.Count - 1;
        GameObject newItem = Instantiate(itemNavigationPrefab, itemNavigationParent.transform);
        itemNavigation.Add(newItem);
        itemNavigationText = itemNavigation[index].GetComponentInChildren<TMP_Text>();
        itemNavigationText.text = Locale.Item[item.itemID].Name;

        if (openInventory)
            OpenInventory(true, index);
    }

    public void ChangeItem(int direction)
    {
        currentItem += direction;
        currentItem = (currentItem + items.Count) % items.Count;
        UpdateInfo();
    }

    public void RotateItemsParent(int dir)
    {
        if (items.Count <= 1 || isRotating) return;

        float angleBetweenItems = 360f / items.Count;
        StartCoroutine(SmoothRotation(angleBetweenItems, dir));
    }

    private void ClearItems()
    {
        foreach (Transform child in itemsParent)
        {
            Destroy(child.gameObject);
        }
    }

    private void PopulateCircle(int offset = 0)
    {
        int itemCount = items.Count;
        for (int i = 0; i < itemCount; i++)
        {
            // Calculate the adjusted index with the offset
            int adjustedIndex = (i + offset) % itemCount;

            // Calculate the angle for the current position
            float angle = i * 360f / itemCount;
            Vector3 position = CalculatePosition(angle);

            // Instantiate the prefab at the calculated position
            Instantiate(items[adjustedIndex].itemPrefab, position, Quaternion.identity, itemsParent);
        }
    }

    private Vector3 CalculatePosition(float angle)
    {
        // Convert angle from degrees to radians
        float radian = angle * Mathf.Deg2Rad;

        // Calculate x and z position for a horizontal circle on X-Z plane
        float x = radius * Mathf.Cos(radian);
        float z = radius * Mathf.Sin(radian);

        // Adjust position based on the itemsParent's position
        return new Vector3(x + itemsParent.position.x, itemsParent.position.y, z + itemsParent.position.z);
    }

    private IEnumerator SmoothRotation(float angleItem, int dir)
    {
        float angle = angleItem * dir;
        isRotating = true;
        float elapsedTime = 0;
        Quaternion startingRotation = itemsParent.rotation;
        Quaternion finalRotation = Quaternion.Euler(itemsParent.eulerAngles + new Vector3(0, angle, 0));

        while (elapsedTime < rotationDuration)
        {
            itemsParent.rotation = Quaternion.Slerp(startingRotation, finalRotation, elapsedTime / rotationDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        itemsParent.rotation = finalRotation;
        isRotating = false;
        ChangeItem(dir);
    }

    public void PickUpAudio(AudioClip audio)
    {
        audioSource.PlayOneShot(audio);
    }



    public void RotateToItem(int targetIndex)
    {
        if (targetIndex == -1 || targetIndex == currentItem) return;

        int direction = CalculateRotationDirection(currentItem, targetIndex);
        int distance = CalculateRotationDistance(currentItem, targetIndex, direction);
        RotateItemsParent(distance * direction);
    }


    private int CalculateRotationDirection(int currentIndex, int targetIndex)
    {
        int forwardDistance = (targetIndex - currentIndex + items.Count) % items.Count;
        int backwardDistance = (currentIndex - targetIndex + items.Count) % items.Count;

        return forwardDistance <= backwardDistance ? 1 : -1;
    }

    private int CalculateRotationDistance(int currentIndex, int targetIndex, int direction)
    {
        if (direction > 0)
            return (targetIndex - currentIndex + items.Count) % items.Count;
        else
            return (currentIndex - targetIndex + items.Count) % items.Count;
    }

    public void BagButton()
    {
        OpenInventory(true);
    }
}