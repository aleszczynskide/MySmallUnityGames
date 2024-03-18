using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class Demo : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public Item[] ItemsToPickup;

    public void ItemsAdded(int id)
    {
     inventoryManager.AddItem(ItemsToPickup[id]);
    }
}
