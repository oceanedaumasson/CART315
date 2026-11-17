using UnityEngine;

public class PitSounds : MonoBehaviour
{
    public GameObject throbSound;
    public GameObject groanSound;
    public float addPerSecond;
    public float startVolume;

    [SerializeField] private pitSoundTrigger PitSoundTrigger;
    
    void Start(){
        InvokeRepeating("PlayGroanSound",25f,45f);
    }

    void Update()
    {
        throbSound.GetComponent<AudioSource>().volume = startVolume;

        if (PitSoundTrigger.beastFed)
        {
            throbSound.GetComponent<AudioSource>().volume = 0;
        }
        
        startVolume += addPerSecond * Time.deltaTime;
    }
    
    void PlayGroanSound(){
        groanSound.GetComponent<AudioSource>().Play();
    }
}