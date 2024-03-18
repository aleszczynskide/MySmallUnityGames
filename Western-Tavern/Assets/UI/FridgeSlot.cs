using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FridgeSlot : MonoBehaviour, IDropHandler
{
    public List<Item> Item;
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            GameObject Dropped = eventData.pointerDrag;
            InventoryItem InventoryItem = Dropped.GetComponent<InventoryItem>();
            for (int i = 0; i < Item.Count; i++)
            {
                if (Item[i] == InventoryItem.item)
                { 
                   InventoryItem.ParentAferDrag = transform;
                }
                else if (Item[i] != InventoryItem.item)
                {
                    Debug.Log("Nie pakuj piwa do lodówy z³otówo");
                }
            }
        }
    }
}
