using UnityEngine;
using UnityEngine.EventSystems;

public class HintClick : MonoBehaviour, IPointerClickHandler
{
    public static bool found = false;
    public GameObject hintBubble;
    
    void Start()
    {
        hintBubble.SetActive(false);
    }

    void Update()
    {
        if (found)
        {
            hintBubble.SetActive(true);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Hint found"); 
        found = true;
    }

    public static bool GetFound()
    {
        return found;
    }
}
