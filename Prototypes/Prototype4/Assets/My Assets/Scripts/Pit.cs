using UnityEngine;

public class Pit : MonoBehaviour
{

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Orb")
        {
            Debug.Log("Orb destroyed");
            Destroy(other.gameObject);
        }
    }
}
