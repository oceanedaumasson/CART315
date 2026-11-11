using UnityEngine;

public class TunnelSound : MonoBehaviour {
    private AudioSource[] audioSources;
    public float fadeTime = 2f;
    
    void Start() 
    {
        audioSources = GetComponents<AudioSource>();
    }
    
    void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Player")) 
        {
            foreach (AudioSource s in audioSources)
            {
                s.Play();
            }
        }
    }
    
    void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit: " + other.name);
        if (other.CompareTag("Player"))
        {
            foreach (AudioSource s in audioSources)
                s.Stop();
        }
    }
}
