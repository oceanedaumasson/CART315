using UnityEngine;

public class unlockAreas : MonoBehaviour
{
    private bool arch1Crossed = false;
    private bool arch2Crossed = false;
    public GameObject stairs;
    public GameObject pitBarrier;
    public GameObject stairGems;
    public Material gemMaterial;
    
    public GameObject arch1Gem;
    public GameObject arch2Gem;
    public GameObject arch3Gem;

    public GameObject towerGem;
    
    public GameObject arch2Path;
    public GameObject arch3Path;
    public GameObject pitGems;
    
    void Start()
    {
        stairs.SetActive(false);
        pitBarrier.SetActive(true);
        
        arch1Gem.SetActive(false);
        arch2Gem.SetActive(false);
        arch3Gem.SetActive(false);
        towerGem.SetActive(false);
        
        arch2Path.SetActive(false);
        arch3Path.SetActive(false);
        pitGems.SetActive(false);

    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Arch1")
        {
            Debug.Log("1 crossed");
            arch1Crossed = true;
            arch1Gem.SetActive(true);
            arch2Path.SetActive(true);
        }

        if ((other.gameObject.tag == "Arch2") && (arch1Crossed == true))
        {
                Debug.Log("2 crossed");
                arch2Crossed = true;
                arch2Gem.SetActive(true);
                arch3Path.SetActive(true);
        }

        if ((other.gameObject.tag == "Arch3") && (arch2Crossed == true))
        {
                Debug.Log("3 crossed");
                unlockStairs(); 
                arch3Gem.SetActive(true);
        }


        if (other.gameObject.tag == "Tower")
        {
            towerGem.SetActive(true);
            pitGems.SetActive(true);
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
