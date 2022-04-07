using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ball;
using System;

namespace Player
{
    public class PlayerCollision : MonoBehaviour
    {
        public Transform[] borderPoints;

        private Vector2 curPosition;

        private float minContactRadius = 0.05f;
        private void Update()
        {
            CheckCollision();
        }
        private void CheckCollision()
        {
            Vector3 ballPosition = BallMovement.instance.gameObject.transform.position;

            if (ballPosition.y <= transform.position.y + transform.localScale.y &&
              ballPosition.y >= transform.position.y - transform.localScale.y &&
              ballPosition.x <= transform.position.x + transform.localScale.x &&
              ballPosition.x >= transform.position.x - transform.localScale.x) BallMovement.instance.OnBallCollide(1);

            curPosition = transform.position;

            if (curPosition.x + transform.localScale.x * .5 <= borderPoints[1].position.x
                && curPosition.x - transform.localScale.x * .5 >= borderPoints[0].position.x) PlayerMovement.playerInstance.PlayerMove();

            else if(Math.Abs(curPosition.x + transform.localScale.x * .5 - borderPoints[1].position.x) <= minContactRadius) 
                PlayerMovement.playerInstance.gameObject.transform.position = new Vector3((float)(-curPosition.x + transform.localScale.x *.5), curPosition.y);

            else if (Math.Abs(curPosition.x - transform.localScale.x * .5 -  borderPoints[0].position.x) <= minContactRadius)
                PlayerMovement.playerInstance.gameObject.transform.position = new Vector3((float)(-curPosition.x - transform.localScale.x * .5), curPosition.y);
        }
    }
}