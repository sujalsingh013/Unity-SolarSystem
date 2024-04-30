using UnityEngine;
using UnityEngine.SceneManagement;

public class Planetsceneloader : MonoBehaviour
{
    // Name of the scene to load
    public string sceneToLoad;

    // Method to be called when the button is clicked
    public void LoadSceneOnClick()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
