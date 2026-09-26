using System;
using UnityEngine;

public class BouncySurface : MonoBehaviour
{
    public float bounceStrength = 0f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Ball ball))
        { 
            ball.currentSpeed += bounceStrength;
        }
    }
}
