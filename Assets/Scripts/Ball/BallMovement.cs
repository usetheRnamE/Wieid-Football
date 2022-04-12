using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;
using GameOverSystem;

namespace Ball
{
    public class BallMovement : MonoBehaviour
    {
        [SerializeField] private float maxBallSpeed, ballAcc;
        private float zCurValue;

        private Vector2 moveVector, clampedVector, randomVector, turnVector;

        private bool isBlueStart;

        [HideInInspector] public static BallMovement instance;

        private float scaleChanger = 4, timeToBump = 0.1f, speedOgBumping = 50;
        private Vector3 defaultScale;

        private bool isGameOver = false;

        private void OnEnable()
        {
            instance = this;
        }

        private void Awake()
        {
            defaultScale = transform.localScale;

            zCurValue = transform.position.z;
            turnVector = Vector3.one;

            GOEventManager.GOEvent += OnGameOver;
        }

        private void Start()
        {
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
            if(! isGameOver) BallMove();
        }

        private void BallMove()
        {
            moveVector = randomVector * ballAcc * Time.deltaTime;

            clampedVector = Vector3.ClampMagnitude(new Vector3(moveVector.x, moveVector.y, zCurValue), maxBallSpeed);

            transform.Translate(clampedVector * turnVector);
        }
        
        public void OnBallCollide(byte XorY)
        {

            StartCoroutine(OnCollideBump());

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
        IEnumerator OnCollideBump()
        {
            Vector3 scaleChangeKoef = transform.localScale / scaleChanger;

            transform.localScale = Vector3.Lerp(transform.localScale, transform.localScale - scaleChangeKoef, Time.deltaTime * speedOgBumping);
            
            yield return new WaitForSeconds(timeToBump);

            while(transform.localScale != defaultScale) 
                transform.localScale = Vector3.Lerp(transform.localScale, defaultScale, Time.deltaTime * speedOgBumping);

            StopCoroutine(OnCollideBump());
        }

        private void OnGameOver()
        {
            isGameOver = true;
        }

        private void OnDisable()
        {
            GOEventManager.GOEvent -= OnGameOver;
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
