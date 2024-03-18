using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodCreator : MonoBehaviour
{
    public List<Sprite>BeerList;
    public List<Sprite> FoodList;
    private SpriteRenderer Sprite;

    private void Awake()
    {
       Sprite = GetComponent<SpriteRenderer>();
    }

    public void ChangeBeerSprite(int id)
    {
        Sprite.sprite = BeerList[id];
    }
}
