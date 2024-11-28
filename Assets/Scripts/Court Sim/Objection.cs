using UnityEngine;

public class Objection : MonoBehaviour
{
    public AudioSource blahblah; // Reference to the AudioSource
    private bool canPressSpace = false; // Whether the player can press space
    private float stopTime = 0f; // Random time when the sound will stop

    void Start()
    {
        PlaySound();
    }

    void Update()
    {
        // Stop the sound at the random time
        if (blahblah.isPlaying && Time.time >= stopTime)
        {
            blahblah.Stop();
            canPressSpace = true; // Enable space press
            Debug.Log("Sound stopped! Press Space!");
        }

        // Check for spacebar press
        if (canPressSpace && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space pressed in time! You win!");
            canPressSpace = false; // Reset the state
        }

        //if spacebar pressed at right time play win method

        //if spacebar pressed to early gameover method 
    }

    void PlaySound()
    {
        blahblah.Play();
        float randomDuration = Random.Range(1f, 5f); // Generate a random time between 2 and 5 seconds
        stopTime = Time.time + randomDuration; // Calculate when to stop the sound
        canPressSpace = false; // Reset the state
        Debug.Log("Sound playing... it will stop randomly!");
    }
}
