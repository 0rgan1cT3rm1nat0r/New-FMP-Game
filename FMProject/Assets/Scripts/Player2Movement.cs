using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player2Movement : MonoBehaviour
{
    public Animator animator;
    private float horizontal = 0;
    public float speed = 8f;
    public float jumpingPower = 16f;
    private bool isFacingRight = true;
    private bool idle = true;
    private bool isRunning = false;

    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    public bool isGrounded;

    void Update()
    {
        IsGrounded();

        // Get horizontal input
        horizontal = Input.GetAxisRaw("Horizontal2");

        // Check for jump input
        if (Input.GetKey(KeyCode.UpArrow) && IsGrounded())
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpingPower, rb.velocity.z); // Add jump force on the y-axis
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) && IsGrounded())
        {
            isRunning = true;
            // animator.SetBool("running", true);
        }

        else
        {
            isRunning = false;
            // animator.SetBool("running", false);
        }




        animator.SetFloat("horizontal", horizontal);
        animator.SetBool("idle", idle);
        animator.SetBool("grounded", isGrounded);
        animator.SetBool("running", isRunning);

        // Smooth out jumping (reducing upward force when the jump key is released)
        if (Input.GetKeyUp(KeyCode.UpArrow) && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y * 0.5f, rb.velocity.z);
        }

        // Handle character flip
        Flip();
    }

    private void FixedUpdate()
    {
        // Move the player in the X-axis and maintain current Y and Z velocity (for gravity)
        rb.velocity = new Vector3(horizontal * speed, rb.velocity.y, rb.velocity.z);
        if (horizontal == 0)
        {
            idle = true;
        }
        else if (horizontal == 1 && horizontal == -1)
        {
            idle = false;
        }
    }

    private bool IsGrounded()
    {
        // Check if player is grounded using a sphere check
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.2f, groundLayer);
        return isGrounded;
    }

    private void Flip()
    {
        // Flip the character model (rotation on Y-axis)
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            transform.Rotate(0f, 180f, 0f); // Rotate 180 degrees around the Y-axis
        }
    }
}
