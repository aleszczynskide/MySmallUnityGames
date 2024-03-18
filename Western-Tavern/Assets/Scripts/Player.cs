using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    public int MovementSpeed = 5;
    private bool TrashCollider;
    private GameObject Trash;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        float DirectX = Input.GetAxisRaw("Horizontal");
        float DirectY = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2 (DirectX * MovementSpeed, DirectY * MovementSpeed);

        if (Input.GetKeyDown("space") && TrashCollider)
        {
            Destroy(Trash);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Trash"))
        {
            TrashCollider = true;
            Debug.Log("Œmieæ");
            Trash = collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Trash"))
        {
            TrashCollider = false;
            Trash = null;
        }
    }
}
