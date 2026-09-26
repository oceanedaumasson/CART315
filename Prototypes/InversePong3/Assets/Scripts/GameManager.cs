using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

[DefaultExecutionOrder(-1)]
public class GameManager : MonoBehaviour
{
    [SerializeField] private Ball ball;
    [SerializeField] private Paddle playerPaddle;
    [SerializeField] private Paddle computerPaddle;

    // For time and game over screen
    private bool isGameOver = false;
    [SerializeField] private Timer timer;
    [SerializeField] private GameObject gameOverText;
    [SerializeField] private TMP_Text gameOverTimeText;
    
    // For side switching
    private bool isInverseMode = false;
    public GameObject switchText;
    [SerializeField] private GameObject leftPaddleObject;
    [SerializeField] private GameObject rightPaddleObject;
    
    // Increase switching over time
    [SerializeField] private float startMinTime = 13f;
    [SerializeField] private float startMaxTime = 20f;
    [SerializeField] private float endMinTime = 3f;
    [SerializeField] private float endMaxTime = 5f;
    [SerializeField] private float switchTimePerSecond = 0.1f;
    
    private void Start()
    {
        gameOverText.SetActive(false);
        ApplyPaddles();
        StartCoroutine(SetInverseMode()); // Starts timer to switch sides
        NewRound();
    }

    private void Update()
    {
        if (isGameOver && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    
    public void NewRound()
    {
        playerPaddle.ResetPosition();
        computerPaddle.ResetPosition();
        ball.ResetPosition();

        CancelInvoke();
        Invoke(nameof(StartRound), 1f);
    }

    private void StartRound()
    {
        ball.AddStartingForce();
    }
    
    // Coroutine
    private IEnumerator SetInverseMode()
    {
        while (true)
        {
            float shrink = timer.time * switchTimePerSecond;
            float currentMin = Mathf.Max(startMinTime - shrink, endMinTime);
            float currentMax = Mathf.Max(startMaxTime - shrink, endMaxTime);
            
            yield return new WaitForSeconds(Random.Range(currentMin, currentMax) - 2f); // Wait certain amount of time
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

    // Switch between player and computer paddle scripts, depending on mode
    private void ApplyPaddles()
    {
        Paddle leftPlayer = leftPaddleObject.GetComponent<PlayerPaddle>();
        Paddle leftComputer = leftPaddleObject.GetComponent<ComputerPaddle>();
        Paddle rightPlayer = rightPaddleObject.GetComponent<PlayerPaddle>();
        Paddle rightComputer = rightPaddleObject.GetComponent<ComputerPaddle>();

        leftPlayer.enabled = !isInverseMode;
        leftComputer.enabled = isInverseMode;
        rightPlayer.enabled = isInverseMode;
        rightComputer.enabled = !isInverseMode;
    }
    
    public void OnLeftMissed()
    {
        // Game over if player misses with left paddle
        if (!isInverseMode)
        {
            HandlePlayerMiss();
        }
        else
        {
            // Just reset ball if cpu misses with left paddle
            NewRound();
        }
    }

    public void OnRightMissed()
    {
        // Game over if player misses with right paddle
        if (isInverseMode)
        {
            HandlePlayerMiss();
        }
        else
        {
            // Just reset ball if cpu misses with right paddle
            NewRound();
        }
    }

    // End round and show game over screen
    private void HandlePlayerMiss()
    {
        isGameOver = true;
        timer.isRunning = false;
        ball.gameObject.SetActive(false);
        gameOverText.SetActive(true);
        gameOverTimeText.text = "Time: " + timer.time.ToString("F1") + "s";
    }

}
