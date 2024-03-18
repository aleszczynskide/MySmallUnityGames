using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    public Sprite One, TwoLine, ThreeLine, FourLine, TwoUpDown, ThreeUpDown, FourUpDown;
    SpriteRenderer spr;
    public float speed = 5f;
    public int zmienna;
    public GameObject Switcher;
    private bool Dance = true;
    private bool Vanish = true;
    private void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        Switcher = GameObject.FindGameObjectWithTag("Switcher");
    }

    private void FixedUpdate()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = Camera.main.transform.position.z + Camera.main.nearClipPlane;
        transform.position = mousePosition;

    }
    private void Update()
    {
        if (!Switcher.GetComponent<Switcher>().Switching())
        {
            Dance = true;
        }
        if (Switcher.GetComponent<Switcher>().Switching())
        {
            Dance = false;
        }
        if (Dance && !Vanish)
        {
            switch (zmienna)
            {
                case 1: this.spr.sprite = One; break;
                case 2: this.spr.sprite = TwoUpDown; break;
                case 3: this.spr.sprite = ThreeUpDown; break;
                case 4: this.spr.sprite = FourUpDown; break;
            }
        }
        else if (!Dance && !Vanish)
        {
            switch (zmienna)
            {
                case 1: this.spr.sprite = One; break;
                case 2: this.spr.sprite = TwoLine; break;
                case 3: this.spr.sprite = ThreeLine; break;
                case 4: this.spr.sprite = FourLine; break;
            }

        }
    }
    public void AppearUpDown(int x)
    {
        zmienna = x;
    }

    public void VanishPointer()
    {
        this.spr.sprite = null;
        Vanish = true;
    }
    public void CreatePointer()
    {
        Vanish = false;
    }
}
