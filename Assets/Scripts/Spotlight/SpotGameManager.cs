using UnityEngine;
using UnityEngine.SceneManagement;

public class SpotGameManager : MonoBehaviour
{
    public SpotlightTrigger spotlightTrigger; // Reference to the SpotlightTrigger script
    public float winTime = 5f; // Time required to win
    private float timeInSpotlight = 0f; // Timer for staying in the spotlight
    private bool gameEnded = false; // To check if the game is over
    SceneRandomizer SceneRandomizer;

    private void Start()
    {
        SceneRandomizer = GameObject.Find("DontDestroyOnLoad").GetComponent<SceneRandomizer>();
    }
    void Update()
    {
        if (gameEnded) return;

        if (spotlightTrigger.isPlayerInSpotlight)
        {
            // Increment the timer when the player is in the spotlight
            timeInSpotlight += Time.deltaTime;

            if (timeInSpotlight >= winTime)
            {
                WinGame();
            }
        }
        else
        {
            // Player stepped out of the spotlight - lose condition
            LoseGame();
        }
    }

    void WinGame()
    {
        gameEnded = true;
        Debug.Log("You Win!");
        SceneRandomizer.Win = true;
    }

    void LoseGame()
    {
        gameEnded = true;
        Debug.Log("You Lose!");
        SceneRandomizer.gameOver();
    }

    
}