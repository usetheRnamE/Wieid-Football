using Player;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ball
{
    public class BallCollisionDetection : MonoBehaviour
    {
        public Transform[] borderPoints;

        private Vector2 curPosition;

        float minAllowableRaius = 0.05f;
        private void Update()
        {
            curPosition = transform.position;

            CollisionDetect();
            ClampBallIntoBounds();
        }
        private void CollisionDetect()
        {
                if (Math.Abs(curPosition.x - borderPoints[1].position.x) <= minAllowableRaius 
                || Math.Abs(curPosition.x - borderPoints[0].position.x) <= minAllowableRaius) BallMovement.instance.OnBallCollide(0); 
                else if (Math.Abs(curPosition.y - borderPoints[1].position.y) <= minAllowableRaius 
                || Math.Abs(curPosition.y - borderPoints[0].position.y) <= minAllowableRaius) BallMovement.instance.OnBallCollide(1);

            Vector3 playerPosition = PlayerMovement.playerInstance.transform.position;
            PlayersCollisionDetection(playerPosition);

            Vector3 AIPosition = AIMovement.AIInstance.transform.position;
            PlayersCollisionDetection(AIPosition);
        

            /*  else if((AIPosition.y <= transform.position.y + transform.localScale.y &&
                AIPosition.y >= transform.position.y - transform.localScale.y &&
                AIPosition.x <= transform.position.x + transform.localScale.x &&
                AIPosition.x >= transform.position.x - transform.localScale.x)) BallMovement.instance.OnBallCollide(0);*/
        }
        private void PlayersCollisionDetection(Vector3 playerPos)
        {
            if (playerPos.y <= transform.position.y + transform.localScale.y &&
              playerPos.y >= transform.position.y - transform.localScale.y &&
              playerPos.x <= transform.position.x + transform.localScale.x &&
              playerPos.x >= transform.position.x - transform.localScale.x) BallMovement.instance.OnBallCollide(1);
        }
        private void ClampBallIntoBounds()
        {
            curPosition.x = Mathf.Clamp(curPosition.x, borderPoints[0].position.x, borderPoints[1].position.x);
            curPosition.y = Mathf.Clamp(curPosition.y, borderPoints[0].position.y, borderPoints[1].position.y);

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
