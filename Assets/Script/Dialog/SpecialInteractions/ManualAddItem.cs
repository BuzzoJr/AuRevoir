using Assets.Script.Dialog;
using Assets.Script.Interaction;
using Assets.Script.Locale;
using System.Collections;
using TMPro;
using UnityEngine;
using static UnityEditor.Progress;

public class ManualAddItem : MonoBehaviour, IUse
{
    private string ItemName;
    private string ItemDescription;
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

    private void Awake()
    {
        dialogText = dialogBox.GetComponentInChildren<TMP_Text>();
        ItemName = Locale.Item[itemGroup][0].Name;
        ItemDescription = Locale.Item[itemGroup][0].Description;
        ItemID = Locale.Item[itemGroup][0].ID;
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

        Inventory.instance.AddItem(new Item(ItemID, ItemName, ItemDescription, ItemPrefab, ItemMousePrefab));
        if (HasText)
        {
            dialogBox.SetActive(true);
            foreach (TextData data in Locale.Texts[textGroup])
            {
                dialogText.color = TextColorManager.textTypeColors[data.Type];
                dialogText.text = data.Type != TextType.Player ? data.Type + ": " + data.Text : data.Text;

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
        }
        GameManager.Instance.UpdateGameState(GameManager.GameState.Playing);
        Inventory.instance.PickUpAudio(pickupAudio);
        Key.SetActive(true);
        Destroy(gameObject);
    }
}