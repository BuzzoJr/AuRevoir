using Assets.Script;
using Assets.Script.Locale;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    public PlayerData playerData;
    public GameObject inventoryBag;
    public List<InventoryObject> objects = new();

    public Inventory items;
    public Documents documents;
    public Notes notes;

    private ItemType lastType = ItemType.Item;
    private AudioSource audioSource;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        SceneManager.sceneUnloaded += OnsceneUnloaded;
    }

    private void OnsceneUnloaded(Scene scene)
    {
        items.Close();
        documents.Close();
        notes.Close();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
            OpenClose();

        inventoryBag.SetActive(CanOpen());
    }

    public InventoryObject GetObjectByGroup(ItemGroup group)
    {
        return objects.FirstOrDefault(o => o.group == group);
    }

    public void Add(ItemGroup item)
    {
        InventoryObject obj = GetObjectByGroup(item);
        if (obj == null)
        {
            Debug.LogError($"{typeof(InventoryManager)}: Tentei adicionar um item que não conheço '{item}'.");
            return;
        }

        playerData.AddItem(item);
    }

    public void AddMany(List<ItemGroup> groups)
    {
        foreach (ItemGroup group in groups)
            Add(group);
    }

    public void OpenClose()
    {
        if (items.opened || documents.opened || notes.opened)
            StartCoroutine(WaitMouseReleaseToPlay()); // Close
        else
            Open();
    }

    private IEnumerator WaitMouseReleaseToPlay()
    {
        yield return new WaitUntil(() => !Input.GetMouseButton(0));
        items.Close();
        documents.Close();
        notes.Close();
        GameManager.Instance.UpdateGameState(GameManager.GameState.Playing);
    }

    public void Open(ItemType type)
    {
        lastType = type;
        Open(force: true);
    }

    public void Open(ItemGroup selected = ItemGroup.Default, bool force = false)
    {
        if (!CanOpen() && !force)
            return;

        GameManager.Instance.UpdateGameState(GameManager.GameState.Menu);

        // Close Interaction Wheel
        GameObject player = GameObject.FindWithTag("Player");
        if (player.TryGetComponent(out PlayerController controller))
            controller.CloseInteractionWheel();

        if (selected != ItemGroup.Default)
            lastType = objects.FirstOrDefault(o => o.group == selected)?.type ?? lastType;

        switch (lastType)
        {
            case ItemType.Item:
                documents.Close();
                notes.Close();
                items.Open(selected);
                return;

            case ItemType.Document:
                items.Close();
                notes.Close();
                documents.Open(selected);
                return;

            case ItemType.Note:
                items.Close();
                documents.Close();
                notes.Open(selected);
                return;
        }
    }

    private bool CanOpen()
    {
        // State
        if (GameManager.Instance.State != GameManager.GameState.Playing)
            return false;

        // Scenes
        List<string> blockInventoryInScenes = new()
        {
            SceneRef.NewMenu.ToString(),
            SceneRef.AP_BedroomBadDream.ToString(),
            SceneRef.AP_LivingroomBadDream.ToString(),
        };

        return !blockInventoryInScenes.Contains(SceneManager.GetActiveScene().name);
    }

    public void PickUpAudio(AudioClip audio)
    {
        audioSource.PlayOneShot(audio);
    }
}