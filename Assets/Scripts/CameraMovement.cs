using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float normalSpeed = 20.0f;
    public float sprintSpeed = 200.0f;
    private float currentSpeed;

    public float rSpeed = 10.0f;
    private float normalRotationSpeed = 10.0f;

    private float X = 0.0f;
    private float Y = 0.0f;

    private bool isSprinting = false;

    // Start is called before the first frame update
    void Start()
    {
        // start the game with the cursor locked
        Debug.Log("curssor locked");
        LockCursor(true);
        currentSpeed = normalSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        // if ESCAPE key is pressed, then unlock the cursor
        if (Input.GetButtonDown("Cancel"))
        {
            LockCursor(false);
        }

        // if the player fires, then relock the cursor
        if (Input.GetKeyDown(KeyCode.L))
        {
            LockCursor(true);
        }

        // Handle sprinting
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isSprinting = !isSprinting;
            currentSpeed = isSprinting ? sprintSpeed : normalSpeed;
        }

        X += Input.GetAxis("Mouse X") * rSpeed;
        Y += -Input.GetAxis("Mouse Y") * rSpeed;

        // Clamp the Y rotation angle to a certain range
        Y = Mathf.Clamp(Y, -90.0f, 90.0f);

        transform.localRotation = Quaternion.AngleAxis(X, Vector3.up);
        transform.localRotation *= Quaternion.AngleAxis(Y, Vector3.left);

        transform.position += transform.forward * currentSpeed * -Input.GetAxis("Vertical") * Time.deltaTime;
        transform.position += transform.right * currentSpeed * -Input.GetAxis("Horizontal") * Time.deltaTime;

        // Clamp the position to prevent going below a certain value on the Y-axis
        transform.position = new Vector3(transform.position.x, Mathf.Max(transform.position.y, 15.0f), transform.position.z);
    }

    private void LockCursor(bool isLocked)
    {
        if (isLocked)
        {
            // make the mouse pointer invisible
            Cursor.visible = false;

            // lock the mouse pointer within the game area
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            // make the mouse pointer visible
            Cursor.visible = true;

            // unlock the mouse pointer so player can click on other windows
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
