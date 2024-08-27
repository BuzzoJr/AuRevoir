using Assets.Script.Locale;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Notes : MonoBehaviour, ILangConsumer
{
    public PlayerData playerData;

    private Dictionary<ItemGroup, GameObject> navigation = new();

    public bool opened = false;

    [Header("Clickable List")]
    [SerializeField] private GameObject navigationParent;
    [SerializeField] private GameObject navigationPrefab;

    [Header("UI Text")]
    //[SerializeField] private TMP_Text objName;
    //[SerializeField] private TMP_Text objDetails;

    [Header("Reference Points")]
    //[SerializeField] private GameObject detailsParent;

    private GameObject ui;
    private ItemGroup current = ItemGroup.Default;
    private ItemType myType = ItemType.Note;

    void Awake()
    {
        Locale.RegisterConsumer(this);
    }

    void OnDestroy()
    {
        Locale.UnregisterConsumer(this);
    }

    void Start()
    {
        navigation = new();

        // Initiate all items
        foreach (InventoryObject obj in InventoryManager.Instance.objects)
        {
            if (obj.type != myType)
                continue;

            // Navigation
            GameObject nav = Instantiate(navigationPrefab, navigationParent.transform);
            navigation.Add(obj.group, nav);
            //nav.GetComponentInChildren<TMP_Text>().text = Locale.Item[obj.group].Name;
        }

        ui = transform.GetChild(0).gameObject;
        UpdateLangTexts();
    }

    public void UpdateLangTexts()
    {

        foreach (var nav in navigation)
            nav.Value.GetComponentInChildren<TMP_Text>().text = Locale.Item[nav.Key].Name;

        if (!navigation.Any(n => n.Value.activeSelf))
        {
            //objName.text = Locale.Texts[TextGroup.Inventory][0].Text;
            //objDetails.text = Locale.Texts[TextGroup.Inventory][0].Text;
            return;
        }

        UpdateCurrentItemData();
    }

    private void UpdateCurrentItemData()
    {
        ItemData itemData = Locale.Item[current];

        //objName.text = itemData.Name;

        //if (itemData.Details != null)
        //objDetails.text = itemData.Details;
    }

    void Update()
    {
        if (!ui.activeSelf)
            return;

        GameManager.Instance.UpdateGameState(GameManager.GameState.Menu);
        if (Input.GetMouseButtonDown(0))
        {
            //if (detailsParent.activeSelf)
            //detailsParent.SetActive(false);

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
                    var selected = navigation.FirstOrDefault(n => n.Value == result.gameObject).Key;
                    if (selected != ItemGroup.Default)
                    {
                        current = selected;
                        UpdateInfo();
                        break;
                    }

                    switch (result.gameObject.name)
                    {
                        case "Close":
                            Close();
                            GameManager.Instance.UpdateGameState(GameManager.GameState.Playing);
                            break;
                        case "Items":
                            InventoryManager.Instance.Open(ItemType.Item);
                            break;
                        case "Documents":
                            InventoryManager.Instance.Open(ItemType.Document);
                            break;
                        case "Notes":
                            InventoryManager.Instance.Open(ItemType.Note);
                            break;
                    }
                }
            }
        }
    }

    public void Close()
    {
        ui.SetActive(false);
        opened = false;
    }

    public void Open(ItemGroup selected = ItemGroup.Default)
    {
        ui.SetActive(true);
        opened = true;

        if (selected != ItemGroup.Default && playerData.items.Contains(selected))
            current = selected;

        OrganizeNavigation();
        UpdateInfo();
    }

    private void OrganizeNavigation()
    {
        // Ativa / Desativa baseado na lista de items do player data
        foreach (var nav in navigation)
            nav.Value.SetActive(playerData.items.Contains(nav.Key));
    }

    private void UpdateInfo()
    {
        foreach (var nav in navigation)
            nav.Value.GetComponentInChildren<TMP_Text>().color = (nav.Key == current) ? Color.white : Color.grey;

        UpdateCurrentItemData();
    }
}