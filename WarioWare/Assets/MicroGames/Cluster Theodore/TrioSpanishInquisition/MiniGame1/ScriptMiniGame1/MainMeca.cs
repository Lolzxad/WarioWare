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
            private int numberOfButtons;
            private bool waitingForButton;
            private bool gameDone;

            void Update()
            {
                if (waitingForButton == false && numberOfButtons < 3)
                {
                    QTEGen = Random.Range(1, 5);
                    waitingForButton = true;                  
                }

                if (QTEGen == 1)
                {
                    Debug.Log("Bouton A");

                    if (Input.GetButtonDown("A_Button"))
                    {
                        waitingForButton = false;
                        QTEGen = 0;
                        numberOfButtons++;
                    }
                }

                if (QTEGen == 2)
                {
                    Debug.Log("Bouton B");

                    if (Input.GetButtonDown("B_Button"))
                    {
                        waitingForButton = false;
                        QTEGen = 0;
                        numberOfButtons++;
                    }
                }

                if (QTEGen == 3)
                {
                    Debug.Log("Bouton X");  

                    if (Input.GetButtonDown("X_Button"))
                    {
                        waitingForButton = false;
                        QTEGen = 0;
                        numberOfButtons++;
                    }
                }

                if (QTEGen == 4)
                {
                    Debug.Log("Bouton Y");

                    if (Input.GetButtonDown("Y_Button"))
                    {
                        waitingForButton = false;
                        QTEGen = 0;
                        numberOfButtons++;
                    }
                }

                if (numberOfButtons == 3 && gameDone == false)
                {
                    Debug.Log("You win !)");
                    gameDone = true;
                }
            }
        }
    }
}
