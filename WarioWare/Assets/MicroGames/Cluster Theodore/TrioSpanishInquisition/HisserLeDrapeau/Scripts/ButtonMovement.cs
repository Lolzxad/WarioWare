using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpanishInquisition
{
    namespace HisserLeDrapeau
    {

        public enum ButtonsType
        {
            A, 
            B,
            X,
            Y
        }
        public class ButtonMovement : TimedBehaviour
        {
            private Transform target;
            private Transform spawner;
            private float radius;
            private float distanceToTarget;
            public float speed;
            public float flagToSpawner;
            public GameObject flag;
            public ButtonsType type;
            public ParticleSystem feedbackParticle;

            private NewGameManager manager;
            private SoundManager soundMngr;

            public override void Start()
            {
                base.Start(); //Do not erase this line!
                manager = GameObject.Find("Manager").GetComponent<NewGameManager>();
                soundMngr = GameObject.Find("/Manager/SoundManager").GetComponent<SoundManager>();
                radius = manager.radius;
                target = manager.target;
                speed = manager.speed;
                flagToSpawner = manager.flagToSpawner;
                flag = manager.flag;
                feedbackParticle = manager.feedbackParticle;
                //spawner = manager.spawner.transform;
            }       

            private void Update()
            {
                transform.position += Vector3.down * speed * Time.deltaTime;

                distanceToTarget = Mathf.Abs((target.position - transform.position).magnitude);
                if (distanceToTarget <= radius)
                {
                    if (Input.GetButtonDown("A_Button") && type == ButtonsType.A)
                    {
                        manager.score++;

                        if (flag.transform.position.y < (flag.transform.position.y + flagToSpawner))
                        {
                            flag.transform.position += Vector3.up * flagToSpawner * Time.deltaTime;
                        }
                       
                        feedbackParticle.Play();
                        soundMngr.PlayGoodButton();
                        Destroy(gameObject);
                    }

                    if (Input.GetButtonDown("B_Button") && type == ButtonsType.B)
                    {
                        manager.score++;

                        if (flag.transform.position.y < (flag.transform.position.y + flagToSpawner))
                        {
                            flag.transform.position += Vector3.up * flagToSpawner * Time.deltaTime;
                        }

                        soundMngr.PlayGoodButton();
                        Destroy(gameObject);
                    }

                    if (Input.GetButtonDown("X_Button") && type == ButtonsType.X)
                    {
                        manager.score++;

                        if (flag.transform.position.y < (flag.transform.position.y + flagToSpawner))
                        {
                            flag.transform.position += Vector3.up * flagToSpawner * Time.deltaTime;
                        }

                        soundMngr.PlayGoodButton();
                        Destroy(gameObject);
                    }

                    if (Input.GetButtonDown("Y_Button") && type == ButtonsType.Y)
                    {
                        manager.score++;

                        if (flag.transform.position.y < (flag.transform.position.y + flagToSpawner))
                        {
                            flag.transform.position += Vector3.up * flagToSpawner * Time.deltaTime;
                        }

                        soundMngr.PlayGoodButton();
                        Destroy(gameObject);
                    }
                }
            }
        }
    }
}