using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float time;
    public TMP_Text timeText;

    public bool isRunning = true;
    
    void Update()
    {
        if (!isRunning)
            return;
        
        time += Time.deltaTime;
        
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    
}
