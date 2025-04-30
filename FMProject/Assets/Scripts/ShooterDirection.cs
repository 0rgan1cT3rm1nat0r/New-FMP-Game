using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterDirection : MonoBehaviour
{
    public float rotationSpeed = 10000f;

    private float lastHorizontalDirection = 1f; // Start by facing right

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Update last horizontal direction if moving
        if (Mathf.Abs(horizontal) > 0.1f)
        {
            lastHorizontalDirection = Mathf.Sign(horizontal); // +1 = right, -1 = left
        }

        Vector3 direction;

        // If there is input in any direction, use it
        if (Mathf.Abs(vertical) > 0.1f || Mathf.Abs(horizontal) > 0.1f)
        {
            direction = new Vector3(-vertical, horizontal, 0f);
        }
        else
        {
            // No input, default to last known horizontal direction
            direction = (lastHorizontalDirection > 0) ? Vector3.up : Vector3.down;
        }

        // Rotate if we have a valid direction
        if (direction.magnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
