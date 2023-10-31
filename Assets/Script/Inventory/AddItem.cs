using System.Collections;
using System.Collections.Generic;
using Assets.Script.Interaction;
using UnityEngine;

public class AddItem : MonoBehaviour, IUse
{
    [SerializeField] private string ItemName;
    [SerializeField] private string ItemDescription;
    [SerializeField] private GameObject ItemPrefab;

    public void Use(GameObject who)
    {
        StartCoroutine(GettingItem());
    }

    IEnumerator GettingItem()
    {
        GameManager.Instance.UpdateGameState(GameManager.GameState.Interacting);
        PlayerController.navMeshAgent.destination = transform.position;
        yield return null;
        yield return new WaitUntil(() => !PlayerController.anim.GetBool("Walk"));

        Inventory.instance.AddItem(new Item(ItemName, 1, ItemDescription, ItemPrefab));
        Destroy(gameObject);
        GameManager.Instance.UpdateGameState(GameManager.GameState.Playing);
    }
}