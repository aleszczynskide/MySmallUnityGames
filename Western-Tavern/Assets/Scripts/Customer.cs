using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Customer : MonoBehaviour
{
    public GameObject Toilet;
    public int CustomerSex;
    bool BeerSpawner = true,FoodSpawner = true,ToiletOccupied = true;
    private GameObject ItemToOrder;//Zmienna do zniszczenia piwa
    public List<GameObject> OrderedBeer;//Lista zamówionego piwa w zale¿noœci od CustomerID
    public List<GameObject> OrderedFood;//Lista zamówionego piwa w zale¿noœci od CustomerID
    public int CustomerID;//Zmienna do zachowania klienta
    public GameObject MyCustomer;//Obiekt klient
    public GameObject Door;//Miejsce do koñca algorytmu klienta
    private GameObject GameManager,NewTrash; //Zmienna do namierzenia GameManager
    public GameObject Canvas; // Obiekt do wrzucenia Canvasu Klienta
    public GameObject CustomerCanvasPrefab; // Prefab Canvasu do u¿ywania jedzenia i picia
    private GameObject CustomerCanvasInstance; // Instancja obecnie aktywnego Canvas
    private bool GivingOrder = false; // Zmienna do sprawdzania czy mo¿na przyj¹æ zamówienie
    public Transform CurrentPosition;
    public SeekerMovement SeekerMovement;
    private Animator Anim;
    public Transform Chair;
    public GameObject ChairLayer;
    public int Popularity = 3;
    public GameObject Trash;

    private void Start()
    {
        Canvas = GameObject.FindGameObjectWithTag("Canvas");
        Anim = GetComponent<Animator>();
        Door = GameObject.FindGameObjectWithTag("Door");
        GameManager = GameObject.Find("GameManager");
        ChairLayer = Chair.gameObject;
        string DefaultLayer = "Default";
        int NewLayerIndex = LayerMask.NameToLayer(DefaultLayer);
        ChairLayer.layer = NewLayerIndex;

    }

    private void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
         {
            if (GivingOrder)
            {
                Vector3 canvasPosition = CurrentPosition.position + Vector3.up * 0.2f; // Przesuniêcie 0.1f w górê
                Vector2 screenPosition = Camera.main.WorldToScreenPoint(canvasPosition);
                CustomerCanvasInstance = Instantiate(CustomerCanvasPrefab);
                CustomerCanvasInstance.transform.SetParent(Canvas.transform, false);
                CustomerCanvasInstance.GetComponent<RectTransform>().position = screenPosition;
                CustomerCanvasInstance.GetComponent<ClientSlot>().Customer = MyCustomer;
                CustomerCanvasInstance.GetComponent<ClientSlot>().OrderedBeer = CustomerID;
            }
        }
        if (collision.gameObject.CompareTag("Door"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Trash"))
        {
            if (Popularity >= 1)
            {
                Debug.Log("Wszed³ " + Popularity);
                Popularity -= 1;
            }
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (CustomerCanvasInstance != null)
            {
                Destroy(CustomerCanvasInstance);
            }
        }
    }
    public void Ordering()
    {
        if (CustomerID <= 2)
        {
            if (BeerSpawner)
            {
                string DefaultLayer = "Obstacle";
                int NewLayerIndex = LayerMask.NameToLayer(DefaultLayer);
                ChairLayer.layer = NewLayerIndex;
                BeerSpawner = false;
                ItemToOrder = Instantiate(OrderedBeer[CustomerID], new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z), Quaternion.identity);
                GivingOrder = true;
                Anim.SetBool("Sitting", true);
                transform.position = SeekerMovement.PlayerToFollow.position;
                if (SeekerMovement != null)
                {
                    SeekerMovement.PlayerToFollow = Chair;
                }
            }
        }
       else if (CustomerID > 2 && CustomerID <= 5)
        {
            if (FoodSpawner)
            {
                string DefaultLayer = "Obstacle";
                int NewLayerIndex = LayerMask.NameToLayer(DefaultLayer);
                ChairLayer.layer = NewLayerIndex;
                FoodSpawner = false;
                ItemToOrder = Instantiate(OrderedFood[CustomerID - 3], new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z), Quaternion.identity);
                GivingOrder = true;
                Anim.SetBool("Sitting", true);
                transform.position = SeekerMovement.PlayerToFollow.position;
                if (SeekerMovement != null)
                {
                    SeekerMovement.PlayerToFollow = Chair;
                }
            }
        }
       else if (CustomerID > 5)
        {
            if (ToiletOccupied)
            {
                ToiletOccupied = false;
                Anim.SetBool("Toilet", true);
                transform.position = SeekerMovement.PlayerToFollow.position;
                if (SeekerMovement != null)
                {
                    SeekerMovement.PlayerToFollow = Chair;
                }
            }
        }
    }

    public void OrderReceived()
    {
        GivingOrder = false;
        if (CustomerID <= 2)
        {
            Anim.SetBool("Drinking", true);
        }
      else   if (CustomerID > 2 && CustomerID <= 5)
        {
            Anim.SetBool("Eating", true);
        }
    }
    public void OrderEaten()
    {
        Anim.SetBool("Sitting", false);
        Destroy(ItemToOrder);
        BeerSpawner = false;
        FoodSpawner = false;
        ToiletOccupied = false;
        GivingOrder = false;
        Transform DoorTransform = Door.transform;
        SeekerMovement.PlayerToFollow = DoorTransform;
        SeekerMovement.Movement = true;
        GameManager.GetComponent<GameManager>().Popularity += Popularity;
        if (CustomerID <= 2)
        {
            if (GameManager != null)
            {
                GameManager.GetComponent<GameManager>().FreeBarChairs.Add(Chair);
            }
        }
      else if (CustomerID > 2 && CustomerID <= 5)
        {
            if (GameManager != null)
            {
                GameManager.GetComponent<GameManager>().FreeFoodChairs.Add(Chair);
            }
        }
    }
    public void LeaveToilet()
    {
        BeerSpawner = true;
        FoodSpawner = true;
        ToiletOccupied = true;
        GivingOrder = false;
        Anim.SetBool("Toilet", false);
        Transform DoorTransform = Door.transform;
        SeekerMovement.PlayerToFollow = DoorTransform;
        SeekerMovement.Movement = true;
        if ( CustomerSex == 1)
        {
            if (GameManager != null)
            {
                GameManager.GetComponent<GameManager>().MaleToilet.Add(Chair);
            }
        }
        if (CustomerSex == 2)
        {
            if (GameManager != null)
            {
                GameManager.GetComponent<GameManager>().FemaleToilet.Add(Chair);
            }
        }
    }
    public void PopularityDown()
    {
        if (Popularity >= 1)
        {
            Popularity -= 1;
        }
       
    }
    public void SpawnTrash()
    {
        int x = Random.Range(0, 101);
        if (x >= 80)
        {
          //  NewTrash = Instantiate(Trash, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        }     
    }
    public void ActivateTrash()
    {
        if (NewTrash != null)
        {
            //NewTrash.SetActive(true);
        }  
    }
}
