using Assets.Script.Locale;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Documents : MonoBehaviour
{
    public static Documents instance;
    public List<Item> documents = new List<Item>();
    [Header("Clickable Item List")]
    private List<GameObject> documentNavigation = new List<GameObject>();
    [SerializeField] private GameObject documentNavigationParent;
    [SerializeField] private GameObject documentNavigationPrefab;
    [Header("UI Text")]
    [SerializeField] private TMP_Text DocumentName;
    [SerializeField] private TMP_Text DocumentDetails;
    [SerializeField] private GameObject useText;
    [Header("Reference Points")]
    [SerializeField] private GameObject DocumentDetailsParent;
    [Header("Item Circle")]
    [SerializeField] private Transform DocumentParent;
    [SerializeField] private float radius = 20f;
    [SerializeField] private float rotationDuration = 1.0f;

    private AudioSource audioSource;
    private bool isRotating = false;
    private GameObject documentsUI;
    private int currentDocument = 0;
    private TMP_Text interactDocument;
    private TMP_Text documentNavigationText;
    private string currentState = "Playing";

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
        documentsUI = transform.GetChild(0).gameObject;
        DocumentName.text = Locale.Texts[TextGroup.Inventory][0].Text;
        DocumentDetails.text = Locale.Texts[TextGroup.Inventory][0].Text;
        interactDocument = useText.GetComponentInChildren<TMP_Text>();
        GameManager.OnGameStateChange += GameManagerOnGameStateChange;
    }
    void OnDestroy()
    {
        GameManager.OnGameStateChange -= GameManagerOnGameStateChange;
    }

    private void GameManagerOnGameStateChange(GameManager.GameState state)
    {
        currentState = state.ToString();
    }

    private void Update()
    {
        if (documentsUI.activeSelf)
        {
            GameManager.Instance.UpdateGameState(GameManager.GameState.Menu);

            if (Input.GetKeyDown(KeyCode.Tab))
            {
                OpenDocuments(false);
            }

            if (Input.GetMouseButtonDown(0))
            {
                if (DocumentDetailsParent.activeSelf)
                    DocumentDetailsParent.SetActive(false);
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
                        if (documentNavigation.Contains(result.gameObject))
                        {
                            RotateToItem(documentNavigation.IndexOf(result.gameObject));
                            break;
                        }
                        switch (result.gameObject.name)
                        {
                            case "UseItem":
                                if (documents[currentDocument].itemMousePrefab != null)
                                {
                                    Instantiate(documents[currentDocument].itemMousePrefab, Vector3.zero, Quaternion.identity);
                                    documentsUI.SetActive(false);
                                    GameManager.Instance.UpdateGameState(GameManager.GameState.Interacting);
                                }
                                else if (documents[currentDocument].itemDetails != null)
                                {
                                    DocumentDetailsParent.SetActive(true);
                                }
                                break;
                            case "Close":
                                OpenDocuments(false);
                                break;
                            case "Items":
                                Inventory.instance.OpenInventory(true);
                                OpenDocuments(false);
                                break;
                            case "Notes":
                                Notes.instance.OpenNotes(true);
                                OpenDocuments(false);
                                break;
                            case "Map":
                                Map.instance.OpenMap(true);
                                OpenDocuments(false);
                                break;
                        }
                    }
                }
            }
        }
    }

    public void OpenDocuments(bool open = true, int index = 0)
    {
        documentsUI.SetActive(open);
        if (documentsUI.activeSelf)
        {
            GameManager.Instance.UpdateGameState(GameManager.GameState.Menu);
            if (index != 0)
                currentDocument = documents.Count - 1;
            ClearItems();
            PopulateCircle(currentDocument);
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
        foreach (var navText in documentNavigation)
        {
            documentNavigationText = navText.GetComponentInChildren<TMP_Text>();
            documentNavigationText.color = Color.grey;
        }
        if (documents.Count != 0)
        {
            DocumentName.text = documents[currentDocument].itemName;
            Debug.Log(documents[currentDocument]);
            Debug.Log(DocumentName.text);
            documentNavigationText = documentNavigation[currentDocument].GetComponentInChildren<TMP_Text>();
            documentNavigationText.color = Color.white;
            if (documents[currentDocument].itemMousePrefab != null)
            {
                useText.SetActive(true);
                interactDocument.text = Locale.Texts[TextGroup.Inventory][1].Text;
            }
            else if (documents[currentDocument].itemDetails != null)
            {
                useText.SetActive(true);
                interactDocument.text = Locale.Texts[TextGroup.Inventory][2].Text;
                DocumentDetails.text = documents[currentDocument].itemDetails;
            }
            else
            {
                useText.SetActive(false);
            }
        }
    }

    public void AddDocument(Item item)
    {
        if (documents.FindIndex(existingItem => existingItem.itemID == item.itemID) != -1)
            return;

        documents.Add(item);
        int index = documents.Count - 1;
        GameObject newItem = Instantiate(documentNavigationPrefab, documentNavigationParent.transform);
        documentNavigation.Add(newItem);
        documentNavigationText = documentNavigation[index].GetComponentInChildren<TMP_Text>();
        documentNavigationText.text = item.itemName;
        OpenDocuments(true, index);
    }

    public void ChangeItem(int direction)
    {
        currentDocument += direction;
        currentDocument = (currentDocument + documents.Count) % documents.Count;
        UpdateInfo();
    }

    public void RotateItemsParent(int dir)
    {
        if (documents.Count <= 1 || isRotating) return;

        float angleBetweenItems = 360f / documents.Count;
        StartCoroutine(SmoothRotation(angleBetweenItems, dir));
    }

    private void ClearItems()
    {
        foreach (Transform child in DocumentParent)
        {
            Destroy(child.gameObject);
        }
    }

    private void PopulateCircle(int offset = 0)
    {
        int itemCount = documents.Count;
        for (int i = 0; i < itemCount; i++)
        {
            // Calculate the adjusted index with the offset
            int adjustedIndex = (i + offset) % itemCount;

            // Calculate the angle for the current position
            float angle = i * 360f / itemCount;
            Vector3 position = CalculatePosition(angle);

            // Instantiate the prefab at the calculated position
            Instantiate(documents[adjustedIndex].itemPrefab, position, Quaternion.identity, DocumentParent);
        }
    }

    private Vector3 CalculatePosition(float angle)
    {
        // Convert angle from degrees to radians
        float radian = angle * Mathf.Deg2Rad;

        // Calculate x and z position for a horizontal circle on X-Z plane
        float x = radius * Mathf.Cos(radian);
        float z = radius * Mathf.Sin(radian);

        // Adjust position based on the DocumentParent's position
        return new Vector3(x + DocumentParent.position.x, DocumentParent.position.y, z + DocumentParent.position.z);
    }

    private IEnumerator SmoothRotation(float angleItem, int dir)
    {
        float angle = angleItem * dir;
        isRotating = true;
        float elapsedTime = 0;
        Quaternion startingRotation = DocumentParent.rotation;
        Quaternion finalRotation = Quaternion.Euler(DocumentParent.eulerAngles + new Vector3(0, angle, 0));

        while (elapsedTime < rotationDuration)
        {
            DocumentParent.rotation = Quaternion.Slerp(startingRotation, finalRotation, elapsedTime / rotationDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        DocumentParent.rotation = finalRotation;
        isRotating = false;
        ChangeItem(dir);
    }

    public void PickUpAudio(AudioClip audio)
    {
        audioSource.PlayOneShot(audio);
    }



    public void RotateToItem(int targetIndex)
    {
        if (targetIndex == -1 || targetIndex == currentDocument) return;

        int direction = CalculateRotationDirection(currentDocument, targetIndex);
        int distance = CalculateRotationDistance(currentDocument, targetIndex, direction);
        RotateItemsParent(distance * direction);
    }


    private int CalculateRotationDirection(int currentIndex, int targetIndex)
    {
        int forwardDistance = (targetIndex - currentIndex + documents.Count) % documents.Count;
        int backwardDistance = (currentIndex - targetIndex + documents.Count) % documents.Count;

        return forwardDistance <= backwardDistance ? 1 : -1;
    }

    private int CalculateRotationDistance(int currentIndex, int targetIndex, int direction)
    {
        if (direction > 0)
            return (targetIndex - currentIndex + documents.Count) % documents.Count;
        else
            return (currentIndex - targetIndex + documents.Count) % documents.Count;
    }
}