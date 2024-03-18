using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("OrderingElements")]
    public List<Transform> FreeBarChairs; //Lista wolnych krzese³ w barze
    public List<Transform> FreeFoodChairs; //Lista wolnych krzese³ w jadalni
    public List<Transform> MaleToilet; //Lista wolnych krzese³ w jadalni
    public List<Transform> FemaleToilet; //Lista wolnych krzese³ w jadalni
    [Header("GameElements")]
    public Text MoneyText,PopularityText;
    public int Popularity;
    public int PopularityLevel = 1;
    [HideInInspector] public float Money = 0f; //Zmienna do przechowywania pieniêdzy
    [Header("Unsorted")]
    private int CustomerID; //Identyfikator klienta
    public GameObject Chair; //Prefabrykat krzese³
    public GameObject BarClient; //Prefabrykat klienta baru
    public GameObject Clock;//Odnoœnik do zegara
    public GameObject ExitButton, Fridge;

    void Start()
    {
        Clock Clock = GetComponent<Clock>();
        ExitButton.SetActive(false);
        Fridge.SetActive(false);
    }
    void Update()
    {
        Money = Mathf.Round(Money * 100f) / 100f;
        MoneyText.text = "" + Money;
        PopularityText.text = "" + PopularityLevel;
        if (Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (PopularityLevel * 30 <= Popularity)
        {
            Popularity = 0;
            PopularityLevel += 1;
        }
        Debug.Log(Popularity);
    }

   public void StartShift()
    {
        Clock.GetComponent<Clock>().StartShift(PopularityLevel);
    }

    public void GenerateCustomer()
    {
        int x = Random.Range(0, 8);
        int y = Random.Range(1, 3);
        Debug.Log(x +" " + y);

        switch (x)
        {
            case 0:
                {
                    GenerateBarCustomer(x,y);
                }
                break;
            case 1:
                {
                    GenerateBarCustomer(x,y);
                }
                break;
            case 2:
                {
                    GenerateBarCustomer(x,y);
                }
                break;
            case 3:
                {
                    GenerateFoodCustomer(x,y);
                   
                }
                break;
            case 4:
                {
                    GenerateFoodCustomer(x,y);
                   
                }
                break;
            case 5:
                {
                    GenerateFoodCustomer(x,y);
                }
                break;
            case 6:
                {
                    GenerateToiletCustomer(x, y);
                }
                break;
            case 7:
                {
                    GenerateToiletCustomer(x, y);
                }
                break;
        }
    }


    public void GenerateChairs()
    {
        float x =  Random.Range(0.9403696f, 14.39f);
        float y =  Random.Range(9.015768f, 14.16f);

        for (int i = 0; i< FreeBarChairs.Count; i++)
        {
            Debug.Log(FreeBarChairs[i]);
        }

        GameObject NewChair = Instantiate(Chair, new Vector3(0, 0, 0), Quaternion.identity);
        NewChair.transform.position = new Vector3(x,y, 1);
        Transform ChairTransform = NewChair.transform;
        FreeBarChairs.Add(ChairTransform);
    }

    public void GenerateBarCustomer(int x,int y)
    {
        if (FreeBarChairs.Count > 0)
        {
            int RandomChairIndex = Random.Range(0, FreeBarChairs.Count); 
            GameObject NewClient = Instantiate(BarClient, new Vector3(9.703f, 6.53f, transform.position.z), Quaternion.identity);
            NewClient.GetComponent<SeekerMovement>().PlayerToFollow = FreeBarChairs[RandomChairIndex];
            NewClient.GetComponent<SeekerMovement>().Customer = NewClient;
            NewClient.GetComponent<Customer>().SeekerMovement = NewClient.GetComponent<SeekerMovement>();
            NewClient.GetComponent<Customer>().MyCustomer = NewClient;
            NewClient.GetComponent<Customer>().Chair = FreeBarChairs[RandomChairIndex];
            NewClient.GetComponent<Customer>().CustomerID = x;
            NewClient.GetComponent<Customer>().CustomerSex = y;
            FreeBarChairs.RemoveAt(RandomChairIndex);
        }
        else
        {
            Debug.Log("Brak Wolnych Miejsc");
        }
    }

    public void GenerateFoodCustomer(int x, int y)
    {
        if (FreeFoodChairs.Count > 0)
        {
            int RandomChairIndex = Random.Range(0, FreeFoodChairs.Count); //  Losowanie indeksu krzes³a
            GameObject NewClient = Instantiate(BarClient, new Vector3(9.703f, 6.53f, transform.position.z), Quaternion.identity);
            NewClient.GetComponent<Customer>().Chair = FreeFoodChairs[RandomChairIndex];
            NewClient.GetComponent<SeekerMovement>().PlayerToFollow = FreeFoodChairs[RandomChairIndex];
            NewClient.GetComponent<SeekerMovement>().Customer = NewClient;
            NewClient.GetComponent<Customer>().SeekerMovement = NewClient.GetComponent<SeekerMovement>();
            NewClient.GetComponent<Customer>().MyCustomer = NewClient;      
            NewClient.GetComponent<Customer>().CustomerID = x;
            NewClient.GetComponent<Customer>().CustomerSex = y;
            FreeFoodChairs.RemoveAt(RandomChairIndex); // Usuñ wybrane krzes³o z listy dostêpnych krzese³
        }
        else
        {
            Debug.Log("Brak Wolnych Miejsc");
        }
    }
    public void GenerateToiletCustomer(int x,int y)
    {
        switch (y)
        {
            case 1:
                {
                    int RandomChairIndex = Random.Range(0, MaleToilet.Count); //  Losowanie indeksu krzes³a
                    GameObject NewClient = Instantiate(BarClient, new Vector3(9.703f, 6.53f, transform.position.z), Quaternion.identity);
                    NewClient.GetComponent<SeekerMovement>().PlayerToFollow = MaleToilet[RandomChairIndex];
                    NewClient.GetComponent<SeekerMovement>().Customer = NewClient;
                    NewClient.GetComponent<Customer>().SeekerMovement = NewClient.GetComponent<SeekerMovement>();
                    NewClient.GetComponent<Customer>().MyCustomer = NewClient;
                    NewClient.GetComponent<Customer>().Chair = MaleToilet[RandomChairIndex];
                    NewClient.GetComponent<Customer>().CustomerID = x;
                    NewClient.GetComponent<Customer>().CustomerSex = y;
                    MaleToilet.RemoveAt(RandomChairIndex); // Usuñ wybrane krzes³o z listy dostêpnych krzese³
                }
                break;
            case 2:
                {
                    int RandomChairIndex = Random.Range(0, FemaleToilet.Count); //  Losowanie indeksu krzes³a
                    GameObject NewClient = Instantiate(BarClient, new Vector3(9.703f, 6.53f, transform.position.z), Quaternion.identity);
                    NewClient.GetComponent<SeekerMovement>().PlayerToFollow = FemaleToilet[RandomChairIndex];
                    NewClient.GetComponent<SeekerMovement>().Customer = NewClient;
                    NewClient.GetComponent<Customer>().SeekerMovement = NewClient.GetComponent<SeekerMovement>();
                    NewClient.GetComponent<Customer>().MyCustomer = NewClient;
                    NewClient.GetComponent<Customer>().Chair = FemaleToilet[RandomChairIndex];
                    NewClient.GetComponent<Customer>().CustomerID = x;
                    NewClient.GetComponent<Customer>().CustomerSex = y;
                    FemaleToilet.RemoveAt(RandomChairIndex); // Usuñ wybrane krzes³o z listy dostêpnych krzese³
                }
                break;
            default:
                {
                    Debug.Log("BrakWolnychKibli");
                }break;
        }
    }
}
