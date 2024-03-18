using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    public GameObject GameManager;
    private Animator Anim;
    public GameObject StartShiftButton;
    public GameObject CashRegister;
    void Start()
    {
        GameObject GameManager = GameObject.Find("GameManager");
        Anim = GetComponent<Animator>();
    }
    void Update()
    {

    }
    void SpawnCustomer()
    {
        GameManager.GetComponent<GameManager>().GenerateCustomer();
    }

    public void StartShift(int x)
    {
        Debug.Log("Krokodyl");
        Anim.SetInteger("Popularity", x);
    }

    public void EndShift()
    {
        Anim.SetInteger("Popularity",0);
        StartShiftButton.SetActive(true);
        CashRegister.SetActive(true);
    }
}
