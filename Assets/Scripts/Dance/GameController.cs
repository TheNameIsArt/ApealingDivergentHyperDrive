using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameController : MonoBehaviour
{
    // References to the player and AI
    public Animator playerAnimator;
    public Animator aiAnimator;

    private List<string> aiSequence = new List<string>();   // Store AI's animation sequence
    private List<string> playerSequence = new List<string>(); // Store player's input sequence
    private bool playerTurn = false; // Flag to check if it's the player's turn to input
    private bool isSequenceComplete = false; // Flag to check if the sequence is complete

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PlayAISequence()); // Start the AI sequence at the beginning
    }

    // Play the AI sequence (random Left/Right animations)
    private IEnumerator PlayAISequence()
    {
        aiSequence.Clear();  // Clear any existing sequence
        isSequenceComplete = false; // Reset the sequence completion flag

        // AI will play 5 random animations
        for (int i = 0; i < 5; i++)
        {
            string animation = Random.value > 0.5f ? "Left" : "Right";
            aiSequence.Add(animation);

            aiAnimator.SetTrigger(animation);  // Trigger either Left or Right for AI

            Debug.Log("AI triggered: " + animation);
            yield return new WaitForSeconds(1f); // Wait for 1 second between animations
        }

        // After the AI sequence, allow the player to input
        playerTurn = true;
        Debug.Log("Player's turn, follow the sequence!");
    }

    // Update is called once per frame
    void Update()
    {
        // Allow the player to input if it's their turn and the sequence isn't complete
        if (playerTurn && !isSequenceComplete)
        {
            if (playerSequence.Count < aiSequence.Count)
            {
                HandlePlayerInput();
            }
            else
            {
                CheckPlayerInput(); // Once player sequence length matches AI sequence, check if it's correct
            }
        }
    }

    // Handle the player's input (A for Left, D for Right)
    private void HandlePlayerInput()
    {
        if (Keyboard.current.aKey.wasPressedThisFrame)
        {
            playerSequence.Add("Left");
            playerAnimator.SetTrigger("Left"); // Trigger Left animation for the player
            Debug.Log("Player triggered: Left");
        }

        if (Keyboard.current.dKey.wasPressedThisFrame)
        {
            playerSequence.Add("Right");
            playerAnimator.SetTrigger("Right"); // Trigger Right animation for the player
            Debug.Log("Player triggered: Right");
        }
    }

    // Check if the player's sequence matches the AI sequence
    private void CheckPlayerInput()
    {
        int currentIndex = playerSequence.Count - 1;
        string playerMove = playerSequence[currentIndex];
        string aiMove = aiSequence[currentIndex];

        if (playerMove != aiMove)
        {
            Debug.Log("Incorrect input, you lose!");
            StopGame(); // Stop the game
        }
        else
        {
            Debug.Log("Correct input!");

            // If the player completed the sequence correctly, you win
            if (playerSequence.Count == aiSequence.Count)
            {
                Debug.Log("You win!");
                StopGame(); // Stop the game
            }
        }
    }

    // Stop the game (disable further input and sequence)
    private void StopGame()
    {
        playerTurn = false; // Disable player input
        aiAnimator.enabled = false; // Optionally, disable AI animator
        playerAnimator.enabled = false; // Optionally, disable player animator
    }
}
