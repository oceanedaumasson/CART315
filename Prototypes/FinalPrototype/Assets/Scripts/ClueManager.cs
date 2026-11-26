using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

// Clue object
[System.Serializable]
public class Clue
{
    public string id;
    public string thought;
    public int answersNeeded = 1;
        
    public bool resolved;
    public int answersFound;
}

public class ClueManager : MonoBehaviour
{
    public static ClueManager Instance;
    public static int layer = 0; // Refers to the paint layers in the painting scene

    public List<Clue> clues; // List of clues to be found in stack
    public GameObject bubble;
    public TMP_Text bubbleText;

    private Clue clicked;
    
    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        bubble.SetActive(false);
    }

    // Method called by ClueClick when clue clicked is not an answer clue
    public void PickUp(string id)
    {
        Clue clue = null;
        foreach (Clue c in clues) // Go through list, check if clicked clue id matches one in list
        {
            if (c.id == id)
            {
                clue = c;
                break;
            }
        }
            
        if (clue == null || clue.resolved)
            return;

        // If match, show thought bubble and set clicked to true
        clicked = clue;
        bubbleText.text = clue.thought;
        bubble.SetActive(true);
    }

    // Method called by ClueClick when clue clicked is an answer clue
    public bool TryResolve(string id)
    {
        if (clicked == null || clicked.id != id)
            return false;

        clicked.answersFound++;
        
        if (clicked.answersFound >= clicked.answersNeeded)
        {
            clicked.resolved = true;
            Debug.Log("Resolved: " + clicked.id);
            clicked = null;
            bubble.SetActive(false); // Hide thought bubble again

            // Once all clues are found and matched
            if (clues.TrueForAll(c => c.resolved))
            {
                Debug.Log("All clues resolved");
                layer++;
                SceneManager.LoadScene("Scenes/Painting");
                ;
            }
        }

        return true;
    }

}
