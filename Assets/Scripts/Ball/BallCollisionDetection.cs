using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ball
{
    public class BallCollisionDetection : MonoBehaviour
    {
        public Transform[] borderPoints;

        private Vector2 curPosition;

        private void Update()
        {
            CollisionDetect();
        }

        private void CollisionDetect()
        {
            curPosition = transform.position;

                if (curPosition.x >= borderPoints[1].position.x || curPosition.x <= borderPoints[0].position.x) BallMovement.instance.OnBallCollide(0); 
                else if (curPosition.y >= borderPoints[1].position.y || curPosition.y <= borderPoints[0].position.y) BallMovement.instance.OnBallCollide(1);
            
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
