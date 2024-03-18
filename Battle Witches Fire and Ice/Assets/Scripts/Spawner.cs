using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private GameObject Controller,SpawnerPoint,Spawner1,Spawner2,Spawner3,Spawner4;
    public bool Available = true;
    private BoxCollider2D Box;

    public void Start()
    {
        Box = GetComponent<BoxCollider2D>();    
    }
    private void OnMouseDown()
    {
        Controller = GameObject.FindGameObjectWithTag("GameController");
        SpawnerPoint = GameObject.FindGameObjectWithTag("Pointer");
        switch (this.name)
        {
            case "Spawner 1":
                {
                    Spawner2 = GameObject.FindGameObjectWithTag("Spawner2");
                    Spawner3 = GameObject.FindGameObjectWithTag("Spawner3");
                    Spawner4 = GameObject.FindGameObjectWithTag("Spawner4");
                }
                break;
            case "Spawner 2":
                {
                    Spawner1 = GameObject.FindGameObjectWithTag("Spawner1");
                    Spawner3 = GameObject.FindGameObjectWithTag("Spawner3");
                    Spawner4 = GameObject.FindGameObjectWithTag("Spawner4");
                }
                break;
            case "Spawner 3":
                {
                    Spawner1 = GameObject.FindGameObjectWithTag("Spawner1");
                    Spawner2 = GameObject.FindGameObjectWithTag("Spawner2");
                    Spawner4 = GameObject.FindGameObjectWithTag("Spawner4");
                }
                break;
            case "Spawner 4":
                {
                    Spawner1 = GameObject.FindGameObjectWithTag("Spawner1");
                    Spawner2 = GameObject.FindGameObjectWithTag("Spawner2");
                    Spawner3 = GameObject.FindGameObjectWithTag("Spawner3");
                }
                break;
        }
      
        if (Available)
        {

            switch (this.name)
            {
                case "Spawner 1": Controller.GetComponent<Controller>().CreateSpawnPlates(1); SpawnerPoint.GetComponent<Pointer>().AppearUpDown(1); SpawnerPoint.GetComponent<Pointer>().CreatePointer(); Controller.GetComponent<Controller>().SpawnerKeepScore(1, 0, 0, 0); Spawner2.GetComponent<Spawner>().Available = false;
                    Spawner3.GetComponent<Spawner>().Available = false;
                    Spawner4.GetComponent<Spawner>().Available = false; ; break;
                case "Spawner 2": Controller.GetComponent<Controller>().CreateSpawnPlates(2); SpawnerPoint.GetComponent<Pointer>().AppearUpDown(2); SpawnerPoint.GetComponent<Pointer>().CreatePointer(); Controller.GetComponent<Controller>().SpawnerKeepScore(0, 1, 0, 0); Spawner1.GetComponent<Spawner>().Available = false;
                    Spawner3.GetComponent<Spawner>().Available = false;
                    Spawner4.GetComponent<Spawner>().Available = false; ; break;
                case "Spawner 3": Controller.GetComponent<Controller>().CreateSpawnPlates(3); SpawnerPoint.GetComponent<Pointer>().AppearUpDown(3); SpawnerPoint.GetComponent<Pointer>().CreatePointer(); Controller.GetComponent<Controller>().SpawnerKeepScore(0, 0, 1, 0); Spawner1.GetComponent<Spawner>().Available = false;
                    Spawner2.GetComponent<Spawner>().Available = false;
                    Spawner4.GetComponent<Spawner>().Available = false; ; break;
                case "Spawner 4": Controller.GetComponent<Controller>().CreateSpawnPlates(4); SpawnerPoint.GetComponent<Pointer>().AppearUpDown(4); SpawnerPoint.GetComponent<Pointer>().CreatePointer(); Controller.GetComponent<Controller>().SpawnerKeepScore(0, 0, 0, 1); Spawner1.GetComponent<Spawner>().Available = false;
                    Spawner2.GetComponent<Spawner>().Available = false;
                    Spawner3.GetComponent<Spawner>().Available = false; ; break;
            }  
        }
    }

    public void TurnOff()
    {
        Box.enabled = false;
    }

    public void TurnOn()
    {
        Box.enabled = true;
    }
}
