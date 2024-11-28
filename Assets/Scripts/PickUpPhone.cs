using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PickUpPhone : MonoBehaviour
{
    public TMP_Text resultText;       // Assign in the inspector
    public Button cueButton;          // Visual cue
    public AudioSource phoneRing;     // Audio for button appearance
    public AudioSource spacebarAudio; // Audio for spacebar press

    private float targetTime;         // Randomized time to hit
    private bool gameActive = false;  // Controls game state
    private float timer;              // Tracks elapsed time
    private bool phoneSoundPlayed = false; 
    private float buttonAppearTime;   // Tracks the exact time the button appears
    private bool buttonVisible = false; // Tracks if the button is visible

    void Start()
    {
        cueButton.gameObject.SetActive(false); // Hides the button at the start
        StartGame();
    }

    void Update()
    {
        if (gameActive)
        {
            timer += Time.deltaTime;

            // Show the button when the target time is reached
            if (timer >= targetTime && !buttonVisible)
            {
                ShowButton();
            }

            // Check lose condition if the button is visible
            if (buttonVisible && Time.time - buttonAppearTime >= 5f)
            {
                HandleLoseCondition();
            }

            // Handle spacebar press
            if (Input.GetKeyDown(KeyCode.Space) && buttonVisible)
            {
                HandleSpacebarPress();
            }
        }
    }

    void ShowButton()
    {
        cueButton.gameObject.SetActive(true);   // Show the button
        resultText.text = "PICK UP THE PHONE!";
        buttonAppearTime = Time.time;          // Record the time the button appears
        buttonVisible = true;

        if (!phoneSoundPlayed)
        {
            phoneRing.Play();                  // Play the sound effect
            phoneSoundPlayed = true;           // Ensure the sound only plays once
        }
    }

    void HandleSpacebarPress()
    {
        gameActive = false;
        cueButton.gameObject.SetActive(false); // Hide the button
        buttonVisible = false;                 // Reset button visibility

        if (phoneRing.isPlaying)
        {
            phoneRing.Stop();                  // Stop the ringing sound
        }

        spacebarAudio.Play();                  // Play the spacebar press sound
        resultText.text = "Good job!";
    }

    void HandleLoseCondition()
    {
        gameActive = false;
        cueButton.gameObject.SetActive(false); // Hide the button
        buttonVisible = false;                 // Reset button visibility
        resultText.text = "Too slow!";
        
        if (phoneRing.isPlaying)
        {
            phoneRing.Stop();                  // Stop the ringing sound
        }
    }

    void StartGame()
    {
        targetTime = Random.Range(1f, 5f); // Set random target time
        timer = 0f;
        gameActive = true;
        buttonVisible = false;             // Reset button visibility
        phoneSoundPlayed = false;          // Allow sound to play again
        cueButton.gameObject.SetActive(false); // Hide the button
        resultText.text = "Pick up the phone when it rings!";
    }
}
