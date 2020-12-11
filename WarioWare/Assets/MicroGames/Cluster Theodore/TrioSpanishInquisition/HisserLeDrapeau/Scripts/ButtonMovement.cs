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
            public ButtonsType type;

            private NewGameManager manager;

            public override void Start()
            {
                base.Start(); //Do not erase this line!
                manager = GameObject.Find("Manager").GetComponent<NewGameManager>();
                radius = manager.radius;
                target = manager.target;
                //spawner = manager.spawner.transform;
            }       

            private void Update()
            {
                distanceToTarget = Mathf.Abs((target.position - transform.position).magnitude);
                if (distanceToTarget <= radius)
                {
                    if (Input.GetButtonDown("A_Button") && type == ButtonsType.A)
                    {
                        manager.score++;
                        Destroy(gameObject);
                        //Particle or effect
                    }

                    if (Input.GetButtonDown("B_Button") && type == ButtonsType.B)
                    {
                        manager.score++;
                        //Flag movement
                        Destroy(gameObject);
                    }

                    if (Input.GetButtonDown("X_Button") && type == ButtonsType.X)
                    {
                        manager.score++;
                        Destroy(gameObject);
                    }

                    if (Input.GetButtonDown("Y_Button") && type == ButtonsType.Y)
                    {
                        manager.score++;
                        Destroy(gameObject);
                    }

                }
            }

            //FixedUpdate is called on a fixed time.
            public override void FixedUpdate()
            {
                base.FixedUpdate(); //Do not erase this line!

                transform.position += Vector3.down * speed * Time.deltaTime;

            }

            //TimedUpdate is called once every tick.
            public override void TimedUpdate()
            {

            }
        }
    }
}