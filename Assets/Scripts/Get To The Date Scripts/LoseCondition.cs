using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCondition : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the player collided with the box
        if (collision.CompareTag("Player"))
        {
            Debug.Log("You Lose!"); // Log a lose message for now

            // Call the lose logic
            LoseGame();
        }
    }

    private void LoseGame()
    {
        // Display a lose message or reset the game
        Debug.Log("Game Over! You hit the box!");

        // Example: Stop the game or reload the level
        Time.timeScale = 0; // Pause the game
    }
}
