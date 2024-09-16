using Assets.Script.Dialog;
using Assets.Script.Interaction;
using Assets.Script.Locale;
using System.Collections;
using UnityEngine;

public class AddItem : MonoBehaviour, IUse
{
    public PlayerData playerData;

    [Tooltip("Item or Document")]
    public ItemGroup itemGroup = ItemGroup.Default;
    [SerializeField] private AudioClip pickupAudio;

    [Header("Walk To")]
    public Vector3 CustomWalkOffset = Vector3.zero;
    public Transform lookAtObj;

    [Header("DIALOG ON PICKUP ITEM")]
    [SerializeField] private bool HasText = false;
    [ConditionalHide("HasText")] public TextGroup textGroup = TextGroup.DialogWakeUpCall;
    [ConditionalHide("HasText")] public TextInteractionType textInteractionType = TextInteractionType.Sequence;
    private Dialog dialog;

    private void Awake()
    {
        if (HasText)
        {
            dialog = gameObject.AddComponent<Dialog>();
            dialog.Configure(textGroup, textInteractionType);
        }
    }

    void Start()
    {
        if (playerData.items.Contains(itemGroup))
            runSpecial();
    }

    public void Use(GameObject who)
    {
        StartCoroutine(GettingItem(who));
    }

    IEnumerator GettingItem(GameObject who)
    {
        GameManager.Instance.UpdateGameState(GameManager.GameState.Interacting);

        var g = new GoTo();
        yield return StartCoroutine(g.GoToRoutine(new Vector3(transform.position.x + CustomWalkOffset.x, transform.position.y + CustomWalkOffset.y, transform.position.z + CustomWalkOffset.z), lookAtObj == null ? transform : lookAtObj));

        // Action cancelled
        if (GameManager.Instance.State != GameManager.GameState.Interacting)
            yield break;

        DialogAction result = DialogAction.None;
        if (HasText)
            yield return StartCoroutine(dialog.Execute(who, (value) => result = value));

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