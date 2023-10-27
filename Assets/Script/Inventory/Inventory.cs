using static UnityEditor.Progress;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.UIElements;

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
    private int currentItem = -1;
    private float lastItemPos = 1f;

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
        ItemName.text = "none";
        ItemInfo.text = "none";
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
            UpdateInfo();
            scrollRect.horizontalNormalizedPosition = lastItemPos;
        }
    }
    public void AddItem(Item item)
    {
        items.Add(item);
        GameObject newUIPlaceholder = Instantiate(ItemPlaceholderPrefab, ItemPlaceholder.transform);
        GameObject newItem = Instantiate(item.itemPrefab, newUIPlaceholder.transform);
        lastItemPos = 1;
        currentItem += 1;
    }

    public void ChangeItem(int direction)
    {
        currentItem += direction;
        currentItem = Mathf.Clamp(currentItem, 0, items.Count - 1);
        UpdateInfo();
        ScrollByDelta((1f * direction) / (items.Count - 1));
    }

    private void UpdateInfo()
    {
        if(items.Count != 0)
        {
            ItemName.text = items[currentItem].itemName;
            ItemInfo.text = items[currentItem].itemInfo;
        }
    }
    public void ScrollByDelta(float delta)
    {
        scrollRect.horizontalNormalizedPosition += delta;
        lastItemPos = scrollRect.horizontalNormalizedPosition;
    }
}
