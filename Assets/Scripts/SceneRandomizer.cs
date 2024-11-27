using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneRandomizer : MonoBehaviour
{
    public bool Win = false; // Boolean to check if the player has won
    public string[] sceneNames; // Array to store scene names
    private bool isChangingScene = false; // Prevent multiple triggers
    public static SceneRandomizer Instance;
    public GameObject gameOverScreen;
    public bool gameIsOver = false;
    public float gameSpeedFloat = 1;
    public   TMP_Text pointsTxt;
    public TMP_Text gameSpeed;
    private int Points;
    private int PointsRequired = 1;
    private int PointsToSpeedChange;

    private void Awake()
    {
        //Checks if gameobject already exists
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        sceneNames = new string[] { "Alone at the Disco", "Catwalk simulation", "Fashion Gun", "PickUpThePhone" };
        Instance = this;
        DontDestroyOnLoad(this);
        PointsToSpeedChange = PointsRequired;
        
        
    }

    private void Update()
    {
        Time.timeScale = gameSpeedFloat;
        gameSpeed.text = "Speed: " + System.Math.Round(Time.timeScale, 1);
        // Check if the Win condition is true and we aren't already changing the scene
        if (Win && !isChangingScene && !gameIsOver)
        {
            PointGet();
            isChangingScene = true; // Prevent re-triggering
            PickRandomScene(); // Call the method to pick a random scene
            
        }

    }

    private void PickRandomScene()
    {
        Win = false;
        // Check if there are scenes in the array
        if (sceneNames.Length == 0)
        {
            Debug.LogWarning("No scenes available in the sceneNames array!");
            return;
        }

        // Pick a random scene name
        string randomScene = sceneNames[Random.Range(0, sceneNames.Length)];

        // Load the selected scene
        SceneManager.LoadScene(randomScene);

        // Reset isChangingScene after the scene is loaded
        isChangingScene = false;
        
    }
    public void PointGet()
    {
        Points = Points + 1;
        pointsTxt.text = "Points: " + Points;
        PointsToSpeedChange = PointsToSpeedChange - 1;
        if (PointsToSpeedChange <= 0)
        {
            SpeedChanger();
        }
    }
    public void gameOver()
    {
        if (gameIsOver == false)
        {
            gameIsOver = true;
            gameOverScreen.SetActive(true);
            Debug.Log("Game Over man!");

        }
        
    }
    public void restart()
    {
        gameOverScreen.SetActive(false);
        gameIsOver=false;
        PickRandomScene();
        Points = 0;
        pointsTxt.text = "Points: " + Points;
        gameSpeedFloat = 1;
    }
    private void SpeedChanger()
    {
        Debug.Log("Speed faster!");
        gameSpeedFloat = gameSpeedFloat + 0.2f;
        PointsToSpeedChange = PointsRequired;
        return;
    }
}