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
        private void Update()
        {
            PlayerMoves();
        }
        /*  public void PlayerMove()
          {
              if (Input.GetKeyDown(KeyCode.D)) xInputVector = Vector2.right * moveAcc * Time.deltaTime;

              else if (Input.GetKeyDown(KeyCode.S)) xInputVector = Vector2.left * moveAcc * Time.deltaTime;

              else xInputVector = Vector2.zero;

              clampedVector = Vector3.ClampMagnitude(new Vector3(xInputVector.x, 0, startPoint.position.z), maxSpeed);

              transform.Translate(clampedVector);
          }*/
        private void PlayerMoves()
        {
            if (Input.GetKey(KeyCode.D)) xInputVector = Vector2.right * moveAcc * Time.deltaTime;
  
            else if (Input.GetKey(KeyCode.A)) xInputVector = Vector2.left * moveAcc * Time.deltaTime;

            else xInputVector = Vector2.zero;

            clampedVector = Vector3.ClampMagnitude(new Vector3(xInputVector.x, 0, startPoint.position.z), maxSpeed);

            transform.Translate(clampedVector);
        }
        private void Restart()
        {
            transform.position = startPoint.position;
        }
    }
}
