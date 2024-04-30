using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    // Start is called before the first frame update


    // Update is called once per frame
     // Saturn's rotation speed in degrees per second

    void Update()
    {
        // Rotate the object around the Y-axis at the same speed as Saturn
        transform.Rotate(0,.4f, 0);
    }
}
