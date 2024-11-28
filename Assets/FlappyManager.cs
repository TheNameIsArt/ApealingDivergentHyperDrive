using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FlappyManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI highScoreText;

    public Player player;

    public Text scoreText;

    public GameObject playButton;

    public GameObject gameOver;

    private int score;

    SceneRandomizer SceneRandomizer;

    private void Awake()
    {
        SceneRandomizer = GameObject.Find("DontDestroyOnLoad").GetComponent<SceneRandomizer>();

        Play();
    }

    public void Play()
    {






        player.enabled = true;

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