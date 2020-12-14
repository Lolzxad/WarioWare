using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Testing;

namespace SpanishInquisition
{

    namespace HisserLeDrapeau
    {
        public class NewGameManager : TimedBehaviour
        {
            public GameObject[] buttons;
            public GameObject spawner;
            public GameObject flag;
            public int objectiveNumber;
            public bool gameIsWon;
            public Transform target;
            public float radius;
            public float speed;
            public float flagToSpawner;
            public ParticleSystem feedbackParticle;
            [HideInInspector] public int score;

            private SoundManager soundManager;

            public override void Start()
            {
                base.Start(); //Do not erase this line!
                feedbackParticle.GetComponent<ParticleSystem>();
                speed = bpm / 10;
                flag = GameObject.Find("/Graphs/Flag");
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
                        objectiveNumber = 3;
                        FlagMove();
                        break;

                    case Difficulty.MEDIUM:
                        objectiveNumber = 4;
                        FlagMove();
                        break;

                    case Difficulty.HARD:
                        objectiveNumber = 5;
                        FlagMove();
                        break;
                }
            }

            //FixedUpdate is called on a fixed time.
            public override void FixedUpdate()
            {
                base.FixedUpdate(); //Do not erase this line!

                if (score >= objectiveNumber)
                {
                    gameIsWon = true;
                    //soundManager.PlayVictory();
                    GameObject.Find("/Graphs/Victory/Typo victoire").SetActive(true);
                    GameObject.Find("/Graphs/Victory/Feedback victoire").SetActive(true);
                }
            }

            //TimedUpdate is called once every tick.
            public override void TimedUpdate()
            {
                if (Tick < 8)
                {
                    Spawner();
                }

                if (Tick == 8)
                {
                    Manager.Instance.Result(gameIsWon);
                }

                if (Tick == 8 && !gameIsWon)
                {
                    soundManager.PlayDefeat();
                    GameObject.Find("/Graphs/Defeat/Typo défaite").SetActive(true);
                    GameObject.Find("/Graphs/Defeat/Feedback défaite").SetActive(true);
                }
            }

            private void Spawner()
            {
                int buttonNumber = Random.Range(0, 4);

                switch (buttonNumber)
                {
                    case 3:
                        GameObject.Instantiate(buttons[3], spawner.transform.position, Quaternion.identity);
                        soundManager.PlayButtonApparition();
                        break;

                    case 2:
                        GameObject.Instantiate(buttons[2], spawner.transform.position, Quaternion.identity);
                        soundManager.PlayButtonApparition();
                        break;

                    case 1:
                        GameObject.Instantiate(buttons[1], spawner.transform.position, Quaternion.identity);
                        soundManager.PlayButtonApparition();
                        break;

                    case 0:
                        GameObject.Instantiate(buttons[0], spawner.transform.position, Quaternion.identity);
                        soundManager.PlayButtonApparition();
                        break;

                    default:
                        Debug.Log("Wrong button index");
                        break;  
                }
            }

            private void FlagMove()
            {
                flagToSpawner = ((spawner.transform.position - flag.transform.position).magnitude) / objectiveNumber;
            }
        }
    }
}