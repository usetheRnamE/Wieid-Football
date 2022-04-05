using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

namespace Ball
{
    public class BallMovement : MonoBehaviour
    {
        [SerializeField] private float maxBallSpeed, ballAcc;
        private float zCurValue;

        private Vector2 moveVector, clampedVector, randomVector, turnVector;

        private bool isBlueStart;

        [HideInInspector] public static BallMovement instance;

        private void OnEnable()
        {
            instance = this;
        }

        private void Awake()
        {
            zCurValue = transform.position.z;
            turnVector = Vector3.one;

            if (!isBlueStart)
            {
                randomVector = new Vector3(Random.RandomRange(0f, 1f), -1, 0);
                isBlueStart = true;
            }
            else
            {
                randomVector = new Vector3(Random.RandomRange(0f, 1f), 1, 0);
                isBlueStart = false;
            }
        }

        private void Update()
        {
            BallMove();
        }

        void BallMove()
        {
            moveVector = randomVector * ballAcc * Time.deltaTime;

            clampedVector = Vector3.ClampMagnitude(new Vector3(moveVector.x, moveVector.y, zCurValue), maxBallSpeed);

            transform.Translate(clampedVector * turnVector);
        }
        
        public void OnBallCollide(byte XorY)
        {

            switch (XorY)
                {
                    case 0:
                    turnVector *= new Vector2(-1, 1);
                        break;
                    case 1:
                    turnVector *= new Vector2(1, -1);
                        break;
                }
                //ballVector = Vector2.one;                       
        }


        

   


        /* private void OnCollisionEnter2D(Collision2D collision)
         {
             switch (collision.gameObject.tag)
             {
                 case "Borders":
                     Bounce();
                     break;
             }
         }

         void Bounce()
         {
             transform.rotation = new Quaternion(0, 90, 0, 1);
         }*/
    }
}
