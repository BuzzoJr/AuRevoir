using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    public List<Item> items = new List<Item>();
    [SerializeField] private float radius = 20f;
    [SerializeField] private TMP_Text ItemName;
    [SerializeField] private TMP_Text ItemInfo;
    [SerializeField] private Transform itemsParent; 
    [SerializeField] private float rotationDuration = 1.0f;

    private bool isRotating = false;
    private GameObject inventoryUI;
    private int currentItem = -1;

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

            if (inventoryUI.activeSelf)
                GameManager.Instance.UpdateGameState(GameManager.GameState.Menu);
            else
                GameManager.Instance.UpdateGameState(GameManager.GameState.Playing);

            UpdateInfo();
        }
    }

    private void UpdateInfo()
    {
        if (items.Count != 0)
        {
            ItemName.text = items[currentItem].itemName;
            ItemInfo.text = items[currentItem].itemInfo;
        }
    }

    public void AddItem(Item item)
    {
        items.Add(item);
        ClearItems();
        PopulateCircle();
        currentItem += 1;
    }

    public void ChangeItem(int direction)
    {
        currentItem += direction;
        currentItem = (currentItem + items.Count) % items.Count;
        Debug.Log(currentItem);
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
}