using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public Score score;
    public Ball ball;
    public GameStates gameState;

    // Time interval for switching sides, can be edited in Unity
    public float minTime = 6f;
    public float maxTime = 16f;
    public GameObject switchText; 
    
    private bool isInverseMode = false;
    
    // Set all of these in Unity
    public PlayerController player;
    public CPUController cpu;
    public Paddle leftPaddle;
    public Paddle rightPaddle;
    
    private void Start()
    {
        StartCoroutine(SetInverseMode()); // Starts timer to switch sides
        ApplyPaddles();
        
        switchText.SetActive(false); // Hide text at start
        
        StartRound();
    }

    public void StartRound()
    {
        ball.ResetBall();
        ball.AddStartingForce();
    }
    
    // Coroutine
    private IEnumerator SetInverseMode()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minTime, maxTime) - 2f); // Wait certain amount of time
            switchText.SetActive(true);
            yield return new WaitForSeconds(2f); // Last 2 seconds before switch, show text

            // Switch paddles back and forth
            isInverseMode = !isInverseMode; 
            ApplyPaddles();
            
            switchText.SetActive(false);
        }
    }
    
    // Does the actual switching of paddles, based on bool value of isInverseMode
    private void ApplyPaddles()
    {
        player.paddle = isInverseMode ? rightPaddle : leftPaddle;
        cpu.paddle = isInverseMode ? leftPaddle : rightPaddle;
    }

    public void CourtTriggered(int courtId)
    {
        score.IncreaseScore((courtId == 0 ? 1 : 0)); //If left court was triggered, right player scores & vice versa
        StartRound();
    }
}