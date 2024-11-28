using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    public AudioSource audioSource; // Reference to the AudioSource

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the player triggered the collision
        if (collision.CompareTag("Player"))
        {
            // Play the sound cue
            audioSource.Play();

            // Call the win logic
            WinGame();
        }
    }

    private void WinGame()
    {
        Time.timeScale = 0; // Pause the game
    }
}
