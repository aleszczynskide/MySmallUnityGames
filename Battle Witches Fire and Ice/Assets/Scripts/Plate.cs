using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class Plate : MonoBehaviour
{
    private int Xposition, Yposition, ShipNumber,TurnNumber;    
    private float PositionX, PositionY;
    private GameObject controller, PositionChecker,Switcher;

    private void Start()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");
        Switcher = GameObject.FindGameObjectWithTag("Switcher");
    }
    public void SetCords(int a ,int b,int c)
    { 
        ShipNumber = c;

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
        Switcher.GetComponent<Switcher>().Switching();
        if (!Switcher.GetComponent<Switcher>().Switching())
        {
            switch (ShipNumber)
            {
                case (1):
                    {
                        controller = GameObject.FindGameObjectWithTag("GameController");
                        controller.GetComponent<Controller>().SetPositions(Xposition, Yposition); //Œrodek
                        controller.GetComponent<Controller>().SetPositions(Xposition - 1, Yposition + 1); //lewa góra
                        controller.GetComponent<Controller>().SetPositions(Xposition, Yposition + 1); // góra
                        controller.GetComponent<Controller>().SetPositions(Xposition + 1, Yposition + 1); // prawa góra
                        controller.GetComponent<Controller>().SetPositions(Xposition + 1, Yposition); // prawo
                        controller.GetComponent<Controller>().SetPositions(Xposition + 1, Yposition - 1); //dolne prawo
                        controller.GetComponent<Controller>().SetPositions(Xposition, Yposition - 1); //dó³
                        controller.GetComponent<Controller>().SetPositions(Xposition - 1, Yposition - 1); //dolne lewo
                        controller.GetComponent<Controller>().SetPositions(Xposition - 1, Yposition); //lewo
                        controller.GetComponent<Controller>().SpawnIce(Xposition, Yposition);
                        controller.GetComponent<Controller>().DestroyPlates();
                        controller.GetComponent<Controller>().ValidPlace();
                    }
                    break;

                case (2):
                    {
                        if (controller.GetComponent<Controller>().CheckTwo(Xposition, Yposition))
                        {
                            Debug.Log("Good Location");
                            controller.GetComponent<Controller>().SpawnIce(Xposition, Yposition);
                            controller.GetComponent<Controller>().SpawnIce(Xposition, Yposition - 1);
                            controller.GetComponent<Controller>().SetPositions(Xposition, Yposition); //Œrodek
                            controller.GetComponent<Controller>().SetPositions(Xposition - 1, Yposition + 1); //lewa góra
                            controller.GetComponent<Controller>().SetPositions(Xposition, Yposition + 1); // góra
                            controller.GetComponent<Controller>().SetPositions(Xposition + 1, Yposition + 1); // prawa góra
                            controller.GetComponent<Controller>().SetPositions(Xposition + 1, Yposition); // prawo
                            controller.GetComponent<Controller>().SetPositions(Xposition + 1, Yposition - 1); //dolne prawo
                            controller.GetComponent<Controller>().SetPositions(Xposition, Yposition - 1); //dó³
                            controller.GetComponent<Controller>().SetPositions(Xposition - 1, Yposition - 1); //dolne lewo
                            controller.GetComponent<Controller>().SetPositions(Xposition - 1, Yposition); //lewo
                            controller.GetComponent<Controller>().SetPositions(Xposition, Yposition - 2); //drugi dó³
                            controller.GetComponent<Controller>().SetPositions(Xposition - 1, Yposition - 2); // drugiedolne lewo
                            controller.GetComponent<Controller>().SetPositions(Xposition - 1, Yposition - 1); //drugie lewo
                            controller.GetComponent<Controller>().SetPositions(Xposition + 1, Yposition - 2); //drugi prawy dó³
                            controller.GetComponent<Controller>().DestroyPlates();
                            controller.GetComponent<Controller>().ValidPlace();
                        }
                        else
                        {
                            controller.GetComponent<Controller>().InvalidPlace();
                        }
                      

                    }
                    break;

                case (3):
                    {
                        if (controller.GetComponent<Controller>().CheckThree(Xposition, Yposition))
                        {
                            Debug.Log("Good Location");

                            controller.GetComponent<Controller>().SpawnIce(Xposition, Yposition);
                            controller.GetComponent<Controller>().SpawnIce(Xposition, Yposition - 1);
                            controller.GetComponent<Controller>().SpawnIce(Xposition, Yposition - 2);
                            controller.GetComponent<Controller>().SetPositions(Xposition - 1, Yposition + 1); //Œrodek
                            controller.GetComponent<Controller>().SetPositions(Xposition, Yposition + 1); //Œrodek
                            controller.GetComponent<Controller>().SetPositions(Xposition + 1, Yposition + 1); //Œrodek
                            controller.GetComponent<Controller>().SetPositions(Xposition - 1, Yposition); //Œrodek
                            controller.GetComponent<Controller>().SetPositions(Xposition, Yposition); //Œrodek
                            controller.GetComponent<Controller>().SetPositions(Xposition + 1, Yposition); //Œrodek
                            controller.GetComponent<Controller>().SetPositions(Xposition - 1, Yposition - 1); //Œrodek
                            controller.GetComponent<Controller>().SetPositions(Xposition, Yposition - 1); //Œrodek
                            controller.GetComponent<Controller>().SetPositions(Xposition + 1, Yposition - 1); //Œrodek
                            controller.GetComponent<Controller>().SetPositions(Xposition - 1, Yposition - 2); //Œrodek
                            controller.GetComponent<Controller>().SetPositions(Xposition, Yposition - 2); //Œrodek
                            controller.GetComponent<Controller>().SetPositions(Xposition + 1, Yposition - 2); //Œrodek
                            controller.GetComponent<Controller>().SetPositions(Xposition - 1, Yposition - 3); //Œrodek
                            controller.GetComponent<Controller>().SetPositions(Xposition, Yposition - 3); //Œrodek
                            controller.GetComponent<Controller>().SetPositions(Xposition + 1, Yposition - 3); //Œrodek
                            controller.GetComponent<Controller>().DestroyPlates();
                            controller.GetComponent<Controller>().ValidPlace();
                        }
                        else
                        {
                            controller.GetComponent<Controller>().InvalidPlace();

                        }
                       

                    }
                    break;
                case (4):
                    {
                        if (controller.GetComponent<Controller>().CheckFour(Xposition, Yposition))
                        {
                            Debug.Log("Good Location");
                            controller.GetComponent<Controller>().SpawnIce(Xposition, Yposition);
                            controller.GetComponent<Controller>().SpawnIce(Xposition, Yposition - 1);
                            controller.GetComponent<Controller>().SpawnIce(Xposition, Yposition - 2);
                            controller.GetComponent<Controller>().SpawnIce(Xposition, Yposition - 3);
                            controller.GetComponent<Controller>().SetPositions(Xposition - 1, Yposition + 1); //Œrodek
                            controller.GetComponent<Controller>().SetPositions(Xposition, Yposition + 1); //Œrodek
                            controller.GetComponent<Controller>().SetPositions(Xposition + 1, Yposition + 1); //Œrodek
                            controller.GetComponent<Controller>().SetPositions(Xposition - 1, Yposition); //Œrodek
                            controller.GetComponent<Controller>().SetPositions(Xposition, Yposition); //Œrodek
                            controller.GetComponent<Controller>().SetPositions(Xposition + 1, Yposition); //Œrodek
                            controller.GetComponent<Controller>().SetPositions(Xposition - 1, Yposition - 1); //Œrodek
                            controller.GetComponent<Controller>().SetPositions(Xposition, Yposition - 1); //Œrodek
                            controller.GetComponent<Controller>().SetPositions(Xposition + 1, Yposition - 1); //Œrodek
                            controller.GetComponent<Controller>().SetPositions(Xposition - 1, Yposition - 2); //Œrodek
                            controller.GetComponent<Controller>().SetPositions(Xposition, Yposition - 2);//Œrodek
                            controller.GetComponent<Controller>().SetPositions(Xposition + 1, Yposition - 2); //Œrodek
                            controller.GetComponent<Controller>().SetPositions(Xposition - 1, Yposition - 3); //Œrodek
                            controller.GetComponent<Controller>().SetPositions(Xposition, Yposition - 3); //Œrodek
                            controller.GetComponent<Controller>().SetPositions(Xposition + 1, Yposition - 3); //Œrodek
                            controller.GetComponent<Controller>().SetPositions(Xposition - 1, Yposition - 4);
                            controller.GetComponent<Controller>().SetPositions(Xposition, Yposition - 4);
                            controller.GetComponent<Controller>().SetPositions(Xposition + 1, Yposition - 4);
                            controller.GetComponent<Controller>().DestroyPlates();
                            controller.GetComponent<Controller>().ValidPlace();


                        }
                        else
                        {
                            controller.GetComponent<Controller>().InvalidPlace();
                        }
                       

                    }
                    break;
            }
        }
        else if (Switcher.GetComponent<Switcher>().Switching())
        {
            switch (ShipNumber)
            {
                case (1):
                    {
                        controller = GameObject.FindGameObjectWithTag("GameController");
                        controller.GetComponent<Controller>().SetPositions(Xposition, Yposition); //Œrodek
                        controller.GetComponent<Controller>().SetPositions(Xposition - 1, Yposition + 1); //lewa góra
                        controller.GetComponent<Controller>().SetPositions(Xposition, Yposition + 1); // góra
                        controller.GetComponent<Controller>().SetPositions(Xposition + 1, Yposition + 1); // prawa góra
                        controller.GetComponent<Controller>().SetPositions(Xposition + 1, Yposition); // prawo
                        controller.GetComponent<Controller>().SetPositions(Xposition + 1, Yposition - 1); //dolne prawo
                        controller.GetComponent<Controller>().SetPositions(Xposition, Yposition - 1); //dó³
                        controller.GetComponent<Controller>().SetPositions(Xposition - 1, Yposition - 1); //dolne lewo
                        controller.GetComponent<Controller>().SetPositions(Xposition - 1, Yposition); //lewo
                        controller.GetComponent<Controller>().SpawnIce(Xposition, Yposition);
                        controller.GetComponent<Controller>().DestroyPlates();
                        controller.GetComponent<Controller>().ValidPlace();
                    }
                    break;

                case (2):
                    {
                        if (controller.GetComponent<Controller>().CheckTwoRight(Xposition, Yposition))
                        {
                            Debug.Log("Good Location");
                            controller.GetComponent<Controller>().SetPositions(Xposition, Yposition); //Œrodek
                            controller.GetComponent<Controller>().SetPositions(Xposition - 1, Yposition + 1); //lewa góra
                            controller.GetComponent<Controller>().SetPositions(Xposition, Yposition + 1); // góra
                            controller.GetComponent<Controller>().SetPositions(Xposition + 1, Yposition + 1); // prawa góra
                            controller.GetComponent<Controller>().SetPositions(Xposition + 1, Yposition); // prawo
                            controller.GetComponent<Controller>().SetPositions(Xposition + 1, Yposition - 1); //dolne prawo
                            controller.GetComponent<Controller>().SetPositions(Xposition, Yposition - 1); //dó³
                            controller.GetComponent<Controller>().SetPositions(Xposition - 1, Yposition - 1); //dolne lewo
                            controller.GetComponent<Controller>().SetPositions(Xposition - 1, Yposition); //lewo
                            controller.GetComponent<Controller>().SetPositions(Xposition + 2, Yposition + 1); //Œrodek
                            controller.GetComponent<Controller>().SetPositions(Xposition + 2, Yposition); //Œrodek
                            controller.GetComponent<Controller>().SetPositions(Xposition + 2, Yposition - 1); //Œrodek
                            controller.GetComponent<Controller>().SpawnIce(Xposition , Yposition );
                            controller.GetComponent<Controller>().SpawnIce(Xposition + 1, Yposition);
                            controller.GetComponent<Controller>().DestroyPlates();
                            controller.GetComponent<Controller>().ValidPlace();

                        }
                        else
                        {
                            controller.GetComponent<Controller>().InvalidPlace();
                        }
                       

                    }
                    break;

                case (3):
                    {
                        if (controller.GetComponent<Controller>().CheckThreeRight(Xposition, Yposition))
                        {
                            Debug.Log("Good Location");

                            controller.GetComponent<Controller>().SpawnIce(Xposition, Yposition);
                            controller.GetComponent<Controller>().SpawnIce(Xposition + 1, Yposition );
                            controller.GetComponent<Controller>().SpawnIce(Xposition + 2, Yposition);
                            controller.GetComponent<Controller>().SetPositions(Xposition, Yposition); //Œrodek
                            controller.GetComponent<Controller>().SetPositions(Xposition - 1, Yposition + 1); //lewa góra
                            controller.GetComponent<Controller>().SetPositions(Xposition, Yposition + 1); // góra
                            controller.GetComponent<Controller>().SetPositions(Xposition + 1, Yposition + 1); // prawa góra
                            controller.GetComponent<Controller>().SetPositions(Xposition + 1, Yposition); // prawo
                            controller.GetComponent<Controller>().SetPositions(Xposition + 1, Yposition - 1); //dolne prawo
                            controller.GetComponent<Controller>().SetPositions(Xposition, Yposition - 1); //dó³
                            controller.GetComponent<Controller>().SetPositions(Xposition - 1, Yposition - 1); //dolne lewo
                            controller.GetComponent<Controller>().SetPositions(Xposition - 1, Yposition); //lewo
                            controller.GetComponent<Controller>().SetPositions(Xposition + 2, Yposition + 1); //Œrodek
                            controller.GetComponent<Controller>().SetPositions(Xposition + 2, Yposition); //Œrodek
                            controller.GetComponent<Controller>().SetPositions(Xposition + 2, Yposition - 1); //Œrodek
                            controller.GetComponent<Controller>().SetPositions(Xposition + 3, Yposition + 1); //Œrodek
                            controller.GetComponent<Controller>().SetPositions(Xposition + 3, Yposition); //Œrodek
                            controller.GetComponent<Controller>().SetPositions(Xposition+ 3, Yposition - 1); //Œrodek
                            controller.GetComponent<Controller>().DestroyPlates();
                            controller.GetComponent<Controller>().ValidPlace();
                        }
                        else
                        {
                            controller.GetComponent<Controller>().InvalidPlace();

                        }
                        

                    }
                    break;
                case (4):
                    {
                        if (controller.GetComponent<Controller>().CheckFourRight(Xposition, Yposition))
                        {
                            Debug.Log("Good Location");
                            controller.GetComponent<Controller>().SpawnIce(Xposition, Yposition);
                            controller.GetComponent<Controller>().SpawnIce(Xposition + 1, Yposition );
                            controller.GetComponent<Controller>().SpawnIce(Xposition + 2, Yposition );
                            controller.GetComponent<Controller>().SpawnIce(Xposition + 3, Yposition );
                            controller.GetComponent<Controller>().SetPositions(Xposition, Yposition); //Œrodek
                            controller.GetComponent<Controller>().SetPositions(Xposition - 1, Yposition + 1); //lewa góra
                            controller.GetComponent<Controller>().SetPositions(Xposition, Yposition + 1); // góra
                            controller.GetComponent<Controller>().SetPositions(Xposition + 1, Yposition + 1); // prawa góra
                            controller.GetComponent<Controller>().SetPositions(Xposition + 1, Yposition); // prawo
                            controller.GetComponent<Controller>().SetPositions(Xposition + 1, Yposition - 1); //dolne prawo
                            controller.GetComponent<Controller>().SetPositions(Xposition, Yposition - 1); //dó³
                            controller.GetComponent<Controller>().SetPositions(Xposition - 1, Yposition - 1); //dolne lewo
                            controller.GetComponent<Controller>().SetPositions(Xposition - 1, Yposition); //lewo
                            controller.GetComponent<Controller>().SetPositions(Xposition + 2, Yposition + 1); //Œrodek
                            controller.GetComponent<Controller>().SetPositions(Xposition + 2, Yposition); //Œrodek
                            controller.GetComponent<Controller>().SetPositions(Xposition + 2, Yposition - 1); //Œrodek
                            controller.GetComponent<Controller>().SetPositions(Xposition + 3, Yposition + 1); //Œrodek
                            controller.GetComponent<Controller>().SetPositions(Xposition + 3, Yposition); //Œrodek
                            controller.GetComponent<Controller>().SetPositions(Xposition + 3, Yposition - 1); //Œrodek
                            controller.GetComponent<Controller>().SetPositions(Xposition + 4, Yposition + 1); //Œrodek
                            controller.GetComponent<Controller>().SetPositions(Xposition + 4, Yposition); //Œrodek
                            controller.GetComponent<Controller>().SetPositions(Xposition + 4, Yposition - 1); //Œrodek
                            controller.GetComponent<Controller>().DestroyPlates();
                            controller.GetComponent<Controller>().ValidPlace();


                        }
                        else
                        {
                            controller.GetComponent<Controller>().InvalidPlace();
                        }
                       

                    }
                    break;
            }
        }

    }
}


