using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpanishInquisition
{
    namespace VegetablePirate
    {

        public enum ObjectsType
        {
            fruit,
            bomb
        }

        public class ObjectMovement : TimedBehaviour
        {
            private Transform target;
            private Transform trueTarget;
            private float radius;
            private float distanceToTarget;
            public float speed;
            public float scaleSpeed = 10f;
            public ObjectsType type;


            private GameManager manager;
            private SoundManager soundMngr;

            public bool InZone ()
            {
                distanceToTarget = Mathf.Abs((target.position - transform.position).magnitude);
                if (distanceToTarget <= radius)
                    return true;
                else
                    return false;                        
            }

            public override void Start()
            {
                base.Start(); //Do not erase this line!               
                manager = GameManager.instance;
                soundMngr = SoundManager.instance;
                radius = manager.radius;
                target = manager.target;
                trueTarget = manager.trueTarget;
                speed = manager.speed;

                //spawner = manager.spawner.transform;
            }       

            private void Update()
            {
                //fruit or bomb movement
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, trueTarget.position, speed * Time.deltaTime); 
                if (transform.localScale.x < 1)
                {
                    transform.localScale += new Vector3(1, 1, 1) * scaleSpeed * Time.deltaTime;
                }
                
                transform.Rotate (Vector3.forward * (750 * Time.deltaTime));
            }

            private void OnBecameInvisible()
            {
                manager.activeObjects.Remove(this);
                Destroy(gameObject);
            }
        }
    }
}