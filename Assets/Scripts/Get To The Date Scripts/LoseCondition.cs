using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCondition : MonoBehaviour
{
    SceneRandomizer SceneRandomizer;
    UniversalTimerScript timer;
    private void Start()
    {
        SceneRandomizer = GameObject.Find("DontDestroyOnLoad").GetComponent<SceneRandomizer>();
        timer = GameObject.Find("Timer").GetComponent<UniversalTimerScript>();
    }
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
        SceneRandomizer.gameSpeedFloat = 0;
        SceneRandomizer.gameOver(); // Pause the game
    }
}
