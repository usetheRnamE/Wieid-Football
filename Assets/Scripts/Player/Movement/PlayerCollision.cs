using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ball;

namespace Player
{
    public class PlayerCollision : MonoBehaviour
    {
        public Transform[] borderPoints;

        private Vector2 curPosition;

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

            if (curPosition.x + transform.localScale.x <= borderPoints[1].position.x 
                && curPosition.x >= borderPoints[0].position.x - transform.localScale.x) PlayerMovement.playerInstance.PlayerMove();
        }
    }
}