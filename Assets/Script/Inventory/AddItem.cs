using Assets.Script.Dialog;
using Assets.Script.Interaction;
using Assets.Script.Locale;
using System.Collections;
using TMPro;
using UnityEngine;

public class AddItem : MonoBehaviour, IUse, ILangConsumer
{
    public PlayerData playerData;

    [Tooltip("Item or Document")]
    public ItemGroup itemGroup = ItemGroup.Default;
    [SerializeField] private AudioClip pickupAudio;

    [Header("DIALOG ON PICKUP ITEM")]
    [SerializeField] private bool HasText = false;
    public TextGroup textGroup = TextGroup.DialogWakeUpCall;
    [SerializeField] private GameObject dialogBox;
    [SerializeField] private GameObject ThinkingBox;
    public Vector3 CustomWalkOffset = Vector3.zero;
    public Transform lookAtObj;
    private TMP_Text dialogText;
    private TMP_Text DialogSpeaker { get; set; }

    private TMP_Text ThinkingText;

    private int currentIndex = -1;

    public void UpdateLangTexts()
    {
        if (currentIndex >= 0)
        {
            TextData data = Locale.Texts[textGroup][currentIndex];
            if (TextType.TristanThinking == data.Type)
            {
                dialogBox.SetActive(false);
                ThinkingBox.SetActive(true);
                ThinkingText.text = "* " + data.Text + " *";
            }
            else
            {
                dialogBox.SetActive(true);
                ThinkingBox.SetActive(false);
                dialogText.text = data.Text;
                DialogSpeaker.color = TextColorManager.textTypeColors[data.Type];
                DialogSpeaker.text = "";
            }
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
            ThinkingText = ThinkingBox.GetComponentInChildren<TMP_Text>();
            dialogText = dialogBox.GetComponentInChildren<TMP_Text>();
            Transform dialogSpeakerTransform = dialogBox.transform.Find("DialogSpeaker");
            DialogSpeaker = dialogSpeakerTransform.GetComponent<TMP_Text>();
        }
    }

    void Start()
    {
        if (playerData.items.Contains(itemGroup))
            runSpecial();
    }

    public void Use(GameObject who)
    {
        StartCoroutine(GettingItem());
    }

    IEnumerator GettingItem()
    {
        GameManager.Instance.UpdateGameState(GameManager.GameState.Interacting);

        var g = new GoTo();
        yield return StartCoroutine(g.GoToRoutine(new Vector3(transform.position.x + CustomWalkOffset.x, transform.position.y + CustomWalkOffset.y, transform.position.z + CustomWalkOffset.z), lookAtObj == null ? transform : lookAtObj));

        // Action cancelled
        if (GameManager.Instance.State != GameManager.GameState.Interacting)
            yield break;

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
            ThinkingBox.SetActive(false);
        }

        GameManager.Instance.UpdateGameState(GameManager.GameState.Playing);

        InventoryManager.Instance.PickUpAudio(pickupAudio);

        if (playerData.AddItem(itemGroup))
            InventoryManager.Instance.Open(itemGroup);

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
}