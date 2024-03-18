using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CashRegister : MonoBehaviour
{
    public GameObject Pointer;
    private GameObject NewPointer;
    private bool InPlace;
    public GameObject CashRegisterBoard;
    public GameObject InventoryManager;

    public void Start()
    {
        InventoryManager = GameObject.Find("InventoryManager");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            InPlace = true;
           NewPointer = Instantiate(Pointer,new Vector2(transform.position.x,transform.position.y + 0.2f),Quaternion.identity);
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            InPlace = false;
           Destroy(NewPointer);
        }
    }

    public void Update()
    {
        if (InPlace && Input.GetKeyDown("space"))
        {
            CashRegisterBoard.SetActive(true);
            InventoryManager.GetComponent<InventoryManager>().UpdateFridge();
        }
    }
}
