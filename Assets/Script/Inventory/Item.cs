using UnityEngine;

[System.Serializable]
public class Item
{
    public string itemName;
    public int itemID;
    public string itemInfo;
    public GameObject itemPrefab;

    public Item(string _name, int _id, string _info, GameObject _prefab)
    {
        itemName = _name;
        itemID = _id;
        itemInfo = _info;
        itemPrefab = _prefab;
    }
}
