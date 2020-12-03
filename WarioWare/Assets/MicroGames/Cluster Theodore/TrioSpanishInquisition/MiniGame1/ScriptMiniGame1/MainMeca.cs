using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SpanishInquisition
{
    namespace MiniGame1
    {
        public class MainMeca : MonoBehaviour
        {
            private int QTEGen;
            private bool WaitingForButton;
            private int NumberOfButtons = 3;

            void Update()
            {
                for (int i = 0; i < NumberOfButtons; i++)
                {
                    if (WaitingForButton == false)
                    {
                        QTEGen = Random.Range(1, 5);
                        WaitingForButton = true;                  
                    }

                    if (QTEGen == 1)
                    {
                        Debug.Log("Bouton A");

                        if (Input.GetButtonDown("A_Button"))
                        {
                            WaitingForButton = false;
                            QTEGen = 0;
                        }
                    }

                    if (QTEGen == 2)
                    {
                        Debug.Log("Bouton B");

                        if (Input.GetButtonDown("B_Button"))
                        {
                            WaitingForButton = false;
                            QTEGen = 0;
                        }
                    }

                    if (QTEGen == 3)
                    {
                        Debug.Log("Bouton X");

                        if (Input.GetButtonDown("X_Button"))
                        {
                            WaitingForButton = false;
                            QTEGen = 0;
                        }
                    }

                    if (QTEGen == 4)
                    {
                        Debug.Log("Bouton Y");

                        if (Input.GetButtonDown("Y_Button"))
                        {
                            WaitingForButton = false;
                            QTEGen = 0;
                        }
                    }
                }
            }
        }
    }
}
