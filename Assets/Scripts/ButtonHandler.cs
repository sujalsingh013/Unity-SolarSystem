using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    // Public method to be called when a planet button is clicked
public string planetName;
    public void OnPlanetButtonClick()
    {
        // Load the solarsystem scene
        SceneManager.LoadScene("Solar System");

        // Save the selected planet name to PlayerPrefs
        PlayerPrefs.SetString("SelectedPlanet", planetName);
    }
}
