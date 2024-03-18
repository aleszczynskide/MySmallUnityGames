using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switcher : MonoBehaviour
{
    public Sprite Line, UpDown;
    public bool Switch = false;
    SpriteRenderer spr;
    private void Start()
    {
        spr = GetComponent<SpriteRenderer>();   
    }

    private void Update()
    {
       
    }
    private void OnMouseDown()
    {
        Switch = !Switch;
        if (Switch)
        {
            this.spr.sprite = Line;
        }
        else if (!Switch)
        {
            this.spr.sprite = UpDown;   
        }
    }

    public bool Switching()
    {
        return Switch;
    }
}
