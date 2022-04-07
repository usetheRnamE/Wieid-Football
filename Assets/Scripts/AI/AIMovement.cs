using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ball;

public class AIMovement : MonoBehaviour
{
    [HideInInspector] public static AIMovement AIInstance;

    public Transform startPoint;

    private Vector2 ballPosition;

    private float minReactionLength = 5, AIMoveSpeed = 10;
    private void Awake()
    {
        AIInstance = this;
    }
    private void Update()
    {
        ballPosition = BallMovement.instance.transform.position;

        FollowTheBall();
    }
    private void FollowTheBall()
    {
        if (Vector2.Distance(transform.position, ballPosition) <= minReactionLength)
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(ballPosition.x, transform.position.y), AIMoveSpeed * Time.deltaTime);
        else GoToStartPosition();
    }
    private void GoToStartPosition() { transform.position = Vector2.MoveTowards(transform.position, startPoint.position, .5f * AIMoveSpeed * Time.deltaTime); }    
}
