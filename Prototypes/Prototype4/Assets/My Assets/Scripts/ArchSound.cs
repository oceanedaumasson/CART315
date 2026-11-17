using UnityEngine;

public class ArchSound : MonoBehaviour
{
    private AudioSource audioSource;
    public bool playOnPlayerEnter = false;

    void Awake() 
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound()
    {
        audioSource.Play();
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (playOnPlayerEnter && other.CompareTag("Player"))
        {
            audioSource.Play();
        }
    }
    
}
