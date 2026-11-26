using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.EventSystems;

public class HintResolved : MonoBehaviour, IPointerClickHandler
{
    public GameObject hintBubble;
    public static bool resolved =  false;
    
    void Start()
    {
    }

    void Update()
    {
        if (resolved)
        {
            Debug.Log("Hint resolved");
            hintBubble.SetActive(false);
            resolved = false;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (HintClick.GetFound()) {
            Debug.Log("Hint clicked");
            resolved = true;
        }
    }


}
