using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
public class LogicScript : MonoBehaviour {



    public TMP_Text MyText;
    public int score;
    public bool gameIsOver = false;
    public PlayerMovement movement;
    public GameObject gameOverScreen;
    public GameObject spawner;
    public SpawnerScript spawnerScript;
    public float gameSpeed = 1.0f;
    public GameObject player;
    public PlayerInput playerInput;

    // Use this for initialization
    void Start () {
   
        MyText.text = "Score:";
        movement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        spawner = GameObject.Find("Spawner");
        spawnerScript = spawner.GetComponent<SpawnerScript>();
        player = GameObject.Find("Hooman");
        playerInput = player.GetComponent<PlayerInput>();
    }


    // Update is called once per frame
    void Update () {
   
        MyText.text = "Score: " + score;
        //Debug.Log("update work");
        
        Time.timeScale = gameSpeed;
    }


    public void pointGet(int scoreToAdd)
    {
        score = score + scoreToAdd;
        MyText.text = score.ToString();
       
    }
    public void gameOver()
    {
        gameOverScreen.SetActive(true);
        gameIsOver = true;
        playerInput.enabled = false;
    }
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        movement.enabled = false;
    }
    public void winner() 
    {
        if (gameIsOver == false)
        {
            Debug.Log("You Win!");

        }
    }
}