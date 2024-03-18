using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Witch : MonoBehaviour
{
    private Animator anim;
    private int Xposition, Yposition, ShipNumber;
    private float PositionX, PositionY;
    private GameObject controller;
    public bool Killer = true;
    private BoxCollider2D box;
    public AudioSource DeathAudioSource;

    private void Start()
    {
        anim = GetComponent<Animator>();
        controller = GameObject.FindGameObjectWithTag("GameController");
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

        transform.position = new Vector3(PositionX, PositionY, -1);
    }

    private void OnMouseDown()
    {

        if (controller.GetComponent<Controller>().IceBaby())
        {
            controller.GetComponent<Controller>().CreateAttackPlate();
        }
;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("FireBall") && Killer)
        {
            Killer = false;
            controller.GetComponent<Controller>().IceLife -= 1;
            anim.SetTrigger("Death");
            DeathAudioSource.Play();
            box.enabled = false;
           
        }
    }
}
