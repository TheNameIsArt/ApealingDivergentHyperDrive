using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public Animator animator; // Reference to Animator
    private float speed = 2f;  // Forward movement speed
    public float turnSpeed = 100f; // Turning speed
    public float gameEndPositionY = -5f; // Y position to trigger game end (game ends when Y reaches -5)

    private float currentSpeed; // Current speed

    void Update()
    {
        float moveDirection = 0;

        // Check for input
        if (Input.GetKey(KeyCode.A))
        {
            moveDirection = -1; // Left turn
            animator.Play("left", 0); // Force play LeftTurn animation
            currentSpeed = speed; // Assign forward speed
            transform.Rotate(Vector3.forward, turnSpeed * Time.deltaTime);
            transform.Translate(Vector3.down * currentSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveDirection = 1; // Right turn
            animator.Play("right", 0); // Force play RightTurn animation
            currentSpeed = speed; // Assign forward speed
            transform.Rotate(Vector3.forward, -turnSpeed * Time.deltaTime);
            transform.Translate(Vector3.down * currentSpeed * Time.deltaTime);
        }
        else
        {
            // Stop forward movement when no key is pressed
            currentSpeed = 0;
        }

        // Update Animator parameters
        animator.SetFloat("MoveDirection", moveDirection);
        animator.SetBool("isStopping", moveDirection == 0);

        // Check if the character has reached the end of the game (Y position = -5)
        if (transform.position.y <= gameEndPositionY)
        {
            EndGame(); // End the game if the player reaches the target position
        }
    }

     // Method to stop the game
    void EndGame()
    {
        // Pause the game by setting time scale to 0
        Time.timeScale = 0; // Stop the game time
        Debug.Log("You Win!");
    }
}
