using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCondition : MonoBehaviour
{
    private Animator animator;
    public Rigidbody2D rb_1;
    private SceneRandomizer SceneRandomizer;
    void Awake()
    {
        rb_1 = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        animator = GameObject.Find("Player").GetComponent<Animator>();
        SceneRandomizer = GameObject.Find("DontDestroyOnLoad").GetComponent<SceneRandomizer>();

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
        rb_1.constraints = RigidbodyConstraints2D.FreezeAll;
        animator.speed = 0f; // Pause the animation
        SceneRandomizer.gameOver();
    }
  
}
