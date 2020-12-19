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
            private float radius;
            private float distanceToTarget;
            public float speed;
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
                speed = manager.speed;

                //spawner = manager.spawner.transform;
            }       

            private void Update()
            {
                //fruit or bomb movement
                transform.position += Vector3.left * speed * Time.deltaTime;
                transform.localScale += new Vector3(1, 0, 1) * Time.deltaTime;
                transform.Rotate (Vector3.up * speed * Time.deltaTime);
            }

            private void OnBecameInvisible()
            {
                manager.activeObjects.Remove(this);
                Destroy(gameObject);
            }
        }
    }
}