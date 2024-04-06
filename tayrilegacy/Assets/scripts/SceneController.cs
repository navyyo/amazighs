using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // Method to load a new scene by its name
    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(1);
    }
}

