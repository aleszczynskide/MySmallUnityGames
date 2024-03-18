using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tester : MonoBehaviour
{
  public float Xmove, Ymove;
    public Rigidbody2D rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Xmove = Input.GetAxis("Horizontal");
        Ymove = Input.GetAxis("Vertical");
        rb.velocity = new Vector2 (Xmove, Ymove);

    }
}
