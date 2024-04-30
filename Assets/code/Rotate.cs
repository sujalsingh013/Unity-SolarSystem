using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float rotationSpeed = 10f; // Adjust the speed as needed

    void Start()
    {
        Debug.Log("Rotation script started");
    }

    void Update()
    {
        // Rotate the planet around its up axis (Vector3.up)
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
