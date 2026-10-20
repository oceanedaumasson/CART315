using System;
using TMPro;
using UnityEngine;

public class Stopwatch : MonoBehaviour
{
    private bool stopwatchActive = true;
    public float currentTime = 0f;
    public TMP_Text stopwatchText;
    
    void Start()
    {
        Time.timeScale = 1f;
    }
    
    void Update()
    {
        if (stopwatchActive)
        {
            currentTime += Time.deltaTime;
        }
    }

    public void StartStopwatch()
    {
        stopwatchActive = true;
    }
    
    public void StopStopwatch()
    {
        stopwatchActive = false;
        stopwatchText.text = "You caught up to her in " + DisplayStopwatchTime();

    }

    public string DisplayStopwatchTime()
    {
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        return string.Format("{0}.{1:00}s", time.Seconds, time.Milliseconds);
    }
}
