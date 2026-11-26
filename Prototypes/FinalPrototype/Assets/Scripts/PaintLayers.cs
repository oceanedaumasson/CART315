using UnityEngine;

public class PaintLayers : MonoBehaviour
{
    public GameObject layer1;
    public GameObject layer2;    
    public GameObject layer3;
    
    void Start()
    {
        layer1.SetActive(false);
        layer2.SetActive(false);    
        layer3.SetActive(false);
    }

    void Update()
    {
        if (ClueManager.layer == 1)
        {
            layer1.SetActive(true);
        } else if (ClueManager.layer == 2)
        {
            layer1.SetActive(false);
            layer2.SetActive(true);
        } else if (ClueManager.layer == 3)
        {
            layer2.SetActive(false);
            layer3.SetActive(true);
        }
        
    }
}
