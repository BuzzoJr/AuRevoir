using Assets.Script.Locale;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    public List<Item> items = new List<Item>();
    public List<GameObject> itemNavigation = new List<GameObject>();
    [SerializeField] private float radius = 20f;
    [SerializeField] private TMP_Text ItemName;
    [SerializeField] private TMP_Text ItemInfo;
    [SerializeField] private TMP_Text ItemDetails;
    [SerializeField] private GameObject ItemDetailsParent;
    [SerializeField] private Transform itemsParent;
    [SerializeField] private float rotationDuration = 1.0f;
    [SerializeField] private Camera inventoryCam;
    [SerializeField] private GameObject useText;

    private AudioSource audioSource;
    private bool isRotating = false;
    private GameObject inventoryUI;
    private int currentItem = -1;
    private TMP_Text interactItem;
    private TMP_Text itemNavigationText;

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
        audioSource = GetComponent<AudioSource>();
        inventoryUI = transform.GetChild(0).gameObject;
        ItemName.text = Locale.Texts[TextGroup.Inventory][0].Text;
        ItemInfo.text = Locale.Texts[TextGroup.Inventory][0].Text;
        ItemDetails.text = Locale.Texts[TextGroup.Inventory][0].Text;
        interactItem = useText.GetComponentInChildren<TMP_Text>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
            if (inventoryUI.activeSelf)
            {
                GameManager.Instance.UpdateGameState(GameManager.GameState.Menu);
                currentItem = 0;
                ClearItems();
                PopulateCircle();
            }
            else
                GameManager.Instance.UpdateGameState(GameManager.GameState.Playing);

            UpdateInfo();
        }

        if (Input.GetMouseButtonDown(0) && inventoryUI.activeSelf)
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
                    switch (result.gameObject.name)
                    {
                        case "NextItem":
                            RotateItemsParent(1);
                            break;

                        case "PrevioustItem":
                            RotateItemsParent(-1);
                            break;

                        case "UseItem":
                            if (items[currentItem].itemMousePrefab != null)
                            {
                                Instantiate(items[currentItem].itemMousePrefab, Vector3.zero, Quaternion.identity);
                                inventoryUI.SetActive(false);
                                GameManager.Instance.UpdateGameState(GameManager.GameState.Interacting);
                            }
                            else if (items[currentItem].itemDetails != null)
                            {
                                ItemDetailsParent.SetActive(true);
                            }
                            break;
                    }
                }
            }
        }
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
            ItemName.text = items[currentItem].itemName;
            ItemInfo.text = items[currentItem].itemInfo;
            itemNavigationText = itemNavigation[items[currentItem].itemID - 1].GetComponentInChildren<TMP_Text>();
            itemNavigationText.color = Color.white;
            if (items[currentItem].itemMousePrefab != null)
            {
                useText.SetActive(true);
                interactItem.text = Locale.Texts[TextGroup.Inventory][3].Text;
            }
            else if (items[currentItem].itemDetails != null)
            {
                useText.SetActive(true);
                interactItem.text = Locale.Texts[TextGroup.Inventory][4].Text;
                ItemDetails.text = items[currentItem].itemDetails;
            }
            else
            {
                useText.SetActive(false);
            }
        }
    }

    public void AddItem(Item item)
    {
        items.Insert(0, item);
        itemNavigationText = itemNavigation[item.itemID - 1].GetComponentInChildren<TMP_Text>();
        itemNavigationText.text = item.itemName;
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
        StartCoroutine(SmoothRotation(angleBetweenItems * dir));
    }

    private void ClearItems()
    {
        foreach (Transform child in itemsParent)
        {
            Destroy(child.gameObject);
        }
    }

    private void PopulateCircle()
    {
        for (int i = 0; i < items.Count; i++)
        {
            float angle = i * 360f / items.Count;
            Vector3 position = CalculatePosition(angle);
            Instantiate(items[i].itemPrefab, position, Quaternion.identity, itemsParent);
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

    private IEnumerator SmoothRotation(float angle)
    {
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
        ChangeItem(angle > 0 ? 1 : -1);
    }

    public void PickUpAudio(AudioClip audio)
    {
        audioSource.PlayOneShot(audio);
    }
}