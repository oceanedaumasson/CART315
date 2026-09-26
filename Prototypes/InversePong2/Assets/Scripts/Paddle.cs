using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class Paddle : MonoBehaviour
{
    private Rigidbody2D _rigidBody;

    public float speed = 10.0f;
    public bool useDynamicBounce = true;

    public Vector2 direction;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    // FixedUpdate is called once per physics update
    private void FixedUpdate()
    {
        if (direction.sqrMagnitude == 0) return;

        _rigidBody.AddForce(direction * speed);
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (useDynamicBounce && collision.gameObject.CompareTag("Ball"))
        {
            Rigidbody2D ball = collision.rigidbody;
            Collider2D paddle = collision.otherCollider;

            Vector2 ballDirection = ball.linearVelocity.normalized;
            Vector2 contactDistance = ball.transform.position - paddle.bounds.center;
            Vector2 surfaceNormal = collision.GetContact(0).normal;
            Vector3 rotationAxis = Vector3.Cross(Vector3.up, surfaceNormal);

            // Rotate the direction of the ball
            float maxBounceAngle = 75f;
            float bounceAngle = contactDistance.y / paddle.bounds.size.y * maxBounceAngle;
            ballDirection = Quaternion.AngleAxis(bounceAngle, rotationAxis) * ballDirection;

// Prevent near-vertical bounces
            float minHorizontal = 0.3f; // tune this - higher = less steep angles allowed
            if (Mathf.Abs(ballDirection.x) < minHorizontal)
            {
                float sign = Mathf.Sign(ballDirection.x == 0 ? 1 : ballDirection.x);
                ballDirection.x = minHorizontal * sign;
                ballDirection = ballDirection.normalized;
            }

            ball.linearVelocity = ballDirection * ball.linearVelocity.magnitude;
        }
    }
}

