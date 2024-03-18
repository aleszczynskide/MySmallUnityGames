using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class ClientSlot : MonoBehaviour, IDropHandler
{
    private GameObject GameManager;
    public List<Item> WantedItem;
    public Transform NewPosition;
    public GameObject Customer;
    public int OrderedBeer;

    void Start()
    {
       GameManager = GameObject.Find("GameManager");
    }
    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        InventoryItem inventoryItem = dropped.GetComponent<InventoryItem>();
        inventoryItem.ParentAferDrag = transform;
        Destroy(dropped);
        int x = OrderedBeer;
        if (inventoryItem != null)
        {
            if (inventoryItem.item == WantedItem[x])
            {
                Debug.Log("Dzia³a");
                Customer.GetComponent<Customer>().OrderReceived();
                if (x == 0)
                {
                    GameManager.GetComponent<GameManager>().Money += 0.3f;
                }
                else
                {
                    GameManager.GetComponent<GameManager>().Money += (x * 0.4f);
                }
                Destroy(gameObject);
            }
            else
            {
                Debug.Log("Zdech³");
            }
        }
    }
}
