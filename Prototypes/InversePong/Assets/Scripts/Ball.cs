using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    private Rigidbody2D _rigidBody;

    public float speed = 6.0f;

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
        float x = Random.value < 0.5f ? -1.0f : 1.0f;
        float y = (Random.value < 0.5f ? -1.0f : 1.0f) * Random.Range(0.5f, 0.9f);

        Vector2 direction = new Vector2(x, y);

        _rigidBody.linearVelocity = direction.normalized * speed;
    }

    private void FixedUpdate()
    {
        if (_rigidBody.linearVelocity.sqrMagnitude < 0.1f) return;
        _rigidBody.linearVelocity = _rigidBody.linearVelocity.normalized * speed;
    }
}