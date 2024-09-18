using Assets.Script;
using Assets.Script.Locale;
using System.Collections.Generic;
using UnityEngine;

public class SelfRemoveItem : MonoBehaviour
{
    public PlayerData playerData;

    [Tooltip("If the playerData has any of these items, the item will be removed from the scene.")]
    public List<ItemGroup> groups;
    public List<GameSteps> steps;
    public bool destroyItem = true;

    void Start()
    {
        foreach (ItemGroup group in groups)
        {
            if (playerData.items.Contains(group))
            {
                if(destroyItem)
                    Destroy(gameObject);
                else
                    gameObject.SetActive(false);
                return;
            }
        }

        foreach (GameSteps step in steps)
        {
            if (playerData.steps.Contains(step))
            {
                if(destroyItem)
                    Destroy(gameObject);
                else
                    gameObject.SetActive(false);
                return;
            }
        }
    }
}
