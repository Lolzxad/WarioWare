using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Testing;

namespace SpanishInquisition
{

    namespace Duel
    {

        /// <summary>
        /// Adel Ahmed-Yahia
        /// </summary>

        public class GameManager : TimedBehaviour
        {
            private static GameManager _instance;
            public static GameManager instance
            {
                get
                {
                    if (_instance == null)
                    {
                        _instance = FindObjectOfType<GameManager>();
                    }
                    return _instance;
                }
            }

            public GameObject[] scoreDisplays;
            public GameObject parryButton1;
            public GameObject parryButton2;
            public GameObject parryButton3;
            public GameObject victoryFeedback;
            public GameObject defeatFeedback;

            public int numberOfParries;
            public int parriesNeeded;
            public int currentParryButton;
            public float tickTimer;
            public float cooldownTime;
            public bool gameIsWon;
            public bool gameIsFinished;
            public bool endFeedbackPlayed;
            public float speed;
            public float cooldown;


            private SoundManager soundManager;

            public override void Start()
            {
                base.Start(); //Do not erase this line!

                speed = bpm / 5;
                cooldownTime = (0.5f * 60) / bpm;
                soundManager = GetComponentInChildren<SoundManager>();


                switch (bpm)
                {
                    case 60:
                        soundManager.PlayFlagMusicSlow();
                        break;

                    case 90:
                        soundManager.PlayFlagMusicMedium();
                        break;

                    case 120:
                        soundManager.PlayFlagMusicFast();
                        break;

                    case 140:
                        soundManager.PlayFlagMusicSuperFast();
                        break;
                }

                switch (currentDifficulty)
                {
                    case Difficulty.EASY:

                        numberOfParries = 2;
                        break;

                    case Difficulty.MEDIUM:

                        numberOfParries = 3;
                        break;

                    case Difficulty.HARD:

                        numberOfParries = 4;
                        break;
                }
                
                //DisplayScore();               
            }

            public void Update()
            {                
                
                if (numberOfParries >= parriesNeeded && !gameIsFinished)
                {
                    gameIsFinished = true;
                    gameIsWon = true;
                    if (!endFeedbackPlayed)
                    {
                        EndOfGameFeedback();
                        endFeedbackPlayed = true;
                    }                   
                }
            }

            //TimedUpdate is called once every tick.

            public override void TimedUpdate()
            {
                base.TimedUpdate();


                if ((Tick < 8 && !gameIsWon) || !gameIsFinished)
                {
                    ParryRandomizer();
                }

                if (Tick == 8)
                {
                    Manager.Instance.Result (gameIsWon);
                }

                if ((Tick == 8 && !gameIsWon) || gameIsFinished)
                {
                    
                }
            }

            private void ParryRandomizer()
            {
                currentParryButton = Random.Range(1, 4);

                if (currentParryButton == 1)
                {
                    parryButton1.SetActive(true);

                    if (Input.GetButtonDown("X_Button"))
                    {
                        Debug.Log("Parry !");
                        numberOfParries++;
                        parryButton1.SetActive(false);
                    }

                    if (Input.GetButtonDown("Y_Button") || Input.GetButtonDown("B_Button"))
                    {
                        Debug.Log("Fail !");
                        gameIsFinished = true;
                    }
                }

                if (currentParryButton == 2)
                {
                    parryButton2.SetActive(true);

                    if (Input.GetButtonDown("Y_Button"))
                    {
                        Debug.Log("Parry !");
                        numberOfParries++;
                        parryButton2.SetActive(false);
                    }

                    if (Input.GetButtonDown("X_Button") || Input.GetButtonDown("B_Button"))
                    {
                        Debug.Log("Fail !");
                        gameIsFinished = true;
                    }
                }

                if (currentParryButton == 3)
                {
                    parryButton3.SetActive(true);

                    if (Input.GetButtonDown("B_Button"))
                    {
                        Debug.Log("Parry !");
                        numberOfParries++;
                        parryButton3.SetActive(false);
                    }

                    if (Input.GetButtonDown("X_Button") || Input.GetButtonDown("Y_Button"))
                    {
                        Debug.Log("Fail !");
                        gameIsFinished = true;
                    }
                }
            }


            public void EndOfGameFeedback()
            {
                if (gameIsWon)
                {
                    //Win feedback
                    soundManager.PlayVictory();
                    victoryFeedback.SetActive(true);
                }
                else
                {
                    //Loss feedback
                    soundManager.PlayDefeat();
                    defeatFeedback.SetActive(true);
                }
            }

            private IEnumerator StartCooldown()
            {
                yield return new WaitForSeconds(cooldownTime);
            }

            /*public bool HasWon()
            {
                bool allObjectsPassed = true;
                bool allObjectsOutOfZone = true;

                foreach (ObjectMovement objMovement in activeObjects)
                {
                    if (!objMovement.hasBeenInZone)
                    {
                        allObjectsPassed = false;
                    }
                }
                foreach (ObjectMovement objMovement in activeObjects)
                {
                    if (objMovement.InZone())
                    {
                        allObjectsOutOfZone = false;
                    }
                }
                Debug.Log(allObjectsOutOfZone);
                return allObjectsPassed && allObjectsOutOfZone && objectSpawned >= objectsNumber && fruitsRemaining == 0;
            }

            /*public void DisplayScore()
            {
                // From int
                foreach (GameObject display in scoreDisplays)
                {
                    display.SetActive(false);
                }

                scoreDisplays[fruitsRemaining].SetActive(true);
            }

            private IEnumerator StartCooldown()
            {
                canCut = false;
                yield return new WaitForSeconds(cooldownTime);
                canCut = true;
            }*/
        }      
    }
}