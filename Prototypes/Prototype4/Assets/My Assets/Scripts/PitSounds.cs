using UnityEngine;

public class PitSounds : MonoBehaviour
{
    public GameObject growlSound;
    public float addPerSecond; 
    public float minSoundDistance = 3;
    public float maxSoundDistance = 6;
    
    public AudioSource growl2;
    public AudioSource growl3;

    void Start()
    {
        
    }

    void Update()
    {
        if (minSoundDistance == 20)
        {
            growl2.Play();
        }
        
        if (minSoundDistance == 30)
        {
            growl3.Play();
        }
            
        growlSound.GetComponent<AudioSource>().minDistance = minSoundDistance;
        growlSound.GetComponent<AudioSource>().maxDistance = maxSoundDistance;
        minSoundDistance += addPerSecond * Time.deltaTime;
        maxSoundDistance += addPerSecond * Time.deltaTime;
    }
}