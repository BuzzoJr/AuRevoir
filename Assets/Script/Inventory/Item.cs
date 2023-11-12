using UnityEngine;

[System.Serializable]
public class Item
{
    public string itemName;
    public int itemID;
    public string itemInfo;
    public GameObject itemPrefab;
    public GameObject itemMousePrefab;
    public string itemDetails;
    public Item(int _id, string _name, string _info, GameObject _prefab, GameObject _itemMousePrefab = null, string _details = null)
    {
        itemName = _name;
        itemID = _id;
        itemInfo = _info;
        itemPrefab = _prefab;
        itemMousePrefab = _prefab;
        itemMousePrefab = _itemMousePrefab ?? null;
        itemDetails = _details ?? null;
    }
}
