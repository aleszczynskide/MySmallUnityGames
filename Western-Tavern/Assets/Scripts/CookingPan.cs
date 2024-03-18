using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class CookingPan : MonoBehaviour
{
    public bool Cooking = false, InPlace = false;
    private GameObject FoodCanvas;
    public InventorySlot InventorySlot;
    public Transform CurrentPosition;
    public GameObject FoodCanvasPrefab;
    public GameObject Canvas;
    public GameObject IncentoryItem;
    [HideInInspector] public Animator Anim;
    public List<Item> CookedIems;
    public List<Item> BurnedIems;
    public int CookedItem;
    private GameObject FoodCanvasInstance, CookedFoodCanvas;
    public GameObject CookedFoodPlate;

    private void Start()
    {
        Canvas = GameObject.FindGameObjectWithTag("Canvas");
        Anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (InPlace && CookedFoodCanvas != null)
        {
            CookedFoodCanvas.SetActive(true);
        }
        else if (!InPlace && CookedFoodCanvas != null)
        {
            CookedFoodCanvas.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            InPlace = true;
            if (!Cooking)
            {

                Vector3 CanvasPosition = CurrentPosition.position + Vector3.up * 0.2f; //Offset dla RectTransform
                Vector2 ScreenPosition = Camera.main.WorldToScreenPoint(CanvasPosition);
                FoodCanvasInstance = Instantiate(FoodCanvasPrefab);
                FoodCanvasInstance.transform.SetParent(Canvas.transform, false);
                FoodCanvasInstance.GetComponent<RectTransform>().position = ScreenPosition;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            InPlace = false;
            Destroy(FoodCanvasInstance);
        }
    }
    public void ItemCooked()
    {
        Vector3 CanvasPosition = CurrentPosition.position + Vector3.up * 0.2f; //Offset dla RectTransform
        Vector2 ScreenPosition = Camera.main.WorldToScreenPoint(CanvasPosition);
        CookedFoodCanvas = Instantiate(CookedFoodPlate);
        CookedFoodCanvas.transform.SetParent(Canvas.transform, false);
        CookedFoodCanvas.GetComponent<RectTransform>().position = ScreenPosition;

        SpawnNewItem(CookedIems[CookedItem], CookedFoodCanvas);
    }

    public void SpawnNewItem(Item item, GameObject slot)
    {
        GameObject NewObject = Instantiate(IncentoryItem, slot.transform);
        InventoryItem inventoryItem = NewObject.GetComponent<InventoryItem>();
        inventoryItem.CreateItem(item);
    }

    public void BurnedFood()
    {
        Destroy(CookedFoodCanvas);
        Vector3 CanvasPosition = CurrentPosition.position + Vector3.up * 0.2f; //Offset dla RectTransform
        Vector2 ScreenPosition = Camera.main.WorldToScreenPoint(CanvasPosition);
        CookedFoodCanvas = Instantiate(CookedFoodPlate);
        CookedFoodCanvas.transform.SetParent(Canvas.transform, false);
        CookedFoodCanvas.GetComponent<RectTransform>().position = ScreenPosition;

        SpawnNewItem(BurnedIems[CookedItem], CookedFoodCanvas);
        Anim.SetBool("Cooking", false);
    }
}
