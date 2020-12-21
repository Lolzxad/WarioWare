using System.Collections.Generic;
using Testing;
using UnityEngine;

namespace SpanishInquisition
{

    namespace VegetablePirate
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

            public GameObject[] objects;
            public List<ObjectMovement> activeObjects = new List<ObjectMovement>();
            public GameObject spawner;
            public GameObject neutralCursor;
            public GameObject activeCursor;
            public GameObject victoryFeedback;
            public GameObject defeatFeedback;
            public GameObject explosionSprite;
            public Animator animator;
            public int objectiveNumber;
            public int numberOfBombs;
            public float tickTimer;
            public bool gameIsWon;
            public bool test;
            public Transform target;
            public Transform trueTarget;
            public float radius;
            public float speed;
            public float cooldown;
            public Vector3 baseSpawnPosition;
            public ParticleSystem cutParticle;
            public ParticleSystem fruitParticle;
            public ParticleSystem explosionParticle;
            [HideInInspector] public int score;

            private SoundManager soundManager;

            public override void Start()
            {
                base.Start(); //Do not erase this line!

                currentDifficulty = Difficulty.MEDIUM;

                cutParticle.GetComponent<ParticleSystem>();
                fruitParticle.GetComponent<ParticleSystem>();
                explosionParticle.GetComponent<ParticleSystem>();
                speed = bpm / 5;
                score = 0;
                soundManager = GetComponentInChildren<SoundManager>();
                baseSpawnPosition = spawner.transform.position;

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

                        break;

                    case Difficulty.MEDIUM:
                        objectiveNumber = 4;

                        break;

                    case Difficulty.HARD:
                        objectiveNumber = 5;

                        break;
                }
            }

            public void Update()
            {
                if (!test)
                {
                    Spawner();
                    test = true;
                }
                

                InputFailSuccessConditions();

                if (score >= objectiveNumber && !gameIsWon)
                {
                    gameIsWon = true;
                    soundManager.PlayVictory();
                    victoryFeedback.SetActive(true);
                }

                /*switch (score)
                {
                    case 5:
                        animator.SetBool("FirstButton", false);
                        animator.SetBool("SecondButton", true);
                        break;

                    case 4:
                        animator.SetBool("ThirdButton", false);
                        animator.SetBool("FirstButton", true);
                        break;

                    case 3:
                        animator.SetBool("SecondButton", false);
                        animator.SetBool("ThirdButton", true);
                        break;

                    case 2:
                        animator.SetBool("FirstButton", false);
                        animator.SetBool("SecondButton", true);
                        break;

                    case 1:
                        animator.SetBool("FirstButton", true);
                        break;

                    default:
                        break;
                }*/
            }

            //TimedUpdate is called once every tick.

            public override void TimedUpdate()
            {
                base.TimedUpdate();

                tickTimer = Time.deltaTime;
                Debug.Log(tickTimer);

                if (Tick < 8 && !gameIsWon)
                {
                    Spawner();
                }

                if (Tick == 8)
                {
                    //Manager.Instance.Result (gameIsWon);
                }

                if (Tick == 8 && !gameIsWon)
                {
                    soundManager.PlayDefeat();
                    defeatFeedback.SetActive(true);
                }
            }

            private void Spawner()
            {
                if (objectiveNumber == 3 || (objectiveNumber == 4 && numberOfBombs >= 2) || (objectiveNumber == 5 && numberOfBombs >= 3))
                {
                    int objectNumber = 0;

                    //create new clone
                    GameObject newObjectInstance = GameObject.Instantiate(objects[objectNumber], spawner.transform.position, Quaternion.identity);

                    //activate the gameobject (because the templates are inactive in the scene, so it makes the clone inactive when instantiated)
                    newObjectInstance.SetActive(true);

                    //add the script to a list of all the button script existing
                    activeObjects.Add(newObjectInstance.GetComponent<ObjectMovement>());

                    soundManager.PlayObjectThrown();
                }

                if (objectiveNumber == 4 && numberOfBombs < 2)
                {
                    int objectNumber = Random.Range(0, 2);

                    if (objectNumber == 1)
                    {
                        numberOfBombs++;
                    }

                    GameObject newObjectInstance = GameObject.Instantiate(objects[objectNumber], spawner.transform.position, Quaternion.identity);

                    newObjectInstance.SetActive(true);

                    activeObjects.Add(newObjectInstance.GetComponent<ObjectMovement>());

                    soundManager.PlayObjectThrown();
                }

                if (objectiveNumber == 5 && numberOfBombs < 3)
                {
                    int objectNumber = Random.Range(0, 2);

                    if (objectNumber == 1)
                    {
                        numberOfBombs++;
                    }

                    GameObject newObjectInstance = GameObject.Instantiate(objects[objectNumber], spawner.transform.position, Quaternion.identity);

                    newObjectInstance.SetActive(true);

                    activeObjects.Add(newObjectInstance.GetComponent<ObjectMovement>());

                    soundManager.PlayObjectThrown();
                }

            }

            private void InputFailSuccessConditions()
            {
                // Iterate over each objects
                foreach (ObjectMovement objMovement in activeObjects)
                {
                    if (objMovement.InZone())
                    {
                        neutralCursor.SetActive(false);
                        activeCursor.SetActive(true);

                        if (Input.GetButtonDown("X_Button") || Input.GetKeyDown(KeyCode.X) && objMovement.type == ObjectsType.fruit)
                        {
                            animator.SetBool("isCutting", true);
                            CutFruit(objMovement);
                        } else
                        {
                            if ((Input.GetButtonDown("X_Button") || Input.GetKeyDown(KeyCode.X) && objMovement.type == ObjectsType.bomb)
)
                            {
                                animator.SetBool("isCutting", true);
                                CutBomb(objMovement);
                            }
                        }

                        return;
                    }
                }


                //No objects are found in the zone
                // si un bouton est appuyé : échec
                if (Input.GetButtonDown("X_Button") || Input.GetKeyDown(KeyCode.X))
                {
                    animator.SetBool("isCutting", true);
                    CutFail();
                }

                activeCursor.SetActive(false);
                neutralCursor.SetActive(true);
                animator.SetBool("isCutting", false);
                explosionSprite.SetActive(false);
                //Cooldown 0.5 tick
            }


            public void CutFruit(ObjectMovement objMovement)
            {

                if (score < objectiveNumber)
                {
                    score++;

                    cutParticle.Play();
                    fruitParticle.Play();
                    soundManager.PlayKatana();
                    soundManager.PlayGoodButton();

                    activeObjects.Remove(objMovement);
                    Destroy(objMovement.gameObject);
                }
            }

            public void CutBomb(ObjectMovement objMovement)
            {
                if (score >= 0 && !gameIsWon)
                {
                    score--;
                    cutParticle.Play();
                    explosionParticle.Play();
                    explosionSprite.SetActive(true);
                    soundManager.PlayKatana();
                    soundManager.PlayWrongButton();

                    activeObjects.Remove(objMovement);
                    Destroy(objMovement.gameObject);
                }
            }

            public void CutFail()
            {
                if (score >= 0 && !gameIsWon)
                {
                    cutParticle.Play();
                    soundManager.PlayKatana();
                }
            }          
        }
    }
}