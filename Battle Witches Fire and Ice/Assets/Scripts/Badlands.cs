using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Badlands : MonoBehaviour
{
    public Sprite One, Two, Three;
    SpriteRenderer spr;
    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        int a = Random.Range(1, 3);
        switch (a)
        {
            case 1: spr.sprite = One; break;
            case 2: spr.sprite = Two; break;
            case 3: spr.sprite = Three; break;
        }
    }
}
