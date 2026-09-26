using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public Score score;
    public Ball ball;
    public GameStates gameState;

    // Time interval for switching sides, can be edited in Unity
    public float minTime = 6f;
    public float maxTime = 16f;
    
    // Text
    public GameObject switchText; 
    public GameObject gameOverText;
    public Timer timer;
    public TMP_Text gameOverTimeText;
    
    private bool isGameOver = false;
    private bool isInverseMode = false;
    
    // Paddles, set all of these in Unity
    public PlayerController player;
    public CPUController cpu;
    public Paddle leftPaddle;
    public Paddle rightPaddle;
    
    private void Start()
    {
        StartCoroutine(SetInverseMode()); // Starts timer to switch sides
        ApplyPaddles();
        
        // Hide text at start
        switchText.SetActive(false);
        gameOverText.SetActive(false);
        
        StartRound();
    }

    private void StartRound()
    {
        ball.ResetBall();
        ball.AddStartingForce();
    }

    private void Update()
    {
        // Reset game once space is pressed after game over
        if (isGameOver && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    
    // Coroutine
    private IEnumerator SetInverseMode()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minTime, maxTime) - 2f); // Wait certain amount of time
            if (isGameOver)
                yield break;
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
        if (isGameOver)
            return;

        Paddle missedPaddle = (courtId == 0) ? leftPaddle : rightPaddle;
        if (missedPaddle == player.paddle)
        {
            // Stop game, show game over panel
            isGameOver = true;
            timer.isRunning = false;
            ball.gameObject.SetActive(false);
            gameOverText.gameObject.SetActive(true);
            gameOverTimeText.text = "Time: " + timer.time.ToString("F1") + "s";
        }
        else
        {
            StartRound(); // Normal ball reset if CPU misses
        }
    }
}