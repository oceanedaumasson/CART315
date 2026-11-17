using UnityEngine;

public class pitSoundTrigger : MonoBehaviour
{
    private AudioSource audioSource;
    public bool beastFed = false;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Orb")
        {
            Debug.Log("Orb triggered sound");
            audioSource.Play();
            beastFed = true;
        }
    }
}
