using Assets.Script.Locale;
using System.Linq;
using UnityEngine;

namespace Assets.Script.Interaction
{
    public class UseItemChangeItem : MonoBehaviour, IUseItem
    {
        public PlayerData playerData;

        public ItemGroup itemGroupToTake = ItemGroup.Default;
        public ItemGroup itemGroupToReceive = ItemGroup.Default;


        public bool UseItem(GameObject item)
        {
            if (!playerData.items.Contains(itemGroupToTake))
                return false;

            InventoryObject obj = InventoryManager.Instance.objects.FirstOrDefault(o => o.group == itemGroupToTake);
            if (obj == null)
                return false;

            Debug.Log("Used: " + item.name);
            Debug.Log("Expected: " + obj.mousePrefab.name);
            if (item.name != obj.mousePrefab.name + "(Clone)")
                return false;

            playerData.RemoveItem(itemGroupToTake);
            playerData.AddItem(itemGroupToReceive);
            InventoryManager.Instance.Open(itemGroupToReceive);

            return true;
        }
    }
}