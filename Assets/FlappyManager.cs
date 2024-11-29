using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FlappyManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI highScoreText;

    public Player player;

 

    public GameObject Tutorial;

    private int score;

    SceneRandomizer SceneRandomizer;
    FallingGameTimerScript timer;

    private void Awake()
    {
        SceneRandomizer = GameObject.Find("DontDestroyOnLoad").GetComponent<SceneRandomizer>();
        timer = GameObject.Find("TimerUp").GetComponent<FallingGameTimerScript>();
        SceneRandomizer.SpeedStopper();
        
        
    }
    public void Start()
    {
        timer.timerStopper = true;
    }
    private void Update()
    {
        if (timer.timerStopper)
        {
            SceneRandomizer.SpeedStopper();
        }

        if (timer.timerStopper && Input.GetKeyDown(KeyCode.Space))
        {
            Play();
        }
    }

    public void Play()
    {



        Tutorial.SetActive(false);
        timer.timerStopper = false;

        //player.enabled = true;

        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
    }

    public void GameOver()
    {
        SceneRandomizer.gameSpeedFloat = 0f;
        SceneRandomizer.gameOver();
    }




}