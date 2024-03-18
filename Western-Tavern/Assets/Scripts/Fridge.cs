using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fridge : MonoBehaviour
{
    private bool InPlace;
    public GameObject Pointer;
    private GameObject PointerStatus;
    public GameObject FridgeInventory,ExitFrideButton,ToolBar;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            InPlace = true;
            PointerStatus = Instantiate(Pointer, new Vector2(transform.position.x, transform.position.y + 0.2f), Quaternion.identity);
        }
     
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            InPlace = false;
            Destroy(PointerStatus);
        }
    }

    public void Update()
    {
        if (InPlace && Input.GetKeyDown("space"))
        {
            FridgeInventory.SetActive(true);
            ExitFrideButton.SetActive(true);

        }
    }
}
