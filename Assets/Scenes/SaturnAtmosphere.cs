using UnityEngine;

public class SaturnAtmosphere : MonoBehaviour
{
    public Material terrainMaterial; // Assign your terrain material in the Inspector
    public Color reddishColor = new Color(1f, 0.5f, 0.2f, 1f); // Adjust color values as needed

    void Start()
    {
        if (terrainMaterial != null)
        {
            // Set the main color of the terrain material to reddish
            terrainMaterial.color = reddishColor;
        }
        else
        {
            Debug.LogError("Terrain material not assigned. Please assign the terrain material in the Inspector.");
        }
    }
}
