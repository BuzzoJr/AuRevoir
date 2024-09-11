using Assets.Script;
using Assets.Script.Locale;
using UnityEngine;

public class BottleSewer : MonoBehaviour
{
    public PlayerData playerData;
    public ItemGroup itemGroup1 = ItemGroup.Default;
    public ItemGroup itemGroup2 = ItemGroup.Default;

    void Start()
    {
        if (playerData.items.Contains(itemGroup1) || playerData.items.Contains(itemGroup2)) {
            Destroy(gameObject);
        }
    }
}
