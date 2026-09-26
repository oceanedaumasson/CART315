using UnityEngine;

public class ComputerPaddle : Paddle
{
    [SerializeField]
    private Rigidbody2D ball;

    private void FixedUpdate()
    {
        // Move the paddle in the direction of the ball to track it
        if (ball.position.y > rb.position.y) {
            rb.AddForce(Vector2.up * speed);
        } else if (ball.position.y < rb.position.y) {
            rb.AddForce(Vector2.down * speed);
        }
    }

}
