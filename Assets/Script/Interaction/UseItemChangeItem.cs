using Assets.Script.Locale;
using Assets.Script.Dialog;
using Assets.Script.Interaction;
using System.Collections;
using System.Linq;
using UnityEngine;

namespace Assets.Script.Interaction
{
    public class UseItemChangeItem : MonoBehaviour, IUseItem
    {
        public PlayerData playerData;
        public ItemGroup itemGroupToTake = ItemGroup.Default;
        public ItemGroup itemGroupToReceive = ItemGroup.Default;
        public TextGroup textGroup = TextGroup.DialogWakeUpCall;
        public TextInteractionType textInteractionType = TextInteractionType.Dialog;
        [SerializeField] private AudioClip pickupAudio;

        [Header("Walk before use")]
        public bool shouldWalk = false;
        [ConditionalHide("shouldWalk")] public Vector3 CustomWalkOffset = Vector3.zero;
        [ConditionalHide("shouldWalk")] public Transform lookAtObj;
        private Assets.Script.Dialog.Dialog dialog;

        void Awake()
        {
            dialog = gameObject.AddComponent<Assets.Script.Dialog.Dialog>();
            dialog.Configure(textGroup, textInteractionType);
        }

        public bool UseItem(GameObject item)
        {
            if (!playerData.items.Contains(itemGroupToTake))
                return false;

            InventoryObject invobj = InventoryManager.Instance.objects.FirstOrDefault(o => o.group == itemGroupToTake);
            if (invobj == null)
                return false;

            if (item.name != invobj.mousePrefab.name + "(Clone)")
                return false;
            StartCoroutine(GoToAndUse(item));

            return true;
        }

        IEnumerator GoToAndUse(GameObject item)
        {
            GameManager.Instance.UpdateGameState(GameManager.GameState.Interacting);

            if (shouldWalk)
            {
                var g = new GoTo();
                yield return StartCoroutine(g.GoToRoutine(new Vector3(transform.position.x + CustomWalkOffset.x, transform.position.y + CustomWalkOffset.y, transform.position.z + CustomWalkOffset.z), lookAtObj));

                // Action cancelled
                if (GameManager.Instance.State != GameManager.GameState.Interacting)
                    yield break;
            }
            yield return null;

            DialogAction result = DialogAction.None;
            yield return StartCoroutine(dialog.Execute(item, (value) => result = value));

            if (result == DialogAction.RemoveDialog)
                Destroy(this);

            playerData.RemoveItem(itemGroupToTake);
            playerData.AddItem(itemGroupToReceive);

            GameManager.Instance.UpdateGameState(GameManager.GameState.Playing);

            InventoryManager.Instance.Open(itemGroupToReceive);
            InventoryManager.Instance.PickUpAudio(pickupAudio);
        }
    }
}