using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float movementSpeed = 5.0f; // Speed of camera movement

    void Update()
    {
        // Get input from arrow keys
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement direction
        Vector3 movementDirection = new Vector3(horizontalInput, verticalInput, 0);

        // Normalize the direction to maintain consistent speed regardless of input magnitude
        movementDirection.Normalize();

        // Move the camera based on the input direction
        transform.position += movementDirection * movementSpeed * Time.deltaTime;
    }
}
