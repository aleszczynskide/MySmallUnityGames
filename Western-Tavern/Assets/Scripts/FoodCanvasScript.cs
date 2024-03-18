using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class FoodCanvasScript : MonoBehaviour, IDropHandler
{
    public Image Image;
    public Item Item;
    public List<Item> ItemsToCook;
    private GameObject Dropped, CookedItem;
    [HideInInspector] public int CookedItemId;
    public GameObject CookingPan;

    private void Start()
    {
        CookingPan = GameObject.Find("CookingPan");
        Image = GetComponent<Image>();
    }
    public void OnDrop(PointerEventData eventData)
    {
        GameObject Dropped = eventData.pointerDrag;
        InventoryItem InventoryItem = Dropped.GetComponent<InventoryItem>();
        for (int i = 0; i < ItemsToCook.Count; i++)
        {
            if (InventoryItem.item == ItemsToCook[i])
            {
                CookedItemId = i;
                InventoryItem.ParentAferDrag = transform;
                Destroy(Dropped);
                CookingPan.GetComponent<CookingPan>().Anim.SetBool("Cooking", true);
                CookingPan.GetComponent<CookingPan>().Cooking = true;
                CookingPan.GetComponent<CookingPan>().CookedItem = i;
                Destroy(gameObject);
            }
        }
    }
}
