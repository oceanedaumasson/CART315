using UnityEngine; 
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class endGame : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
             {
                 SceneManager.LoadScene("IntroMenu");
             }
        
    }
}
