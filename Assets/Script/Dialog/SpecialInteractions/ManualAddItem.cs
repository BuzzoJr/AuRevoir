using Assets.Script.Dialog;
using Assets.Script.Interaction;
using Assets.Script.Locale;
using System.Collections;
using System.Linq;
using TMPro;
using UnityEngine;

public class ManualAddItem : MonoBehaviour, IUse, ILangConsumer
{
    private string ItemName;
    private string ItemDescription;
    private string ItemDetails = null;
    private int ItemID;

    public ItemGroup itemGroup = ItemGroup.Default;
    [SerializeField] private GameObject ItemPrefab;
    [SerializeField] private GameObject ItemMousePrefab;
    [SerializeField] private AudioClip pickupAudio;
    [Header("Special")]
    [SerializeField] private GameObject Key;
    [Header("DIALOG ON PICKUP ITEM")]
    [SerializeField] private bool HasText = false;
    public TextGroup textGroup = TextGroup.DialogWakeUpCall;
    [SerializeField] private GameObject dialogBox;
    private TMP_Text dialogText;

    private int currentIndex = -1;

    public void UpdateLangTexts()
    {
        if (currentIndex >= 0)
        {
            TextData data = Locale.Texts[textGroup][currentIndex];
            dialogText.color = TextColorManager.textTypeColors[data.Type];
            dialogText.text = TextColorManager.TextSpeaker(data.Type, data.Text);
        }
    }

    void OnDestroy()
    {
        Locale.UnregisterConsumer(this);
    }

    private void Awake()
    {
        if (dialogBox)
            dialogText = dialogBox.GetComponentInChildren<TMP_Text>();

        ItemName = Locale.Item[itemGroup][0].Name;
        ItemDescription = Locale.Item[itemGroup][0].Description;
        ItemDetails = Locale.Item[itemGroup][0].Details;
        ItemID = Locale.Item[itemGroup][0].ID;
    }

    void Start()
    {
        if (Inventory.instance.items.Any(item => item.itemID == ItemID))
        {
            Key.SetActive(true);
            Destroy(gameObject);
        }
    }

    public void Use(GameObject who)
    {
        StartCoroutine(GettingItem());
    }

    IEnumerator GettingItem()
    {
        GameManager.Instance.UpdateGameState(GameManager.GameState.Interacting);
        PlayerController.navMeshAgent.destination = transform.position;
        yield return null;
        yield return new WaitUntil(() => !PlayerController.anim.GetBool("Walk"));

        if (HasText && dialogBox)
        {
            dialogBox.SetActive(true);
            Locale.RegisterConsumer(this);
            for (int i = 0; i < Locale.Texts[textGroup].Count; i++)
            {
                currentIndex = i;
                UpdateLangTexts();

                TextData data = Locale.Texts[textGroup][currentIndex];
                bool clicked = false;
                float delayTime = data.Delay > 0 ? data.Delay : AllDialogs.defaultDelay;
                float elapsedTime = 0;

                while (elapsedTime < delayTime && !clicked)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        clicked = true;
                    }
                    elapsedTime += Time.deltaTime;
                    yield return null;
                }
            }
            Locale.UnregisterConsumer(this);
            dialogBox.SetActive(false);
        }
        GameManager.Instance.UpdateGameState(GameManager.GameState.Playing);
        Inventory.instance.AddItem(new Item(ItemID, ItemName, ItemDescription, ItemPrefab, ItemMousePrefab, ItemDetails));
        Inventory.instance.PickUpAudio(pickupAudio);
        Key.SetActive(true);
        Destroy(gameObject);
    }
}