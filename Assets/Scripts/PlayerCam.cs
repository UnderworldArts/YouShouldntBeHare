using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float sensX;// Sensitivity for mouse movement on the X-axis
    public float sensY;// Sensitivity for mouse movement on the Y-axis

    public Transform orientation;// Reference to the player's orientation

    float xRotation;// Current rotation around the X-axis
    float yRotation;// Current rotation around the Y-axis

    private void Start()
    {
        // Lock the cursor to the center of the screen and make it invisible
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    private void Update()
    {
        //get mouse input
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;// Update the Y-axis rotation based on mouse movement
        xRotation -= mouseY;// Update the X-axis rotation based on mouse movement
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);// Clamp the X-axis rotation to prevent flipping

        //roatate cam and orientation
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);// Apply the rotation to the camera
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);// Apply the rotation to the player's orientation


    }
}
