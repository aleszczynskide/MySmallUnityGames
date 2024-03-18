using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEditor.Experimental.GraphView;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Image image;
    [HideInInspector] public Transform ParentAferDrag;
    public Item item;
    public FridgeSlot FridgeSlot;
    public InventorySlot InventorySlot;
    public GameObject InventoryManager;
    public Item[] FridgeItems;
    public GameObject Fridge;
    public void Start()
    {
        InventoryManager = GameObject.Find("InventoryManager");
        Fridge = GameObject.Find("FridgeInventory");
        CreateItem(item);
    }
    public void CreateItem(Item NewItem)
    {
        item = NewItem;
        image.sprite = NewItem.Image;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        ParentAferDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(ParentAferDrag);
        image.raycastTarget = true;
    }

    public void QuickInventorySLots()
    {
        if (transform.parent.name == "InventorySlot" && Fridge.activeSelf == true)
        {
            if (Input.GetKey("left shift") && item == FridgeItems[0])
            {
                for (int i = 0; i < InventoryManager.GetComponent<InventoryManager>().FridgeSlots.Length; i++)
                {
                    if (InventoryManager.GetComponent<InventoryManager>().FridgeSlots[i].transform.childCount == 0)
                    {
                        FridgeSlot = InventoryManager.GetComponent<InventoryManager>().FridgeSlots[i];
                        InventoryManager.GetComponent<InventoryManager>().SpawnFridgeNewItem(item, FridgeSlot);
                        Destroy(gameObject);
                        break;
                    }
                }
            }
            else
            {
                Debug.Log("W³¹cz lodówkê");
            }
        }
        else if (transform.parent.name == "FridgeSlot")
        {
            if (Input.GetKey("left shift") && item == FridgeItems[0])
            {
                for (int i = 0; i < InventoryManager.GetComponent<InventoryManager>().InventorySlots.Length; i++)
                {
                    if (InventoryManager.GetComponent<InventoryManager>().InventorySlots[i].transform.childCount == 0)
                    {
                        InventorySlot = InventoryManager.GetComponent<InventoryManager>().InventorySlots[i];
                        InventoryManager.GetComponent<InventoryManager>().SpawnNewItem(item, InventorySlot);
                        Destroy(gameObject);
                        break;
                    }
                }
            }
        }
    }
}
