using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class JRPGManager : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite menuA;
    public Sprite menuW;
    public Sprite menuD;
    public Sprite menuS;
    public AudioSource COUNTER;
    public AudioSource OBJECTION;
    public AudioSource INDICMENT;
    public AudioSource APPEAL;
    public AudioSource GameOverSound;
    public string[] enemyArgument = { "Appeal", "Indictment", "Counter", "Objection" };
    public int argumentSelector;
    public bool GameOver = false;
    public bool Victory = false;
    private bool gameIsActive = false;

    SceneRandomizer SceneRandomizer;
    UniversalTimerScript timer;


    void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        argumentSelector = Random.Range(0, enemyArgument.Length);
        Debug.Log(enemyArgument[argumentSelector]);
        Debug.Log(enemyArgument);
        SceneRandomizer = GameObject.Find("DontDestroyOnLoad").GetComponent<SceneRandomizer>();
        timer = GameObject.Find("Timer").GetComponent<UniversalTimerScript>();
        Invoke("GameStart", 1f);
    }

    void Update()
    {
        if(gameIsActive== true)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                ChangeSpriteA(menuA);

                switch (argumentSelector)
                {
                    case 0:
                        Debug.Log("Correct Answer!");
                        APPEAL.Play();
                        Victory = true;
                        break;
                    default:
                        Debug.Log("Wrong Answer!!!");
                        GameOver = true;
                        break;
                }

            }
            else
            if (Input.GetKeyDown(KeyCode.W))
            {
                ChangeSpriteW(menuW);

                switch (argumentSelector)
                {
                    case 1:
                        Debug.Log("Correct Answer!");
                        INDICMENT.Play();
                        Victory = true;
                        break;
                    default:
                        Debug.Log("Wrong Answer!!!");
                        GameOver = true;
                        break;

                }
            }
            else
                if (Input.GetKeyDown(KeyCode.D))
            {
                ChangeSpriteD(menuD);

                switch (argumentSelector)
                {
                    case 2:
                        Debug.Log("Correct Answer!");
                        Victory = true;
                        COUNTER.Play();
                        break;
                    default:
                        Debug.Log("Wrong Answer!!!");
                        GameOver = true;
                        break;
                }

            }
            else
                if (Input.GetKeyDown(KeyCode.S))
            {
                ChangeSpriteS(menuS);

                switch (argumentSelector)
                {
                    case 3:
                        Debug.Log("Correct Answer!");
                        OBJECTION.Play();
                        Victory = true;
                        break;
                    default:
                        Debug.Log("Wrong Answer!!!");
                        GameOver = true;
                        break;
                }

            }
            if (Victory == true)
            {
                Victory = false;
                Win();
            }

            if (GameOver == true)
            {
                GameOver = false;
                timer.timerStopper = true;
                GameOverSound.Play();
                Invoke("gameOver", 1f);
            }
        }
    }

    void ChangeSpriteA(Sprite menuA)
    {
        spriteRenderer.sprite = menuA;
    }
    void ChangeSpriteW(Sprite menuW)
    {
        spriteRenderer.sprite = menuW;
    }
    void ChangeSpriteD(Sprite menuD)
    {
        spriteRenderer.sprite = menuD;
    }
    void ChangeSpriteS(Sprite menuS)
    {
        spriteRenderer.sprite = menuS;
    }
    void gameOver()
    {
        SceneRandomizer.gameOver();
        

    }

    void Win()
    {
        Victory = false;
        timer.timerStopper = true;
        Invoke("Point", 2f);
    }

    void Point()
    {
        SceneRandomizer.Win = true;
    }

    void GameStart()
    {
        gameIsActive = true;
    }
}


