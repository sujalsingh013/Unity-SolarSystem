using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Planet : MonoBehaviour
{
    public string planetName;
    public TextMeshProUGUI planetNameUI;
    public string planetSceneName; // The name of the scene to load for this planet

    private bool isPlayerNear = false;

    private void Start()
    {
        HidePlanetName();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isPlayerNear)
        {
            isPlayerNear = true;
            ShowPlanetName();
            LoadPlanetScene();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
            HidePlanetName();
        }
    }

    private void ShowPlanetName()
    {
        if (planetNameUI != null)
        {
            planetNameUI.text = planetName;
            planetNameUI.gameObject.SetActive(true);
        }
    }

    private void HidePlanetName()
    {
        if (planetNameUI != null)
        {
            planetNameUI.gameObject.SetActive(false);
        }
    }

    private void LoadPlanetScene()
    {
        if (!string.IsNullOrEmpty(planetSceneName))
        {
            SceneManager.LoadScene(planetSceneName);
        }
        else
        {
            Debug.LogError("Planet scene name is not set for " + planetName);
        }
    }
}
