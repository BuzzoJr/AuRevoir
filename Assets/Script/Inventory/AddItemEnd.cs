using Assets.Script.Dialog;
using Assets.Script.Interaction;
using Assets.Script.Locale;
using System.Collections;
using System.Linq;
using TMPro;
using UnityEngine;

public class AddItemEnd : MonoBehaviour, IUse
{
    public PlayerData playerData;
    private string ItemName;
    private string ItemDescription;
    private string ItemDetails = null;
    private int ItemID;
    public ItemGroup itemGroup = ItemGroup.Default;
    [SerializeField] private GameObject ItemPrefab;
    [SerializeField] private GameObject ItemMousePrefab;
    [SerializeField] private AudioClip pickupAudio;
    [Header("DIALOG ON PICKUP ITEM")]
    [SerializeField] private bool HasText = false;
    public TextGroup textGroup = TextGroup.DialogWakeUpCall;
    [SerializeField] private GameObject dialogBox;
    private TMP_Text dialogText;
    [SerializeField] private DoorController labDoor;

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
            Destroy(gameObject);
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
            foreach (TextData data in Locale.Texts[textGroup])
            {
                dialogText.color = TextColorManager.textTypeColors[data.Type];
                dialogText.text = TextColorManager.TextSpeaker(data.Type, data.Text);

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
            dialogBox.SetActive(false);

            if (textGroup == TextGroup.LabPickUpChips)
            {
                var special = GetComponentInChildren<ISpecial>();
                if (special != null)
                    special.Special(gameObject);
                playerData.EndGame = true;
                labDoor.SetLock(false);
                int itemIndex = Inventory.instance.items.FindIndex(item => item.itemID == 7);
                if (itemIndex != -1)
                {
                    Inventory.instance.items.RemoveAt(itemIndex);
                }
            }
        }
        GameManager.Instance.UpdateGameState(GameManager.GameState.Playing);
        Inventory.instance.AddItem(new Item(ItemID, ItemName, ItemDescription, ItemPrefab, ItemMousePrefab, ItemDetails));
        Inventory.instance.PickUpAudio(pickupAudio);
        Destroy(gameObject);
    }
}