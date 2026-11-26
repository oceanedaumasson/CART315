using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour
{
    public void nextLayerScene()
    {
        if (ClueManager.layer == 1)
            SceneManager.LoadScene("Scenes/Layer2");
        else if (ClueManager.layer == 2)
            SceneManager.LoadScene("Scenes/Layer3");
    }
}
