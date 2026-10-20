using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timeValue = 90;
    public TMP_Text timeText;

    public bool keepTiming = true;
    
    void Update()
    {
        if (keepTiming)
        {
            timeValue -= Time.deltaTime;
            if (timeValue <= 0) 
            {
                timeValue = 0; 
                DisplayTime(timeValue);
                SceneManager.LoadScene("Scenes/Game Over");
            }
        }

        DisplayTime(timeValue);
    }

    public void StopTimer()
    {
        keepTiming = false;
    }
    
    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
