using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BeerTap : MonoBehaviour
{
    private bool InPlace = false;
    private bool Pouring = false;
    private bool Poured = false; //Sprawdza czy Player jest przy kadzi / Sprawdza,czy piwo jest lane / Czy piwo jest nalane
    public int BeerAmount = 100, BeerPour = 0; //Iloœæ piwa w beczce / ilosæ nalanego piwa do kubka
    private int SwitchSwitcher = 0; //Zmienna nadaj¹ca wartoœæ danej kadzi piwa
    public Item[] Item; //Lista piw
    private Animator Anim; // Animator
    public GameObject Pointer; //Znak do pokazywania interakcji z kadzi¹  / Obiekt to pokazywania piwa
    private GameObject PointerPointer, PouredPointer, BeerPointer; //Zmienna do organizowania wskaŸnika
    public InventoryManager Inventory; // Klasa InventoryManager
    public GameObject[] BeerPointers; // Znaczki piw do pokazywania
    private void Start()
    {
        switch (this.name)
        {
            case "Beer1":
                {
                    SwitchSwitcher = 0;
                }
                break;
            case "Beer2":
                {
                    SwitchSwitcher = 1;
                }
                break;
            case "Beer3":
                {
                    SwitchSwitcher = 2;
                }
                break;
        }
        Anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.gameObject.CompareTag("Player"))
        {
            InPlace = true;
            if (!Pouring)
            {
                PointerPointer = Instantiate(Pointer, new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z), Quaternion.identity);
            }
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            InPlace = false;
            Destroy(PointerPointer);
        }
    }
    private void Update()
    {
        if (InPlace && !Poured)
        {
            if (Input.GetKeyDown("space"))  //Lanie piwa
            {
                Anim.SetBool("Beer", true);
                Destroy(PointerPointer);
                Pouring = true;
            }
        }
        if (BeerPour == 2 && !Poured)
        {
            BeerPointer = Instantiate(BeerPointers[SwitchSwitcher], new Vector3(transform.position.x, transform.position.y - 0.2f, transform.position.z), Quaternion.identity);
            PouredPointer = Instantiate(Pointer, new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z), Quaternion.identity);
            Poured = true;
        }

        if (BeerPour > 3)
        {
            {
                Anim.SetBool("Overflow", true);
            }
        }
        if (InPlace && Poured)
        {
            if (Input.GetKeyDown("space"))
            {
                Anim.SetBool("Beer", false);
                Anim.SetBool("Overflow", false);
                Pouring = false;
                Poured = false;
                Destroy(PouredPointer);
                Destroy(BeerPointer);
                Inventory.AddItem(Item[SwitchSwitcher]);
                BeerPour = 0;
            }
        }
    }
    public void PourBeer() //Zmiana zawartoœci piwa w kadzi i w kubku
    {
        if (BeerAmount > 0)
        {
            BeerAmount -= 1;
            BeerPour += 1;
        }
        else if (BeerAmount <= 0)
        {
            Anim.SetBool("Beer", false);
        }
    }
    public void CheckBeerAmount()
    {
       if(BeerAmount == 0)
        {
            Anim.SetBool("Beer", false);
        }
    }
}
