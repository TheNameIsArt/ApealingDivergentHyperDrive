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
    public string[] enemyArgument = { "Appeal", "Indictment", "Counter", "Objection" };
    public int argumentSelector;
    public bool GameOver = false;
    public bool Victory = false;


    void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        argumentSelector = Random.Range(0, enemyArgument.Length);
        Debug.Log(enemyArgument[argumentSelector]);
        Debug.Log(enemyArgument);
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            ChangeSpriteA(menuA);
                switch (argumentSelector)
                {
                    case 0:
                        Debug.Log("Correct Answer!");
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
            COUNTER.Play();
            switch (argumentSelector)
                {
                    case 2:
                        Debug.Log("Correct Answer!");
                        Victory = true;
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
            OBJECTION.Play();
            switch (argumentSelector)
                {
                    case 3:
                        Debug.Log("Correct Answer!");
                        Victory = true;
                        break;
                    default:
                        Debug.Log("Wrong Answer!!!");
                    GameOver = true;
                    break;
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

}
