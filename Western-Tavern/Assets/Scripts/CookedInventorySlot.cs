using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CookedInventorySlot : MonoBehaviour, IDropHandler
{
    GameObject CookingPan;
         
    public void Start()
    {
       CookingPan = GameObject.Find("CookingPan");
    }
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            GameObject dropped = eventData.pointerDrag;
            InventoryItem inventoryItem = dropped.GetComponent<InventoryItem>();
            inventoryItem.ParentAferDrag = transform;
        }
    }

    public void Update()
    {
        if (transform.childCount == 0)
        {
          Destroy(gameObject);
          CookingPan.GetComponent<CookingPan>().Anim.SetBool("Cooking", false);
          CookingPan.GetComponent<CookingPan>().Cooking = false;
        }
    }
}
