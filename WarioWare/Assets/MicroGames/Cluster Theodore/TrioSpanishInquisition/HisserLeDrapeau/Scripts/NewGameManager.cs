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
            public int objectiveNumber;
            public bool gameIsWon;
            public Transform target;
            public float radius;
            public ParticleSystem feedbackParticle;
            [HideInInspector] public int score;

            private SoundManager soundManager;

            public override void Start()
            {
                base.Start(); //Do not erase this line!
                feedbackParticle.GetComponent<ParticleSystem>();
                soundManager = GetComponentInChildren<SoundManager>();

                /*switch (currentTime)
                {
                    case Manager.BPM.Slow:
                        soundManager.PlayFlagMusicSlow();
                        break;

                    case Manager.BPM.Medium:
                        soundManager.PlayFlagMusicMedium();
                        break;

                    case Manager.BPM.Fast:
                        soundManager.PlayFlagMusicFast();
                        break;

                    case Manager.BPM.SuperFast:
                        soundManager.PlayFlagMusicSuperFast();
                        break;
                }*/
                
                switch (currentDifficulty)
                {
                    case Manager.Difficulty.EASY:
                        objectiveNumber = 3;
                        break;

                    case Manager.Difficulty.MEDIUM:
                        objectiveNumber = 4;
                        break;

                    case Manager.Difficulty.HARD:
                        objectiveNumber = 5;
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
                }

                if (Input.GetKey(KeyCode.A))
                {
                    feedbackParticle.Play();
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

            }
        }
    }
}