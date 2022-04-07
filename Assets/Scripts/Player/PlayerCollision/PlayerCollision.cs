using UnityEngine;
using System;

namespace Player
{
    public class PlayerCollision : MonoBehaviour
    {
        public Transform[] borderPoints;

        private Vector2 curPosition;

        private float playerWidth;
        private void Awake()
        {
            playerWidth = transform.localScale.x * .5f;
        }
        private void LateUpdate()
        {
            CheckCollision();
        }
        private void CheckCollision()
        {
            curPosition = transform.position;

            curPosition.x = Mathf.Clamp(curPosition.x, borderPoints[0].position.x + playerWidth, borderPoints[1].position.x - playerWidth);

            transform.position = curPosition;

            /*    if (curPosition.x + transform.localScale.x * .5 <= borderPoints[1].position.x
                    && curPosition.x - transform.localScale.x * .5 >= borderPoints[0].position.x)
                {
                    PlayerMovement.playerInstance.PlayerTurnsRight();
                    PlayerMovement.playerInstance.PlayerTurnsLeft();
                }

                else if (Math.Abs(curPosition.x + transform.localScale.x * .5 - borderPoints[1].position.x) <= minContactRadius)
                    PlayerMovement.playerInstance.PlayerTurnsLeft();

                else if (Math.Abs(curPosition.x - transform.localScale.x * .5 - borderPoints[0].position.x) <= minContactRadius)
                    PlayerMovement.playerInstance.PlayerTurnsRight();
            }*/
        }
    }
}