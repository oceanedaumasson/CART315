using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    private Rigidbody2D _rigidBody;

    public float speed = 5.0f;
    public float maxSpeed = 20.0f;
    public float currentSpeed { get; set; }

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    public void ResetBall()
    {
        _rigidBody.linearVelocity = Vector2.zero;
        _rigidBody.angularVelocity = 0;
        transform.position = Vector3.zero;
    }

    public void AddStartingForce()
    {
        float x = Random.value < 0.5f ? -1f : 1f;
        float y = Random.value < 0.5f
            ? Random.Range(-1f, -0.5f)
            : Random.Range(0.5f, 1f);

        Vector2 direction = new Vector2(x, y).normalized;
        _rigidBody.AddForce(direction * speed, ForceMode2D.Impulse);
        currentSpeed = speed;
    }

    private void FixedUpdate()
    {
        // Clamp the velocity of the ball to the max speed
        Vector2 direction = _rigidBody.linearVelocity.normalized;
        currentSpeed = Mathf.Min(currentSpeed, maxSpeed);
        _rigidBody.linearVelocity = direction * currentSpeed;
    }

// private void Update()
    //{
    //     speed = Mathf.Min(speed + speedIncreasePerSec * Time.deltaTime, maxSpeed);
    // }
}