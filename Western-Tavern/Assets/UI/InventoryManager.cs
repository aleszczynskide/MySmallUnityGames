using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class InventoryManager : MonoBehaviour
{
    public InventorySlot[] InventorySlots;
    public FridgeSlot[] FridgeSlots;
    public Item[] RawSteakMeat;
    public GameObject InventoryItemPrefab;
    public Text RawSteakText;
    public int PlaceInTheFridge = 0;

    public void AddItem(Item Item)
    {
        for (int i = 0; i < InventorySlots.Length; i++)
        {
            InventorySlot Slot = InventorySlots[i];
            InventoryItem ItemInSlot = Slot.GetComponentInChildren<InventoryItem>();
            if (ItemInSlot == null)
            {
                SpawnNewItem(Item, Slot);
                return;
            }
        }
    }

    public void SpawnNewItem(Item item, InventorySlot Slot)
    {
        GameObject NewObject = Instantiate(InventoryItemPrefab, Slot.transform);
        InventoryItem InventoryItem = NewObject.GetComponent<InventoryItem>();
        InventoryItem.CreateItem(item);
    }
    public void SpawnFridgeNewItem(Item item, FridgeSlot Slot)
    {
        GameObject NewObject = Instantiate(InventoryItemPrefab, Slot.transform);
        InventoryItem inventoryItem = NewObject.GetComponent<InventoryItem>();
        inventoryItem.CreateItem(item);
    }

    public void AddRawSteak(int x)
    {
        for (int i = 0; i < FridgeSlots.Length; i++)
        {
            FridgeSlot Slot = FridgeSlots[i];
            InventoryItem ItemInSlot = Slot.GetComponentInChildren<InventoryItem>();
            if (ItemInSlot == null)
            {
                SpawnFridgeNewItem(RawSteakMeat[x], Slot);
                UpdateFridge();
                return;
            }
        }
    }
    public void UpdateFridge()
    {
        PlaceInTheFridge = 0;
        for (int i = 0; i < FridgeSlots.Length; i++)
        {
            if (FridgeSlots[i].transform.childCount >= 1)
            {
                PlaceInTheFridge += 1;
            }
            else if (FridgeSlots[i].transform.childCount == 0)
            {
                PlaceInTheFridge += 0;
            }
            RawSteakText.text = PlaceInTheFridge + "/27";
        }
    }
}