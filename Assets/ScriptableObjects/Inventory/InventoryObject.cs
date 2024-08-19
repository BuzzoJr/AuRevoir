using Assets.Script.Locale;
using UnityEngine;

[CreateAssetMenu(fileName = "InventoryObject", menuName = "ScriptableObjects/InventoryObject", order = 1)]
public class InventoryObject : ScriptableObject
{
    public ItemType type;
    public ItemGroup group;
    public GameObject prefab;
    public GameObject mousePrefab;
}