using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class FireWitchScript : MonoBehaviour
{
    private int Xposition, Yposition, ShipNumber;
    private float PositionX, PositionY;
    public GameObject controller;
    public bool Killer = true;
    private BoxCollider2D box;
    private Animator anim;
    public AudioSource DeathAudioSource;

    private void Start()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");
        box = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }
    public void SetCords(int a, int b)
    {

        Xposition = a;
        Yposition = b;

        PositionX = a;
        PositionY = b;

        PositionX *= 0.48f;
        PositionY *= 0.48f;

        PositionX += 2f;
        PositionY += 2f;

        Debug.Log(PositionX + PositionY);

        transform.position = new Vector3(PositionX, PositionY, -1);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("FireBall") && Killer)
        {
            Killer = false;
            controller.GetComponent<Controller>().FireLife -= 1;
            box.enabled = false;
            anim.SetTrigger("Death");
            DeathAudioSource.Play();
        }
    }
}
