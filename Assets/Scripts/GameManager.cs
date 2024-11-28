using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SnakeGameManager : MonoBehaviour
{
    public Sprite DHeadUp, DHeadDown, DHeadLeft, DHeadRight;
    public Snakebody snakeBody;
    public GameObject GameOverText;
    public static SnakeGameManager instance;
    SceneRandomizer SceneRandomizer;

    private void Awake()
    {
        instance = this;
        SceneRandomizer = GameObject.Find("DontDestroyOnLoad").GetComponent<SceneRandomizer>();
    }

    public void Died()
    {
        SpriteRenderer SR = snakeBody.GetComponent<SpriteRenderer>();
        
        if(snakeBody.x == 1)
        {
            SR.sprite = DHeadRight;
        }
        if(snakeBody.x == -1)
        {
            SR.sprite = DHeadLeft;
        }
        if (snakeBody.y == -1)
        {
            SR.sprite = DHeadDown;
        }
        if (snakeBody.y == 1)
        {
            SR.sprite = DHeadUp;
        }

        Time.timeScale = 0;
        SceneRandomizer.gameOver();
    }

    public void Win()
    {
      SceneRandomizer.Win = true;
    }

}
