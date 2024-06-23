using Assets.Script.Dialog;
using Assets.Script.Interaction;
using Assets.Script.Locale;
using System.Collections;
using System.Linq;
using TMPro;
using UnityEngine;

public class AddItem : MonoBehaviour, IUse, ILangConsumer
{
    [Tooltip("Item or Document")]
    public ItemType itemType = ItemType.Item;
    public ItemGroup itemGroup = ItemGroup.Default;
    [SerializeField] private GameObject ItemPrefab;
    [SerializeField] private GameObject ItemMousePrefab;
    [SerializeField] private AudioClip pickupAudio;
    [Header("DIALOG ON PICKUP ITEM")]
    [SerializeField] private bool HasText = false;
    public TextGroup textGroup = TextGroup.DialogWakeUpCall;
    [SerializeField] private GameObject dialogBox;
    private TMP_Text dialogText;
    private TMP_Text DialogSpeaker { get; set; }


    private int currentIndex = -1;

    public void UpdateLangTexts()
    {
        if (currentIndex >= 0)
        {
            TextData data = Locale.Texts[textGroup][currentIndex];
            //dialogText.color = TextColorManager.textTypeColors[data.Type];
            dialogText.text = TextColorManager.TextSpeaker(TextType.System, data.Text);
            DialogSpeaker.color = TextColorManager.textTypeColors[data.Type];
            DialogSpeaker.text = TextColorManager.TextSpeaker(data.Type, "");
        }
    }

    void OnDestroy()
    {
        Locale.UnregisterConsumer(this);
    }

    private void Awake()
    {
        if (dialogBox)
        {
            dialogText = dialogBox.GetComponentInChildren<TMP_Text>();
            Transform dialogSpeakerTransform = dialogBox.transform.Find("DialogSpeaker");
            DialogSpeaker = dialogSpeakerTransform.GetComponent<TMP_Text>();
        }
    }

    void Start()
    {
        if (itemType == ItemType.Item)
            if (Inventory.instance.items.Any(item => item.itemID == itemGroup) || Documents.instance.documents.Any(item => item.itemID == itemGroup))
                runSpecial();
    }

    public void Use(GameObject who)
    {
        StartCoroutine(GettingItem());
    }

    IEnumerator GettingItem()
    {
        GameManager.Instance.UpdateGameState(GameManager.GameState.Interacting);
        GameObject.FindWithTag("Player").GetComponent<PlayerController>().GoTo(transform.position, transform);

        yield return null;
        yield return new WaitUntil(() => !PlayerController.anim.GetBool("Walk") && !PlayerController.anim.GetBool("Run"));

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
                        clicked = true; ;
                    }
                    elapsedTime += Time.deltaTime;
                    yield return null;
                }
            }
            Locale.UnregisterConsumer(this);
            dialogBox.SetActive(false);
        }
        GameManager.Instance.UpdateGameState(GameManager.GameState.Playing);
        if (itemType == ItemType.Item)
            Inventory.instance.AddItem(new Item(itemGroup, ItemPrefab, ItemMousePrefab));
        else
            Documents.instance.AddDocument(new Item(itemGroup, ItemPrefab, ItemMousePrefab));

        Inventory.instance.PickUpAudio(pickupAudio);
        runSpecial();
    }

    private void runSpecial()
    {
        var special = GetComponent<IUseSpecial>();
        if (special != null)
            special.UseSpecial(gameObject);
        else
            Destroy(gameObject);
    }

    public enum ItemType
    {
        Item,
        Document,
    }
}