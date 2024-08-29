using Assets.Script.Locale;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Documents : MonoBehaviour, ILangConsumer
{
    public PlayerData playerData;

    public Dictionary<ItemGroup, GameObject> all = new();
    private Dictionary<ItemGroup, GameObject> showing = new();
    private Dictionary<ItemGroup, GameObject> navigation = new();

    public bool opened = false;

    [Header("Clickable List")]
    [SerializeField] private GameObject navigationParent;
    [SerializeField] private GameObject navigationPrefab;

    [Header("UI Text")]
    [SerializeField] private TMP_Text objName;
    [SerializeField] private TMP_Text objDetails;
    [SerializeField] private GameObject useText;

    [Header("Reference Points")]
    [SerializeField] private GameObject detailsParent;

    [Header("Circle")]
    [SerializeField] private Transform circleParent;
    [SerializeField] private float radius = 20f;
    [SerializeField] private float rotationDuration = 1.0f;

    private bool isRotating = false;
    private GameObject ui;
    private int current = 0;
    private TMP_Text interact;
    private ItemType myType = ItemType.Document;

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
        all = new();
        navigation = new();

        // Initiate all items
        foreach (InventoryObject obj in InventoryManager.Instance.objects)
        {
            if (obj.type != myType)
                continue;

            // Instance
            GameObject inst = Instantiate(obj.prefab, circleParent);
            all.Add(obj.group, inst);

            // Navigation
            GameObject nav = Instantiate(navigationPrefab, navigationParent.transform);
            navigation.Add(obj.group, nav);
            nav.GetComponentInChildren<TMP_Text>().text = Locale.Item[obj.group].Name;
        }

        ui = transform.GetChild(0).gameObject;
        interact = useText.GetComponentInChildren<TMP_Text>();
        UpdateLangTexts();
    }

    public void UpdateLangTexts()
    {
        foreach (var nav in navigation)
            nav.Value.GetComponentInChildren<TMP_Text>().text = Locale.Item[nav.Key].Name;

        if (showing.Count <= 0)
        {
            objName.text = Locale.Texts[TextGroup.Inventory][0].Text;
            objDetails.text = Locale.Texts[TextGroup.Inventory][0].Text;
            return;
        }

        UpdateCurrentItemData();
    }

    private void UpdateCurrentItemData()
    {
        ItemGroup group = showing.Keys.ElementAt(current);
        ItemData itemData = Locale.Item[group];

        objName.text = itemData.Name;

        if (InventoryManager.Instance.GetObjectByGroup(group).mousePrefab != null)
        {
            useText.SetActive(true);
            interact.text = Locale.Texts[TextGroup.Inventory][1].Text;
        }
        else if (itemData.Details != null)
        {
            useText.SetActive(true);
            interact.text = Locale.Texts[TextGroup.Inventory][2].Text;
            objDetails.text = itemData.Details;
        }
        else
        {
            useText.SetActive(false);
        }
    }

    void Update()
    {
        if (!ui.activeSelf)
            return;

        GameManager.Instance.UpdateGameState(GameManager.GameState.Menu);
        if (Input.GetMouseButtonDown(0))
        {
            if (detailsParent.activeSelf)
                detailsParent.SetActive(false);

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
                    if (navigation.Values.Contains(result.gameObject))
                    {
                        ItemGroup group = navigation.FirstOrDefault(n => n.Value == result.gameObject).Key;
                        RotateToItem(showing.Keys.ToList().IndexOf(group));
                        break;
                    }

                    switch (result.gameObject.name)
                    {
                        case "UseItem":
                            ItemGroup group = showing.Keys.ElementAt(current);
                            GameObject mouse = InventoryManager.Instance.GetObjectByGroup(group).mousePrefab;
                            if (mouse != null)
                            {
                                Instantiate(mouse, Vector3.zero, Quaternion.identity);
                                ui.SetActive(false);
                                GameManager.Instance.UpdateGameState(GameManager.GameState.Interacting);
                            }
                            else if (Locale.Item[group].Details != null)
                            {
                                detailsParent.SetActive(true);
                            }
                            break;
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
        OrganizeCircle(selected);
        OrganizeNavigation();
        UpdateInfo();
    }

    private void OrganizeCircle(ItemGroup selected = ItemGroup.Default)
    {
        // Ativa / Desativa baseado na lista de items do player data
        foreach (var obj in all)
            obj.Value.SetActive(playerData.items.Contains(obj.Key));

        // Pega somente a lista de items que podem ser apresentados
        showing = all.Where(i => i.Value.activeSelf).ToDictionary(i => i.Key, i => i.Value);

        // Prepara o offset para deixar o item selecionado na frente
        if (selected != ItemGroup.Default && showing.Keys.Contains(selected))
            current = showing.Keys.ToList().IndexOf(selected);

        // Posiciona os ativos no circulo
        for (int i = 0; i < showing.Count; i++)
        {
            int index = (i + current) % showing.Count;
            float angle = i * 2 * Mathf.PI / showing.Count;

            showing.Values.ElementAt(index).transform.SetPositionAndRotation(
                circleParent.position + new Vector3(radius * Mathf.Cos(angle), 0, radius * Mathf.Sin(angle)), // position
                Quaternion.identity); // rotation
        }
    }

    private void OrganizeNavigation()
    {
        // Ativa / Desativa baseado na lista de items do player data
        foreach (var nav in navigation)
            nav.Value.SetActive(playerData.items.Contains(nav.Key));
    }

    private void UpdateInfo()
    {
        if (showing.Count <= 0)
            return;

        foreach (var nav in navigation)
            nav.Value.GetComponentInChildren<TMP_Text>().color = (nav.Key == showing.Keys.ElementAt(current)) ? Color.white : Color.grey;

        UpdateCurrentItemData();
    }

    public void ChangeItem(int direction)
    {
        current += direction;
        current = (current + showing.Count) % showing.Count;
        UpdateInfo();
    }

    public void RotateItemsParent(int dir)
    {
        if (showing.Count <= 1 || isRotating) return;

        float angleBetweenItems = 360f / showing.Count;
        StartCoroutine(SmoothRotation(angleBetweenItems, dir));
    }

    private IEnumerator SmoothRotation(float angleItem, int dir)
    {
        float angle = angleItem * dir;
        isRotating = true;
        float elapsedTime = 0;
        Quaternion startingRotation = circleParent.rotation;
        Quaternion finalRotation = Quaternion.Euler(circleParent.eulerAngles + new Vector3(0, angle, 0));

        while (elapsedTime < rotationDuration)
        {
            circleParent.rotation = Quaternion.Slerp(startingRotation, finalRotation, elapsedTime / rotationDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        circleParent.rotation = finalRotation;
        isRotating = false;
        ChangeItem(dir);
    }

    public void RotateToItem(int targetIndex)
    {
        if (targetIndex == -1 || targetIndex == current) return;

        int direction = CalculateRotationDirection(current, targetIndex);
        int distance = CalculateRotationDistance(current, targetIndex, direction);
        RotateItemsParent(distance * direction);
    }


    private int CalculateRotationDirection(int currentIndex, int targetIndex)
    {
        int forwardDistance = (targetIndex - currentIndex + showing.Count) % showing.Count;
        int backwardDistance = (currentIndex - targetIndex + showing.Count) % showing.Count;

        return forwardDistance <= backwardDistance ? 1 : -1;
    }

    private int CalculateRotationDistance(int currentIndex, int targetIndex, int direction)
    {
        if (direction > 0)
            return (targetIndex - currentIndex + showing.Count) % showing.Count;
        else
            return (currentIndex - targetIndex + showing.Count) % showing.Count;
    }
}