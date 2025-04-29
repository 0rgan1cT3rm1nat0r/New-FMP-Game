
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterDirection : MonoBehaviour
{
    // Speed at which the aim rotates, tweak this value for faster/slower rotation
    public float rotationSpeed = 10000f;

    void Update()
    {
        // Get horizontal (A/D or Left/Right arrow) and vertical (W/S or Up/Down arrow) input
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Create a vector to represent the direction of the aim based on input
        Vector3 direction = new Vector3( -vertical, horizontal, 0f);

        // Only rotate if there is input
        if (direction.magnitude > 0.1f)
        {
            // Calculate the target rotation based on the input direction
            Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, direction);

            // Smoothly rotate towards the target rotation
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}



/*
 using UnityEngine;

public class RotateAimWithKeyPress : MonoBehaviour
{
    // Speed at which the aim rotates
    public float rotationSpeed = 10f;

    void Update()
    {
        // Create a vector to store movement input
        Vector3 direction = Vector3.zero;

        // Check if specific keys are being held down
        if (Input.GetKey(KeyCode.W)) // Up
        {
            direction += Vector3.up;
        }
        if (Input.GetKey(KeyCode.S)) // Down
        {
            direction += Vector3.down;
        }
        if (Input.GetKey(KeyCode.A)) // Left
        {
            direction += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D)) // Right
        {
            direction += Vector3.right;
        }

        // Only rotate if there is input
        if (direction.magnitude > 0.1f)
        {
            // Calculate the target rotation based on the input direction
            Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, direction);

            // Smoothly rotate towards the target rotation
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
*/