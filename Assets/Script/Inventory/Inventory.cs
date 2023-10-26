using static UnityEditor.Progress;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    public List<Item> items = new List<Item>();

    [SerializeField] private TMP_Text ItemName;
    [SerializeField] private TMP_Text ItemInfo;
    [SerializeField] private GameObject ItemPlaceholder;
    [SerializeField] private GameObject ItemPlaceholderPrefab;
    [SerializeField] private ScrollRect scrollRect;
    private GameObject inventoryUI;
    private int currentItem = 0;

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
        inventoryUI = transform.GetChild(0).gameObject;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
            UpdateInfo();
        }
    }
    public void AddItem(Item item)
    {
        items.Add(item);
        // Instantiate the UI placeholder as a child of the main ItemPlaceholder (which contains the HorizontalLayoutGroup)
        GameObject newUIPlaceholder = Instantiate(ItemPlaceholderPrefab, ItemPlaceholder.transform);

        // Instantiate the 3D object as a child of this new UI placeholder
        GameObject newItem = Instantiate(item.itemPrefab, newUIPlaceholder.transform);
    }

    public void ChangeItem(int direction)
    {
        currentItem += direction;
        currentItem = Mathf.Clamp(currentItem, 0, items.Count - 1);
        UpdateInfo();
        ScrollByDelta((1f * direction)/ items.Count);
    }

    private void UpdateInfo()
    {
        if(items.Count != 0)
        {
            ItemName.text = items[currentItem].itemName;
            ItemInfo.text = items[currentItem].itemInfo;
        }
        else
        {
            ItemName.text = "none";
            ItemInfo.text = "none";
        }
    }
    public void ScrollByDelta(float delta)
    {
        scrollRect.horizontalNormalizedPosition += delta;
        Debug.Log(delta);
        Debug.Log(items.Count);
        Debug.Log(scrollRect.horizontalNormalizedPosition);
    }
}
