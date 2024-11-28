using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f; // Speed of running to the right
    public float jumpForce = 10f; // Force of the jump
    private bool isGrounded; // Check if the player is on the ground
    public Transform groundCheck; // The point used to check if the player is grounded
    public LayerMask groundLayer; // The ground layer to check against

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component attached to the player

    }

    void Update()
    {
        // Automatically move the player to the right
        rb.velocity = new Vector2(speed, rb.velocity.y);

        // Check if the player is grounded using the groundCheck position
        Collider2D groundCollider = Physics2D.OverlapCircle(groundCheck.position, 1f, groundLayer);
        isGrounded = groundCollider != null;

        // Debug: Check if the ground check position is detecting anything
        /*if (groundCollider != null)
        {
            Debug.Log("Ground detected at: " + groundCollider.gameObject.name);
        }
        else
        {
            Debug.Log("No ground detected");
        }*/

        // Check if spacebar is pressed and the player is grounded
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Jumping!"); // Debug if spacebar input is detected
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(groundCheck.position, 0.1f); // Show the groundCheck position in the scene
    }
}


