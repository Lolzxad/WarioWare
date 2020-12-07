using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SpanishInquisition
{
    namespace MiniGame1
    {
        public class MainMecaAndSound : MonoBehaviour
        {
            private int QTEGen;
            private int numberOfButtons;
            private int buttonNumber;
            private bool gameDone;
            private bool correctButton;
            private GameObject activeButton;
            private Transform drapeau;

            private LTN_SoundManager sMngr;

            private void Start()
            {
                sMngr = GetComponentInChildren<LTN_SoundManager>();
                drapeau = GameObject.Find("/Graphs/TW_Drapeau").transform;              
            }
        
            private void Update()
            {

                if (numberOfButtons < 3)
                {
                    QTEGen = Random.Range(1, 5);
                }

                if (numberOfButtons == 3)
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

                IEnumerator GameStart()
                {
                    if (buttonNumber == 0)
                    {
                        if (GameObject.Find("/Input/Buttons A/Button A 1").activeSelf == true)
                        {
                            if (Input.GetButton("A_Button") && correctButton == false)
                            {
                                Debug.Log("Success");
                                sMngr.PlayGoodButton();
                                correctButton = true;
                                buttonNumber++;
                                drapeau.transform.position += new Vector3(0, 1, 0);
                            }

                            else if (Input.GetButton("B_Button") || Input.GetButton("X_Button") || Input.GetButton("Y_Button"))
                            {
                                Debug.Log("Fail");
                                sMngr.PlayWrongButton();
                            }
                        }

                        if (GameObject.Find("/Input/Buttons B/Button B 1").activeSelf == true)
                        {
                            if (Input.GetButton("B_Button") && correctButton == false)
                            {
                                Debug.Log("Success");
                                sMngr.PlayGoodButton();
                                correctButton = true;
                                buttonNumber++;
                                drapeau.transform.position += new Vector3(0, 1, 0);
                            }

                            else if (Input.GetButton("A_Button") || Input.GetButton("X_Button") || Input.GetButton("Y_Button"))
                            {
                                Debug.Log("Fail");
                                sMngr.PlayWrongButton();
                            }
                        }

                        if (GameObject.Find("/Input/Buttons X/Button X 1").activeSelf == true)
                        {
                            if (Input.GetButton("X_Button") && correctButton == false)
                            {
                                Debug.Log("Success");
                                sMngr.PlayGoodButton();
                                correctButton = true;
                                buttonNumber++;
                                drapeau.transform.position += new Vector3(0, 1, 0);
                            }

                            else if (Input.GetButton("A_Button") || Input.GetButton("B_Button") || Input.GetButton("Y_Button"))
                            {
                                sMngr.PlayWrongButton();
                                Debug.Log("Fail");
                            }

                        }

                        if (GameObject.Find("/Input/Buttons Y/Button Y 1").activeSelf == true)
                        {
                            if (Input.GetButton("Y_Button") && correctButton == false)
                            {
                                Debug.Log("Success");
                                sMngr.PlayGoodButton();
                                correctButton = true;
                                buttonNumber++;
                                drapeau.transform.position += new Vector3(0, 1, 0);
                            }

                            else if (Input.GetButton("A_Button") || Input.GetButton("B_Button") || Input.GetButton("X_Button"))
                            {
                                sMngr.PlayWrongButton();
                                Debug.Log("Fail");
                            }
                        }
                    }

                    correctButton = false;

                    if (buttonNumber == 1 && correctButton == false)
                    {
                        if (GameObject.Find("/Input/Buttons A/Button A 2").activeSelf == true)
                        {
                            if (Input.GetButton("A_Button") && correctButton == false)
                            {
                                Debug.Log("Success");
                                sMngr.PlayGoodButton();
                                correctButton = true;
                                buttonNumber++;
                                drapeau.transform.position += new Vector3(0, 1, 0);
                            }

                            if (Input.GetButton("B_Button") || Input.GetButton("X_Button") || Input.GetButton("Y_Button"))
                            {
                                sMngr.PlayWrongButton();
                                Debug.Log("Fail");
                            }
                        }

                        if (GameObject.Find("/Input/Buttons B/Button B 2").activeSelf == true)
                        {
                            if (Input.GetButton("B_Button") && correctButton == false)
                            {
                                Debug.Log("Success");
                                sMngr.PlayGoodButton();
                                correctButton = true;
                                buttonNumber++;
                                drapeau.transform.position += new Vector3(0, 1, 0);
                            }

                            if (Input.GetButton("A_Button") || Input.GetButton("X_Button") || Input.GetButton("Y_Button"))
                            {
                                sMngr.PlayWrongButton();
                                Debug.Log("Fail");
                            }
                        }

                        if (GameObject.Find("/Input/Buttons X/Button X 2").activeSelf == true)
                        {
                            if (Input.GetButton("X_Button") && correctButton == false)
                            {
                                Debug.Log("Success");
                                sMngr.PlayGoodButton();
                                correctButton = true;
                                buttonNumber++;
                                drapeau.transform.position += new Vector3(0, 1, 0);
                            }

                            if (Input.GetButton("A_Button") || Input.GetButton("B_Button") || Input.GetButton("Y_Button"))
                            {
                                sMngr.PlayWrongButton();
                                Debug.Log("Fail");
                            }
                        }

                        if (GameObject.Find("/Input/Buttons Y/Button Y 2").activeSelf == true)
                        {
                            if (Input.GetButton("Y_Button") && correctButton == false)
                            {
                                Debug.Log("Success");
                                sMngr.PlayGoodButton();
                                correctButton = true;
                                buttonNumber++;
                                drapeau.transform.position += new Vector3(0, 1, 0);
                            }

                            if (Input.GetButton("A_Button") || Input.GetButton("B_Button") || Input.GetButton("X_Button"))
                            {
                                sMngr.PlayWrongButton();
                                Debug.Log("Fail");
                            }
                        }
                    }

                    correctButton = false;

                    if (buttonNumber == 2 && correctButton == false)
                    {
                        if (GameObject.Find("/Input/Buttons A/Button A 3").activeSelf == true)
                        {
                            if (Input.GetButton("A_Button") && correctButton == false)
                            {
                                Debug.Log("Success");
                                sMngr.PlayGoodButton();
                                correctButton = true;
                                buttonNumber++;
                                drapeau.transform.position += new Vector3(0, 1, 0);
                            }

                            if (Input.GetButton("B_Button") || Input.GetButton("X_Button") || Input.GetButton("Y_Button"))
                            {
                                sMngr.PlayWrongButton();
                                Debug.Log("Fail");
                            }
                        }

                        if (GameObject.Find("/Input/Buttons B/Button B 3").activeSelf == true)
                        {
                            if (Input.GetButton("B_Button") && correctButton == false)
                            {
                                Debug.Log("Success");
                                sMngr.PlayGoodButton();
                                correctButton = true;
                                buttonNumber++;
                                drapeau.transform.position += new Vector3(0, 1, 0);
                            }

                            if (Input.GetButton("A_Button") || Input.GetButton("X_Button") || Input.GetButton("Y_Button"))
                            {
                                sMngr.PlayWrongButton();
                                Debug.Log("Fail");
                            }
                        }

                        if (GameObject.Find("/Input/Buttons X/Button X 3").activeSelf == true)
                        {
                            if (Input.GetButton("X_Button") && correctButton == false)
                            {
                                Debug.Log("Success");
                                sMngr.PlayGoodButton();
                                correctButton = true;
                                buttonNumber++;
                                drapeau.transform.position += new Vector3(0, 1, 0);
                            }

                            if (Input.GetButton("A_Button") || Input.GetButton("B_Button") || Input.GetButton("Y_Button"))
                            {
                                sMngr.PlayWrongButton();
                                Debug.Log("Fail");
                            }
                        }

                        if (GameObject.Find("/Input/Buttons Y/Button Y 3").activeSelf == true)
                        {
                            if (Input.GetButton("Y_Button") && correctButton == false)
                            {
                                Debug.Log("Success");
                                sMngr.PlayGoodButton();
                                correctButton = true;
                                buttonNumber++;
                                drapeau.transform.position += new Vector3(0, 1, 0);
                            }

                            if (Input.GetButton("A_Button") || Input.GetButton("B_Button") || Input.GetButton("X_Button"))
                            {
                                sMngr.PlayWrongButton();
                                Debug.Log("Fail");
                            }
                        }
                    }
                    yield return null;
                }
            }
        }
    }
}
