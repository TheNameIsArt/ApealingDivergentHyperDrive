using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    public AudioSource audioSource; // Reference to the AudioSource
    public Rigidbody2D rb_1;
    private Animator animator;
    private SceneRandomizer SceneRandomizer;

    void Awake()
    {
        rb_1 = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        animator = GameObject.Find("Player").GetComponent<Animator>();
        SceneRandomizer = GameObject.Find("DontDestroyOnLoad").GetComponent<SceneRandomizer>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the player triggered the collision
        if (collision.CompareTag("Player"))
        {
            // Play the sound cue
            audioSource.Play();
            animator.speed = 0f; // Pause the animation
            rb_1.constraints = RigidbodyConstraints2D.FreezeAll;
            // Call the win logic
            Invoke("WinGame", 1f);
        }
    }

    private void WinGame()
    {
        
        if (SceneRandomizer.Win == false)
        {
            SceneRandomizer.Win = true;
        }
    }
}
