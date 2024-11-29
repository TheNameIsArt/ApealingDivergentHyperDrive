using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WinCondition : MonoBehaviour
{
    SceneRandomizer SceneRandomizer;
    public AudioSource audioSource; // Reference to the AudioSource
    private float timesaver;
    private UniversalTimerScript timerScript;
    
    PlayerController playerController;
    private void Start()
    {
        SceneRandomizer = GameObject.Find("DontDestroyOnLoad").GetComponent<SceneRandomizer>();
        timerScript = GameObject.Find("Timer").GetComponent<UniversalTimerScript>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();

    }
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
        timerScript.timerStopper = true;
        
        Invoke("Win", 1f);
    }
    void Win()
    {
        playerController.speed = 0f;
        SceneRandomizer.Win = true;
    }
}
