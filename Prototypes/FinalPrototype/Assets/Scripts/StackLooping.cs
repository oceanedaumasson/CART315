using System.Collections.Generic;
using UnityEngine;

public class StackLooping : MonoBehaviour
{
    public List<GameObject> stack;
    private int currentIndex = 0;
    
    void Start()
    {
        foreach (GameObject card in stack)
        {
            card.SetActive(false);
        }        
        stack[currentIndex].SetActive(true);
    }

    void Update()
    {
    }
    
    public void OnMyButtonClick()
    {
        NextCard();
    }

    private void NextCard()
    {  
        stack[currentIndex].SetActive(false); // Set current card to inactive
        currentIndex = (currentIndex + 1 + stack.Count) % stack.Count; // Move current card index to next in stack (and loop back to start)
        
        stack[currentIndex].SetActive(true); // Set new current card to active
    }
}
