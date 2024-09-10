using Assets.Script.Locale;
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

        [Header("Walk before use")]
        public bool shouldWalk = false;
        [ConditionalHide("shouldWalk")] public Vector3 CustomWalkOffset = Vector3.zero;
        [ConditionalHide("shouldWalk")] public Transform lookAtObj;


        public bool UseItem(GameObject item)
        {
            if (!playerData.items.Contains(itemGroupToTake))
                return false;

            InventoryObject obj = InventoryManager.Instance.objects.FirstOrDefault(o => o.group == itemGroupToTake);
            if (obj == null)
                return false;

            if (item.name != obj.mousePrefab.name + "(Clone)")
                return false;

            StartCoroutine(GoToAndUse());

            return true;
        }

        IEnumerator GoToAndUse()
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

            playerData.RemoveItem(itemGroupToTake);
            playerData.AddItem(itemGroupToReceive);

            GameManager.Instance.UpdateGameState(GameManager.GameState.Playing);

            InventoryManager.Instance.Open(itemGroupToReceive);
        }
    }
}