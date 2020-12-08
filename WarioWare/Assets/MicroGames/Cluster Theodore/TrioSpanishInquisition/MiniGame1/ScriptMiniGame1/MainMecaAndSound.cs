using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SpanishInquisition
{
    namespace MiniGame1
    {
        public class MainMecaAndSound : TimedBehaviour
        {
            private int QTEGen;
            private int numberOfButtons;
            private int buttonNumber;
            private bool gameDone;
            private GameObject activeButton;
            private Transform drapeau;
            public Transform flagFirst;
            public Transform flagSecond;
            public Transform flagThird;

            private LTN_SoundManager sMngr;

            public override void Start()
            {
                base.Start();
                sMngr = GetComponentInChildren<LTN_SoundManager>();
                drapeau = GameObject.Find("/Graphs/TW_Drapeau").transform;
            }
        
            public override void FixedUpdate() 
            {
                base.FixedUpdate();

                if (numberOfButtons < 3)
                {
                    QTEGen = Random.Range(1, 5);
                }

                if (numberOfButtons == 3 && gameDone == false)
                {
                    StartCoroutine(GameStart());
                }

                if (QTEGen == 1)
                {
                    Debug.Log("Bouton A");

                    if (numberOfButtons == 0)
                    {
                        activeButton = GameObject.Find("/Input/Buttons A/Button A 1");
                        activeButton.SetActive(true);
                    }

                    if (numberOfButtons == 1)
                    {
                        activeButton = GameObject.Find("/Input/Buttons A/Button A 2");
                        activeButton.SetActive(true);
                    }

                    if (numberOfButtons == 2)
                    {
                        activeButton = GameObject.Find("/Input/Buttons A/Button A 3");
                        activeButton.SetActive(true);
                    }

                    /*if (numberOfButtons == 3)
                    {
                        activeButton = GameObject.Find("/Input/Buttons A/Button A 4");
                        activeButton.SetActive(true);
                    }*/

                    QTEGen = 0;
                    numberOfButtons++;
                }

                if (QTEGen == 2)
                {
                    Debug.Log("Bouton B");

                    if (numberOfButtons == 0)
                    {
                        activeButton = GameObject.Find("/Input/Buttons B/Button B 1");
                        activeButton.SetActive(true);
                    }

                    if (numberOfButtons == 1)
                    {
                        activeButton = GameObject.Find("/Input/Buttons B/Button B 2");
                        activeButton.SetActive(true);
                    }

                    if (numberOfButtons == 2)
                    {
                        activeButton = GameObject.Find("/Input/Buttons B/Button B 3");
                        activeButton.SetActive(true);
                    }

                    QTEGen = 0;
                    numberOfButtons++;
                }


                if (QTEGen == 3)
                {
                    Debug.Log("Bouton X");

                    if (numberOfButtons == 0)
                    {
                        activeButton = GameObject.Find("/Input/Buttons X/Button X 1");
                        activeButton.SetActive(true);
                    }

                    if (numberOfButtons == 1)
                    {
                        activeButton = GameObject.Find("/Input/Buttons X/Button X 2");
                        activeButton.SetActive(true);
                    }

                    if (numberOfButtons == 2)
                    {
                        activeButton = GameObject.Find("/Input/Buttons X/Button X 3");
                        activeButton.SetActive(true);
                    }

                    QTEGen = 0;
                    numberOfButtons++;
                }

                if (QTEGen == 4)
                {
                    Debug.Log("Bouton Y");

                    if (numberOfButtons == 0)
                    {
                        activeButton = GameObject.Find("/Input/Buttons Y/Button Y 1");
                        activeButton.SetActive(true);
                    }

                    if (numberOfButtons == 1)
                    {
                        activeButton = GameObject.Find("/Input/Buttons Y/Button Y 2");
                        activeButton.SetActive(true);
                    }

                    if (numberOfButtons == 2)
                    {
                        activeButton = GameObject.Find("/Input/Buttons Y/Button Y 3");
                        activeButton.SetActive(true);
                    }

                    QTEGen = 0;
                    numberOfButtons++;
                }


                if (buttonNumber == 3 && gameDone == false)
                {                
                    sMngr.PlayFlagFirst();
                    Debug.Log("You win !)");
                    gameDone = true;
                }

                if (gameDone == true)
                {
                    if (drapeau.position.y < flagThird.position.y)
                    {
                        drapeau.Translate(Vector3.up * Time.deltaTime * 10);
                    }
                }

                IEnumerator GameStart()
                {
                    switch (buttonNumber)
                    {

                        case 2:

                            if (drapeau.position.y < flagSecond.position.y)
                            {
                                drapeau.Translate(Vector3.up * Time.deltaTime * 10);
                            }

                            if (GameObject.Find("/Input/Buttons A/Button A 3").activeSelf == true)
                            {
                                if (Input.GetButtonDown("A_Button"))
                                {
                                    Debug.Log("Success");
                                    sMngr.PlayGoodButton();
                                    
                                    buttonNumber++;
                                    //drapeau.transform.Translate(0, 5, 0);
                                }

                                if (Input.GetButtonDown("B_Button") || Input.GetButtonDown("X_Button") || Input.GetButtonDown("Y_Button"))
                                {
                                    sMngr.PlayWrongButton();
                                    Debug.Log("Fail");
                                }
                            }

                            if (GameObject.Find("/Input/Buttons B/Button B 3").activeSelf == true)
                            {
                                if (Input.GetButtonDown("B_Button"))
                                {
                                    Debug.Log("Success");
                                    sMngr.PlayGoodButton();
                                    
                                    buttonNumber++;
                                    //drapeau.transform.Translate(0, 5, 0);
                                }

                                if (Input.GetButtonDown("A_Button") || Input.GetButtonDown("X_Button") || Input.GetButtonDown("Y_Button"))
                                {
                                    sMngr.PlayWrongButton();
                                    Debug.Log("Fail");
                                }
                            }

                            if (GameObject.Find("/Input/Buttons X/Button X 3").activeSelf == true)
                            {
                                if (Input.GetButtonDown("X_Button"))
                                {
                                    Debug.Log("Success");
                                    sMngr.PlayGoodButton();
                                    
                                    buttonNumber++;
                                    //drapeau.transform.Translate(0, 5, 0);
                                }

                                if (Input.GetButtonDown("A_Button") || Input.GetButtonDown("B_Button") || Input.GetButtonDown("Y_Button"))
                                {
                                    sMngr.PlayWrongButton();
                                    Debug.Log("Fail");
                                }
                            }

                            if (GameObject.Find("/Input/Buttons Y/Button Y 3").activeSelf == true)
                            {
                                if (Input.GetButtonDown("Y_Button"))
                                {
                                    Debug.Log("Success");
                                    sMngr.PlayGoodButton();
                                    
                                    buttonNumber++;
                                    //drapeau.transform.Translate(0, 5, 0);
                                }

                                if (Input.GetButtonDown("A_Button") || Input.GetButtonDown("B_Button") || Input.GetButtonDown("X_Button"))
                                {
                                    sMngr.PlayWrongButton();
                                    Debug.Log("Fail");
                                }
                            }
                            break;

                        case 1:

                            if (drapeau.position.y < flagFirst.position.y)
                            {
                                drapeau.Translate(Vector3.up * Time.deltaTime * 10);
                            }                          

                            if (GameObject.Find("/Input/Buttons A/Button A 2").activeSelf == true)
                            {
                                if (Input.GetButtonDown("A_Button"))
                                {
                                    Debug.Log("Success");
                                    sMngr.PlayGoodButton();
                                    
                                    buttonNumber++;
                                    //drapeau.transform.Translate(0, 5, 0);
                                }
                            
                                if (Input.GetButtonDown("B_Button") || Input.GetButtonDown("X_Button") || Input.GetButtonDown("Y_Button"))
                                {
                                    sMngr.PlayWrongButton();
                                    Debug.Log("Fail");
                                }
                            }
                            
                            if (GameObject.Find("/Input/Buttons B/Button B 2").activeSelf == true)
                            {
                                if (Input.GetButtonDown("B_Button"))
                                {
                                    Debug.Log("Success");
                                    sMngr.PlayGoodButton();
                                    
                                    buttonNumber++;
                                    //drapeau.transform.Translate(0, 5, 0);
                                }
                            
                                if (Input.GetButtonDown("A_Button") || Input.GetButtonDown("X_Button") || Input.GetButtonDown("Y_Button"))
                                {
                                    sMngr.PlayWrongButton();
                                    Debug.Log("Fail");
                                }
                            }
                            
                            if (GameObject.Find("/Input/Buttons X/Button X 2").activeSelf == true)
                            {
                                if (Input.GetButtonDown("X_Button"))
                                {
                                    Debug.Log("Success");
                                    sMngr.PlayGoodButton();
                                    
                                    buttonNumber++;
                                    //drapeau.transform.Translate(0, 5, 0);
                                }
                            
                                if (Input.GetButtonDown("A_Button") || Input.GetButtonDown("B_Button") || Input.GetButtonDown("Y_Button"))
                                {
                                    sMngr.PlayWrongButton();
                                    Debug.Log("Fail");
                                }
                            }
                            
                            if (GameObject.Find("/Input/Buttons Y/Button Y 2").activeSelf == true)
                            {
                                if (Input.GetButtonDown("Y_Button"))
                                {
                                    Debug.Log("Success");
                                    sMngr.PlayGoodButton();
                                    
                                    buttonNumber++;
                                    //drapeau.transform.Translate(0, 5, 0);
                                }
                            
                                if (Input.GetButtonDown("A_Button") || Input.GetButtonDown("B_Button") || Input.GetButtonDown("X_Button"))
                                {
                                    sMngr.PlayWrongButton();
                                    Debug.Log("Fail");
                                }
                            }
                            break;

                        default:
                            if (GameObject.Find("/Input/Buttons A/Button A 1").activeSelf == true)
                            {
                                if (Input.GetButtonDown("A_Button"))
                                {
                                    Debug.Log("Success");
                                    sMngr.PlayGoodButton();
                                    
                                    buttonNumber++;
                                    //drapeau.transform.Translate(0, 5, 0);
                                }

                                else if (Input.GetButtonDown("B_Button") || Input.GetButtonDown("X_Button") || Input.GetButtonDown("Y_Button"))
                                {
                                    Debug.Log("Fail");
                                    sMngr.PlayWrongButton();
                                }
                            }

                            if (GameObject.Find("/Input/Buttons B/Button B 1").activeSelf == true)
                            {
                                if (Input.GetButtonDown("B_Button"))
                                {
                                    Debug.Log("Success");
                                    sMngr.PlayGoodButton();
                                    
                                    buttonNumber++;
                                    //drapeau.transform.Translate(0, 5, 0);
                                }

                                else if (Input.GetButtonDown("A_Button") || Input.GetButtonDown("X_Button") || Input.GetButtonDown("Y_Button"))
                                {
                                    Debug.Log("Fail");
                                    sMngr.PlayWrongButton();
                                }
                            }

                            if (GameObject.Find("/Input/Buttons X/Button X 1").activeSelf == true)
                            {
                                if (Input.GetButtonDown("X_Button"))
                                {
                                    Debug.Log("Success");
                                    sMngr.PlayGoodButton();
                                    
                                    buttonNumber++;
                                    //drapeau.transform.Translate(0, 5, 0);
                                }

                                else if (Input.GetButtonDown("A_Button") || Input.GetButtonDown("B_Button") || Input.GetButtonDown("Y_Button"))
                                {
                                    sMngr.PlayWrongButton();
                                    Debug.Log("Fail");
                                }

                            }

                            if (GameObject.Find("/Input/Buttons Y/Button Y 1").activeSelf == true)
                            {
                                if (Input.GetButtonDown("Y_Button"))
                                {
                                    Debug.Log("Success");
                                    sMngr.PlayGoodButton();
                                    
                                    buttonNumber++;
                                    //drapeau.transform.Translate(0, 5, 0);
                                }

                                else if (Input.GetButtonDown("A_Button") || Input.GetButtonDown("B_Button") || Input.GetButtonDown("X_Button"))
                                {
                                    sMngr.PlayWrongButton();
                                    Debug.Log("Fail");
                                }
                            }
                            break;
                    }
                    yield return null;
                }
            }
        }
    }
}
