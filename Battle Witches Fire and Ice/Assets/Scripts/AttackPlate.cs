using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlate : MonoBehaviour
{
    private Animator anim;
    private int Xposition, Yposition, ShipNumber;
    private float PositionX, PositionY;
    public GameObject controller,iceball;

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

    public void OnMouseDown()
    {
        Instantiate(iceball, new Vector3((Xposition * 0.48f) + 2f , (Yposition * 0.48f ) + 2f, -1), Quaternion.identity);
        controller.GetComponent<Controller>().BattlePositionsDestroy(Xposition, Yposition);
        DestroyAttackPlate();
        controller.GetComponent<Controller>().EnemyAttack();
        

    }
    public void DestroyAttackPlate()
    {
        GameObject[] AttackPlates = GameObject.FindGameObjectsWithTag("AttackPlate");
        for (int a = 0; a < AttackPlates.Length; a++) 
        {
            Destroy(AttackPlates[a]);
        }
    }
}
