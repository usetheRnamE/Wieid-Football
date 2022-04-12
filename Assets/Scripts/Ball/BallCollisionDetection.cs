using Player;
using System;
using UnityEngine;

namespace Ball
{
    public class BallCollisionDetection : MonoBehaviour
    {
        public Transform[] borderPoints;

        private Vector2 curPosition;

        float ballRadius;
        private void Update()
        {
            curPosition = transform.position;

            ballRadius = transform.localScale.y * .5f;

            CollisionDetect();
            ClampBallIntoBounds();
        }
        private void CollisionDetect()
        {
                if (Math.Abs(curPosition.x - borderPoints[1].position.x) <= ballRadius
                || Math.Abs(curPosition.x - borderPoints[0].position.x) <= ballRadius) BallMovement.instance.OnBallCollide(0); 
                else if (Math.Abs(curPosition.y - borderPoints[1].position.y) <= ballRadius
                || Math.Abs(curPosition.y - borderPoints[0].position.y) <= ballRadius) BallMovement.instance.OnBallCollide(1);

            if (PlayerMovement.playerInstance != null)
            {
                Vector3 playerPosition = PlayerMovement.playerInstance.transform.position;
                PlayersCollisionDetection(playerPosition);
            }

            if (AIMovement.AIInstance != null)
            {
                Vector3 AIPosition = AIMovement.AIInstance.transform.position;
                PlayersCollisionDetection(AIPosition);
            }       

            /*  else if((AIPosition.y <= transform.position.y + transform.localScale.y &&
                AIPosition.y >= transform.position.y - transform.localScale.y &&
                AIPosition.x <= transform.position.x + transform.localScale.x &&
                AIPosition.x >= transform.position.x - transform.localScale.x)) BallMovement.instance.OnBallCollide(0);*/
        }
        private void PlayersCollisionDetection(Vector3 colVector)
        {
            if (colVector.y <= transform.position.y + transform.localScale.y &&
              colVector.y >= transform.position.y - transform.localScale.y &&
              colVector.x <= transform.position.x + transform.localScale.x &&
              colVector.x >= transform.position.x - transform.localScale.x) BallMovement.instance.OnBallCollide(1);
        }

        private void ClampBallIntoBounds()
        {
            curPosition.x = Mathf.Clamp(curPosition.x, borderPoints[0].position.x + ballRadius, borderPoints[1].position.x - ballRadius);
            curPosition.y = Mathf.Clamp(curPosition.y, borderPoints[0].position.y + ballRadius, borderPoints[1].position.y - ballRadius);

            transform.position = curPosition;
        }
        /* private void CollisionAction(sbyte XorY)
         { 
             switch (XorY)
             {
                 case 0:
                     ballVector = new Vector2(-1, 1);
                     isTurned = true;
                     break;
                 case 1:
                    ballVector = new Vector2(1, -1);
                     isTurned = true;
                     break;
             }
             ballVector = Vector2.one;
             //     isTurned = true;
         }*/
        //  transform.Rotate(new Vector3(0, 0, transform.rotation.z + sign * 135)); } 
    }
}
