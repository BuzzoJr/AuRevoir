using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour {
    public List<GameObject> objectsInventory;

    private int currentItem = 0;

    public void LeftButton() {
        currentItem--;

        if(currentItem < 0)
            currentItem = objectsInventory.Count;

        
    }

    public void RightButton() {
        currentItem++;

        if(currentItem > objectsInventory.Count)
            currentItem = 0;
    }
}
