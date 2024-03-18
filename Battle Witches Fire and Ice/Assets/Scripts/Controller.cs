using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    public int[,] Positions = new int[15, 7];
    public int[,] BattlePositions = new int[15, 7];
    public int IceWitches = 5;
    public int FireWitches = 5;
    private int IceSpawn = 14;
    public int FireSpawn = 5;
    private int OneShip = 3;
    private int TwoShip = 2;
    private int ThreeShip = 1;
    private int FourShip = 1;
    public bool Ice = true;
    public int IceLife = 14;
    public int FireLife = 14;
    public bool Battle = true;
    public GameObject PlateSpawner, Witch, Spawner, FireWitch, AttackPlate, Fireball,Iceball,Reset;
    public GameObject Pointer, Spawner1, Spawner2, Spawner3, Spawner4;
   public  Text BattleText,PlaceingText,One,Two,Three,Four,FireWitchesText;

    private void Start()
    {
        Pointer = GameObject.FindGameObjectWithTag("Pointer");
        Spawner1 = GameObject.FindGameObjectWithTag("Spawner1");
        Spawner2 = GameObject.FindGameObjectWithTag("Spawner2");
        Spawner3 = GameObject.FindGameObjectWithTag("Spawner3");
        Spawner4 = GameObject.FindGameObjectWithTag("Spawner4");


        CreateFireWitches();
    }

    private void Update()
    {

        BattleText.text = "";
        if (OneShip == 0)
        {
            Spawner1.GetComponent<Spawner>().Available = false;
            Spawner1.GetComponent<Spawner>().TurnOff();
        }

        if (TwoShip == 0)
        {
            Spawner2.GetComponent<Spawner>().Available = false;
            Spawner2.GetComponent<Spawner>().TurnOff();
        }

        if (ThreeShip == 0)
        {
            Spawner3.GetComponent<Spawner>().Available = false;
            Spawner3.GetComponent<Spawner>().TurnOff();
        }

        if (FourShip == 0)
        {
            Spawner4.GetComponent<Spawner>().Available = false;
            Spawner4.GetComponent<Spawner>().TurnOff();
        }

        if (IceSpawn == 0 && Ice)
        {
            CreateAttackPlate();
            Ice = false;
        }
        if (IceLife == 0)
        {
            Battle = false;
            Debug.Log("Ice PRzegrywa");
            BattleText.text = "Fire Witches Won!";
            Instantiate(Reset, new Vector3(5.377474f, 4.417979f, -1), Quaternion.identity);
        }
        else if (FireLife == 0)
        {
            Battle = false;
            Debug.Log("Fire PRzegrywa");
            BattleText.text = "Ice Witches Won!";
            Instantiate(Reset, new Vector3(5.377474f, 4.417979f, -1), Quaternion.identity);
        }

        One.text = "" + OneShip;
        Two.text = "" + TwoShip;
        Three.text = "" + ThreeShip;
        Four.text = "" + FourShip;

        FireWitchesText.text = "Fire Witches: " + FireLife;
    }
    public void CreateSpawnPlates(int c)
    {
        for (int a = 0; a < 7; a++)
        {
            for (int b = 0; b < 7; b++)
            {
                if (Positions[a, b] != 1)
                {
                    CreatePlates(a, b, c);
                }
            }
        }
    }
    public void CreatePlates(int a, int b, int c)
    {
        GameObject obj = Instantiate(PlateSpawner, new Vector3(a, b, -1), Quaternion.identity);
        Plate plt = obj.GetComponent<Plate>();
        plt.SetCords(a, b, c);
    }
    public void SetPositions(int a, int b)
    {
        if (a >= 0 && b >= 0 && a < 15 && b < 7)
        {
            Positions[a, b] = 1;

        }
    }
    public void SetBattlePositions(int a, int b)
    {
        if (a >= 0 && b >= 0 && a < 15 && b < 7)
        {
            BattlePositions[a, b] = 2;
        }
    }
    public void SetPositionsb(int a, int b)
    {
        if (a >= 0 && b >= 0 && a < 15 && b < 7)
        {
            Positions[a, b] = 2;

        }
    }
    public void DestroyPlates()
    {
        GameObject[] SpawnPlates = GameObject.FindGameObjectsWithTag("Plate");
        for (int a = 0; a < SpawnPlates.Length; a++)
        {
            Destroy(SpawnPlates[a]);
        }
    }
    public void SpawnIce(int a, int b)
    {
        GameObject obj = Instantiate(Witch);
        Witch wth = obj.GetComponent<Witch>();
        wth.SetCords(a, b);
        Pointer.GetComponent<Pointer>().VanishPointer();
        IceSpawn -= 1;
        Spawner1.GetComponent<Spawner>().Available = true;
        Spawner2.GetComponent<Spawner>().Available = true;
        Spawner3.GetComponent<Spawner>().Available = true;
        Spawner4.GetComponent<Spawner>().Available = true;
        SetBattlePositions(a, b);
    }
    public void CreateFireWitches()
    {
        int a = Random.Range(1,15);
        switch (a)

        {
            case 1:
                {
                    CreateFire(0+ 8 , 0);
                    CreateFire(0 + 8, 3 );
                    CreateFire(0 + 8, 4);
                    CreateFire(0 + 8, 5 );
                    CreateFire(0 + 8, 6 );
                    CreateFire(2 + 8, 0 );
                    CreateFire( 2 + 8, 1);
                    CreateFire( 2 + 8, 4);
                    CreateFire(3 + 8, 6);
                    CreateFire( 4 + 8, 3 );
                    CreateFire( 4 + 8, 6);
                    CreateFire(5 + 8, 1 );
                    CreateFire(5 + 8, 3 );
                    CreateFire( 5 + 8, 6);

                }
                break;
            case 2:
                {
                    CreateFire( 0 + 8, 1 );
                    CreateFire(0 + 8, 3 );
                    CreateFire( 0 + 8, 4 );
                    CreateFire(0 + 8, 6 );
                    CreateFire(1 + 8, 1 );
                    CreateFire( 1 + 8, 6);
                    CreateFire( 2 + 8, 1);
                    CreateFire(3 + 8, 1 );
                    CreateFire( 3 + 8, 3);
                    CreateFire( 3 + 8, 4 );
                    CreateFire(3 + 8, 5);
                    CreateFire(5 + 8, 2);
                    CreateFire( 5 + 8, 4 );
                    CreateFire(5 + 8, 6);

                }
                break;
            case 3:
                {
                    CreateFire( 0 + 8, 1);
                    CreateFire( 0 + 8, 3 );
                    CreateFire( 1 + 8, 5);
                    CreateFire(2 + 8, 5);
                    CreateFire(3 + 8, 1);
                    CreateFire( 3 + 8, 2 );
                    CreateFire( 3 + 8, 3 );
                    CreateFire( 3 + 8, 5);
                    CreateFire( 4 + 8, 5 );
                    CreateFire( 5 + 8, 3 );
                    CreateFire(6 + 8, 0 );
                    CreateFire(6 + 8, 3 );
                    CreateFire(6 + 8, 5);
                    CreateFire(6 + 8, 6 );

                }
                break;
            case 4:
                {
                    CreateFire(0 + 8, 0);
                    CreateFire( 0 + 8, 2);
                    CreateFire( 0 + 8, 3 );
                    CreateFire( 1 + 8, 0);
                    CreateFire(1 + 8, 6 );
                    CreateFire( 2 + 8, 2);
                    CreateFire( 2 + 8, 4 );
                    CreateFire( 2 + 8, 6 );
                    CreateFire(3 + 8, 6);
                    CreateFire(4 + 8, 1);
                    CreateFire(4 + 8, 2);
                    CreateFire(4 + 8, 3 );
                    CreateFire(4 + 8, 6);
                    CreateFire(6 + 8, 4 );

                }
                break;
            case 5:
                {
                    CreateFire(0 + 8, 0);
                    CreateFire(0 + 8, 6);
                    CreateFire( 2 + 8, 0);
                    CreateFire( 2 + 8, 2 );
                    CreateFire(2 + 8, 3 );
                    CreateFire(2 + 8, 4 );
                    CreateFire(2 + 8, 5 );
                    CreateFire(4 + 8, 0);
                    CreateFire(4 + 8, 1);
                    CreateFire(4 + 8, 3 );
                    CreateFire(4 + 8, 5 );
                    CreateFire( 5 + 8, 3);
                    CreateFire(5 + 8, 5 );
                    CreateFire(6 + 8, 5 );

                }
                break;
            case 6:
                {
                    CreateFire(0 + 8, 1 );
                    CreateFire( 0 + 8, 3 );
                    CreateFire(0 + 8, 5 );
                    CreateFire(1 + 8, 1 );
                    CreateFire(1 + 8, 5 );
                    CreateFire(2 + 8, 1);
                    CreateFire(2 + 8, 5);
                    CreateFire( 3 + 8, 3);
                    CreateFire( 3 + 8, 5);
                    CreateFire( 5 + 8, 1);
                    CreateFire(5 + 8, 3);
                    CreateFire( 5 + 8, 4);
                    CreateFire(6 + 8, 1 );
                    CreateFire(6 + 8, 6 );

                }
                break;
            case 7:
                {
                    CreateFire( 0 + 8, 0);
                    CreateFire(0 + 8, 2 );
                    CreateFire(0 + 8, 3 );
                    CreateFire(1 + 8, 6);
                    CreateFire(2 + 8, 2);
                    CreateFire(2 + 8, 6);
                    CreateFire( 3 + 8, 6);
                    CreateFire( 4 + 8, 0);
                    CreateFire( 4 + 8, 4);
                    CreateFire( 4 + 8, 6 );
                    CreateFire(5 + 8, 0);
                    CreateFire( 6 + 8, 0);
                    CreateFire(6 + 8, 3);
                    CreateFire(6 + 8, 4);

                }
                break;
            case 8:
                {
                    CreateFire(0 + 8, 3 );
                    CreateFire(0 + 8, 4 );
                    CreateFire( 0 + 8, 5);
                    CreateFire( 0 + 8, 6);
                    CreateFire(1 + 8, 1 );
                    CreateFire( 2 + 8, 1);
                    CreateFire(2 + 8, 3);
                    CreateFire(2 + 8, 5 );
                    CreateFire(4 + 8, 1);
                    CreateFire(4 + 8, 2 );
                    CreateFire(4 + 8, 4 );
                    CreateFire(4 + 8, 5);
                    CreateFire( 4 + 8, 6 );
                    CreateFire(6 + 8, 3);

                }
                break;
            case 9:
                {
                    CreateFire(0 + 8, 1);
                    CreateFire(0 + 8, 3 );
                    CreateFire(0 + 8, 5 );
                    CreateFire(0 + 8, 6 );
                    CreateFire( 1 + 8, 1);
                    CreateFire( 2 + 8, 1 );
                    CreateFire(3 + 8, 1 );
                    CreateFire(3 + 8, 6 );
                    CreateFire(4 + 8, 4 );
                    CreateFire(5 + 8, 4);
                    CreateFire(6 + 8, 1 );
                    CreateFire(6 + 8, 2);
                    CreateFire(6 + 8, 4);
                    CreateFire(6 + 8, 6 );

                }
                break;
            case 10:
                {
                    CreateFire(0 + 8, 3);
                    CreateFire( 0 + 8, 5);
                    CreateFire(0 + 8, 6 );
                    CreateFire(2 + 8, 2 );
                    CreateFire(2 + 8, 3 );
                    CreateFire(2 + 8, 4);
                    CreateFire(2 + 8, 5);
                    CreateFire(4 + 8, 0 );
                    CreateFire( 4 + 8, 2 );
                    CreateFire( 5 + 8, 2 );
                    CreateFire(5 + 8, 5 );
                    CreateFire( 6 + 8, 0);
                    CreateFire(6 + 8, 2);
                    CreateFire(6 + 8, 5);

                }
                break;
            case 11:
                {
                    CreateFire(0 + 8, 1 );
                    CreateFire( 0 + 8, 2);
                    CreateFire( 0 + 8, 4 );
                    CreateFire(0 + 8, 5);
                    CreateFire( 2 + 8, 0);
                    CreateFire(2 + 8, 2 );
                    CreateFire(2 + 8, 4 );
                    CreateFire( 3 + 8, 6);
                    CreateFire(4 + 8, 0);
                    CreateFire(4 + 8, 1 );
                    CreateFire(4 + 8, 2 );
                    CreateFire(4 + 8, 3 );
                    CreateFire(4 + 8, 6 );
                    CreateFire(5 + 8, 6 );

                }
                break;
            case 12:
                {
                    CreateFire( 0 + 8, 0 );
                    CreateFire(0 + 8, 3 );
                    CreateFire(0 + 8, 4);
                    CreateFire(1 + 8, 6 );
                    CreateFire(2 + 8, 1 );
                    CreateFire( 3 + 8, 1);
                    CreateFire( 3 + 8, 6);
                    CreateFire( 4 + 8, 6 );
                    CreateFire(5 + 8, 0);
                    CreateFire(5 + 8, 6 );
                    CreateFire(6 + 8, 2 );
                    CreateFire( 6 + 8, 3 );
                    CreateFire( 6 + 8, 4 );
                    CreateFire(6 + 8, 6);

                }
                break;
            case 13:
                {
                    CreateFire(0 + 8, 0);
                    CreateFire(0 + 8, 3);
                    CreateFire(0 + 8, 4 );
                    CreateFire(2 + 8, 2 );
                    CreateFire(2 + 8, 3 );
                    CreateFire(2 + 8, 4 );
                    CreateFire(2 + 8, 5);
                    CreateFire(4 + 8, 5);
                    CreateFire(5 + 8, 0);
                    CreateFire(6 + 8, 0 );
                    CreateFire(6 + 8, 2 );
                    CreateFire( 6 + 8, 4);
                    CreateFire(6 + 8, 5 );
                    CreateFire(6 + 8, 6 );

                }
                break;
            case 14:
                {
                    CreateFire(0 + 8, 2 );
                    CreateFire(1 + 8, 4 );
                    CreateFire(2 + 8, 0 );
                    CreateFire(2 + 8, 2 );
                    CreateFire(2 + 8, 4);
                    CreateFire( 2 + 8, 6);
                    CreateFire(3 + 8, 0);
                    CreateFire(3 + 8, 4 );
                    CreateFire(3 + 8, 6);
                    CreateFire(4 + 8, 4);
                    CreateFire(4 + 8, 6 );
                    CreateFire(5 + 8, 2 );
                    CreateFire(6 + 8, 2 );
                    CreateFire(6 + 8, 6 );

                }
                break;
            case 15:
                {
                    CreateFire(0 + 8, 0 );
                    CreateFire(0 + 8, 3);
                    CreateFire(0 + 8, 5 );
                    CreateFire( 0 + 8, 6 );
                    CreateFire(2 + 8, 1 );
                    CreateFire( 2 + 8, 2);
                    CreateFire( 2 + 8, 3);
                    CreateFire(2 + 8, 4 );
                    CreateFire( 2 + 8, 6);
                    CreateFire(4 + 8, 5 );
                    CreateFire(5 + 8, 1 );
                    CreateFire(5 + 8, 2);
                    CreateFire(5 + 8, 5);
                    CreateFire(6 + 8, 5);

                }
                break;
        }
        
    }
    public void CreateFire(int x, int y)
    {
        GameObject objw = Instantiate(FireWitch);
        FireWitchScript Frw = objw.GetComponent<FireWitchScript>();
        Frw.SetCords(x, y);
        SetBattlePositions(x , y);
    }
    public bool CheckTwo(int x, int y)
    {
        if (Positions[x, y] != 1 && Positions[x, y - 1] != 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool CheckThree(int x, int y)
    {
        if (Positions[x, y] != 1 && Positions[x, y - 1] != 1 && Positions[x, y - 2] != 1)
        {
            return true;
        }
        else
        { return false; }
    }
    public bool CheckFour(int x, int y)
    {
        if (Positions[x, y] != 1 && Positions[x, y - 1] != 1 && Positions[x, y - 2] != 1 && Positions[x, y - 3] != 1)
        {
            return true;
        }
        else
        { return false; }
    }
    public void SpawnerKeepScore(int x, int y, int z, int q)
    {
        OneShip -= x;
        TwoShip -= y;
        ThreeShip -= z;
        FourShip -= q;
    }

    public bool CheckTwoRight(int x, int y)
    {
        if (Positions[x, y] != 1 && Positions[x + 1, y] != 1 && x <= 6 && x + 1 <= 6)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool CheckThreeRight(int x, int y)
    {
        if (Positions[x, y] != 1 && Positions[x + 1, y] != 1 && Positions[x + 2, y] != 1 && x <= 6 && x + 2 <= 6)
        {
            return true;
        }
        else
        { return false; }
    }
    public bool CheckFourRight(int x, int y)
    {
        if (Positions[x, y] != 1 && Positions[x + 1, y] != 1 && Positions[x + 2, y] != 1 && Positions[x + 3, y] != 1 && x <= 6 && x + 3 <= 6)
        {
            return true;
        }
        else
        { return false; }
    }
    public bool CheckFourFire(int x, int y)
    {
        if (Positions[x, y] != 1 && Positions[x, y - 1] != 1 && Positions[x, y - 2] != 1 && Positions[x, y - 3] != 1)
        {
            return true;
        }
        else
        { return false; }
    }
    public bool CheckThreeFire(int x, int y)
    {
        if (Positions[x, y] != 1 && Positions[x, y - 1] != 1 && Positions[x, y - 2] != 1)
        {
            return true;
        }
        else
        { return false; }
    }
    public bool CheckTwoFire(int x, int y)
    {
        if (Positions[x, y] != 1 && Positions[x, y - 1] != 1)
        {
            return true;
        }
        else
        { return false; }
    }
    public void NextTurn()
    {
        Ice = !Ice;
    }
    public bool IceBaby()
    {
        return Ice;
    }
    public void CreateAttackPlate()
    {
        for (int a = 7; a < 15; a++)
        {
            for (int b = 0; b < 7; b++)
            {
                if (BattlePositions[a, b] != 3)
                {
                    CreateAttackPlates(a, b);
                }
            }
        }
    }
    public void CreateAttackPlates(int a, int b)
    {
        GameObject obj = Instantiate(AttackPlate, new Vector3(a, b, -1), Quaternion.identity);
        AttackPlate plt = obj.GetComponent<AttackPlate>();
        plt.SetCords(a, b);
    }
    public void EnemyAttack()
    {
        if (Battle == true)
        {
            float y = 5;
            int a = Random.Range(0, 7);
            int b = Random.Range(0, 7);

            if (BattlePositions[a, b] != 3)
            {
                Instantiate(Fireball, new Vector3((a * 0.48f) + 2f, (b * 0.48f) + 2f, -1), Quaternion.identity);
                BattlePositionsDestroy(a, b);
                
                CreateAttackPlate();
            }

            else
            {
                EnemyAttack();
            }
        }
    }
    public void BattlePositionsDestroy(int x, int y)
    {
        BattlePositions[x, y] = 3;
    }
    public void InvalidPlace()
    {
        PlaceingText.text = "Invalid Location";
    }
    public void ValidPlace()
    {
        PlaceingText.text = " ";
    }
}
