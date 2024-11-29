using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WinCondition : MonoBehaviour
{
    SceneRandomizer SceneRandomizer;
    public AudioSource audioSource; // Reference to the AudioSource
    private float timesaver;
    private UniversalTimerScript timerScript;
    private void Start()
    {
        SceneRandomizer = GameObject.Find("DontDestroyOnLoad").GetComponent<SceneRandomizer>();
        timerScript = GameObject.Find("Timer").GetComponent<UniversalTimerScript>();
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
        SceneRandomizer.gameSpeedFloat = 0; // Pause the game
        Invoke("Win", 1f);
    }
    void Win()
    {
        
        SceneRandomizer.Win = true;
    }
}
