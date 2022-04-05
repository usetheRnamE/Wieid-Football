using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float maxSpeed = 16f;
        [SerializeField] private float moveAcc = 4f;

        [SerializeField] private Transform startPoint;

        private Vector2 xInputVector, clampedVector;
        // move when unpaused (use event system)

        [HideInInspector] public static PlayerMovement playerInstance;
        private void Awake()
        {
            playerInstance = this;

            Restart();
        }
        public void PlayerMove()
        {
            if (Input.GetAxis("Horizontal") != 0)
            {
                xInputVector = Vector2.right * Input.GetAxis("Horizontal") * moveAcc * Time.deltaTime;

                clampedVector = Vector3.ClampMagnitude(new Vector3(xInputVector.x,0, startPoint.position.z), maxSpeed);

                transform.Translate(clampedVector);
            }               
        }
        private void Restart()
        {
            transform.position = startPoint.position;
        }
    }
}
