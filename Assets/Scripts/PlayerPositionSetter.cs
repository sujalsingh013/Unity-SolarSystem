using UnityEngine;

public class PlayerPositionSetter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Check if a planet was selected
        if (PlayerPrefs.HasKey("SelectedPlanet"))
        {
            string selectedPlanet = PlayerPrefs.GetString("SelectedPlanet");

            // Find the GameObject with the selected planet's name in the scene
            GameObject planet = GameObject.Find(selectedPlanet);

            // Move the player 500 units before the selected planet along the x-axis
            if (planet != null)
            {
                // Adjust the position by subtracting 500 units from the x-axis
                Vector3 newPosition = new Vector3(planet.transform.position.x - 500f, planet.transform.position.y, planet.transform.position.z);

                // Set the player's position
                transform.position = newPosition;
            }

            // Remove the selected planet from PlayerPrefs
            PlayerPrefs.DeleteKey("SelectedPlanet");
        }
    }
}
