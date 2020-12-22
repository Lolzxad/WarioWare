using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Testing;

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
            public ObjectsType[] objectsType;
            public List<ObjectMovement> activeObjects = new List<ObjectMovement>();
            public GameObject spawner;
            public GameObject neutralCursor;
            public GameObject activeCursor;
            public GameObject victoryFeedback;
            public GameObject defeatFeedback;
            public GameObject explosionSprite;
            public Animator animator;
            public int objectsNumber;
            public int objectSpawned;
            public int numberOfBombsNeeded;
            public float tickTimer;
            public float cooldownTime;
            public bool gameIsWon;
            public bool gameIsFinished;
            public bool canCut;
            public Transform target;
            public Transform trueTarget;
            public float radius;
            public float speed;
            public float cooldown;
            public Vector3 baseSpawnPosition;
            public ParticleSystem cutParticle;
            public ParticleSystem fruitParticle;
            public ParticleSystem explosionParticle;

            private SoundManager soundManager;

            public override void Start()
            {
                base.Start(); //Do not erase this line!

                currentDifficulty = Difficulty.MEDIUM;

                canCut = true;
                cooldownTime = (0.5f * 60) / bpm;
                cutParticle.GetComponent<ParticleSystem>();
                fruitParticle.GetComponent<ParticleSystem>();
                explosionParticle.GetComponent<ParticleSystem>();
                speed = bpm / 5;
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
                        objectsNumber = 3;
                        numberOfBombsNeeded = 0;

                        break;

                    case Difficulty.MEDIUM:
                        objectsNumber = 4;
                        numberOfBombsNeeded = 2;

                        break;

                    case Difficulty.HARD:
                        objectsNumber = 5;
                        numberOfBombsNeeded = 3;

                        break;
                }

                objectsType = new ObjectsType[objectsNumber];
                RandomizeObjects();
            }

            public void Update()
            {              
                if (!gameIsFinished && canCut)
                {
                    InputFailSuccessConditions();
                }
                
                if (HasWon())
                {
                    gameIsFinished = true;
                    FinishGame();
                }
            }

            //TimedUpdate is called once every tick.

            public override void TimedUpdate()
            {
                base.TimedUpdate();


                if ((Tick < 8 && !gameIsWon) || !gameIsFinished)
                {
                    Spawner();
                }

                if (Tick == 8)
                {
                    //Manager.Instance.Result (gameIsWon);
                }

                if ((Tick == 8 && !gameIsWon) || gameIsFinished)
                {
                    
                }
            }
             
            private void Spawner()
            {
                if (objectSpawned < objectsNumber)
                {
                    ObjectsType currentType = objectsType[objectSpawned];

                    //create new clone
                    GameObject newObjectInstance = GameObject.Instantiate(objects[(int)currentType], spawner.transform.position, Quaternion.identity);
                    objectSpawned++;

                    //activate the gameobject (because the templates are inactive in the scene, so it makes the clone inactive when instantiated)
                    newObjectInstance.SetActive(true);

                    //add the script to a list of all the button script existing
                    activeObjects.Add(newObjectInstance.GetComponent<ObjectMovement>());

                    soundManager.PlayObjectThrown();
                }          
            }

            private void InputFailSuccessConditions()
            {

                bool objectCut = false;

                foreach (ObjectMovement objMovement in activeObjects)
                {
                    if (objMovement.InZone())
                    {
                        neutralCursor.SetActive(false);
                        activeCursor.SetActive(true);

                        if (Input.GetButtonDown("X_Button") || Input.GetKeyDown(KeyCode.X))
                        {
                            animator.SetTrigger("Cut");

                            if (objMovement.type == ObjectsType.fruit)
                            {
                                CutFruit(objMovement);
                            }
                            else if (objMovement.type == ObjectsType.bomb)
                            {
                                CutBomb(objMovement);
                            }
                            objectCut = true;
                        }                    
                    }
                }

                if (Input.GetButtonDown("X_Button") || Input.GetKeyDown(KeyCode.X))
                {
                    animator.SetTrigger("Cut");

                    if (!objectCut)
                    {
                        CutFail();
                    }

                    activeCursor.SetActive(false);
                    neutralCursor.SetActive(true);
                    //Cooldown 0.5 tick
                    StartCoroutine(StartCooldown());
                }                                             
            }

            public void CutFruit(ObjectMovement objMovement)
            {
                cutParticle.Play();
                fruitParticle.Play();
                soundManager.PlayKatana();
                soundManager.PlayGoodButton();

                objMovement.gameObject.SetActive(false);
                //activeObjects.Remove(objMovement);
                //Destroy(objMovement.gameObject);
            }

            public void CutBomb(ObjectMovement objMovement)
            {
                gameIsFinished = true;
                gameIsWon = false;
                FinishGame();
                cutParticle.Play();
                explosionParticle.Play();
                explosionSprite.SetActive(true);
                soundManager.PlayKatana();
                soundManager.PlayWrongButton();

                objMovement.gameObject.SetActive(false);
                //activeObjects.Remove(objMovement);
                //Destroy(objMovement.gameObject);    
            }

            public void CutFail()
            {
                cutParticle.Play();
                soundManager.PlayKatana();
            }

            public void RandomizeObjects()
            {
                int numberOfBombs = 0;
                while (numberOfBombs < numberOfBombsNeeded)
                {
                    int randomPosition;

                    do
                    {
                        randomPosition = Random.Range(0, objectsNumber);
                    }
                    while (objectsType[randomPosition] == ObjectsType.bomb);

                    objectsType[randomPosition] = ObjectsType.bomb;
                    numberOfBombs++;
                }
            }

            public void FinishGame()
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

            public bool HasWon()
            {
                bool allObjectsPassed = true;

                foreach (ObjectMovement objMovement in activeObjects)
                {
                    if (!objMovement.hasBeenInZone)
                    {
                        allObjectsPassed = false;
                    }
                }
                return allObjectsPassed && objectSpawned >= objectsNumber;
            }

            private IEnumerator StartCooldown()
            {
                canCut = false;
                yield return new WaitForSeconds(cooldownTime);
                canCut = true;
            }
        }      
    }
}