using Assets.Script.Locale;
using UnityEngine;

[System.Serializable]
public class Item
{
    public ItemGroup itemID;
    public GameObject itemPrefab;
    public GameObject itemMousePrefab;

    public Item(ItemGroup _id, GameObject _prefab, GameObject _itemMousePrefab = null)
    {
        itemID = _id;
        itemPrefab = _prefab;
        itemMousePrefab = _itemMousePrefab ?? null;
    }
}

public enum ItemType
{
    Item,
    Document,
    Note,
}
