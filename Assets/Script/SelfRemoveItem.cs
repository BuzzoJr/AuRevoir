using Assets.Script.Locale;
using System.Collections.Generic;
using UnityEngine;

public class SelfRemoveItem : MonoBehaviour
{
    public PlayerData playerData;

    [Tooltip("If the playerData has any of these items, the item will be removed from the scene.")]
    public List<ItemGroup> groups;

    void Start()
    {
        foreach (ItemGroup group in groups)
        {
            if (playerData.items.Contains(group))
            {
                Destroy(gameObject);
                return;
            }
        }
    }
}
