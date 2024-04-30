using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float windStrength = 1.0f;  // Adjust the strength of the wind
    public Vector3 windDirection = Vector3.right;  // Adjust the direction of the wind

    void Update()
    {
        // Calculate the rotation based on the wind direction and strength
        Quaternion windRotation = Quaternion.Euler(
            0f,
            Mathf.Sin(Time.time) * windStrength,  // You can modify this part to change the waving pattern
            0f
        );

        // Apply the rotation to the flag
        transform.rotation = Quaternion.identity;  // Reset rotation to avoid accumulation
        transform.Rotate(windRotation.eulerAngles);
    }
}
