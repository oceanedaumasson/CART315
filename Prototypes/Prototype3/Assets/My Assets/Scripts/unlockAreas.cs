using UnityEngine;

public class unlockAreas : MonoBehaviour
{
    private bool arch1Crossed = false;
    private bool arch2Crossed = false;
    public GameObject stairs;
    public GameObject pitBarrier;
    public GameObject stairGems;
    public Material gemMaterial;
    
    void Start()
    {
        stairs.SetActive(false);
        pitBarrier.SetActive(true);
    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Arch1")
        {
            Debug.Log("1 crossed");
            arch1Crossed = true;
        }

        if ((other.gameObject.tag == "Arch2") && (arch1Crossed == true))
        {
                Debug.Log("2 crossed");

                arch2Crossed = true;
        }

        if ((other.gameObject.tag == "Arch3") && (arch2Crossed == true))
        {
                Debug.Log("3 crossed");
                unlockStairs(); 
        }


        if (other.gameObject.tag == "Tower")
        {
            unlockPit();
        }
    }

    void unlockStairs()
    {
        stairs.SetActive(true);
    }
    
    void unlockPit()
    {
        pitBarrier.SetActive(false);
        foreach (Renderer r in stairGems.GetComponentsInChildren<Renderer>(true))
        {
            r.material = gemMaterial;
        }    }
}
