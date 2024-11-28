using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Snakehead : MonoBehaviour
{
    public ParticleSystem eatParticles;
    private AudioSource eatAppleAudio;
    public GameObject snakeBodyGO;
    public Snakebody lastBody;
    public Snakebody snakeBody;
    private float timer;
    public float moveTime;
    
    public AppleManager appleManager;
    private SnakeSprite snakeSprite;

    private void Start()
    {
        eatAppleAudio = this.GetComponent<AudioSource>();
        snakeSprite = this.GetComponent<SnakeSprite>(); 
        timer = moveTime;

      
    }

    // Update is called once per frame
    void Update()
    {
        
        

        if (Input.GetKeyDown(KeyCode.D) && snakeBody.x != -1) 
        {
            snakeBody.x = 1;
            snakeBody.y = 0;
        }
       
        if (Input.GetKeyDown(KeyCode.A) && snakeBody.x != 1)
        {
            snakeBody.x = -1;
            snakeBody.y = 0;
        }
        
        if (Input.GetKeyDown(KeyCode.W) && snakeBody.y != -1)
        {
            snakeBody.x = 0;
            snakeBody.y = 1;
        }
        
        if (Input.GetKeyDown(KeyCode.S) && snakeBody.y != 1)
        {
            snakeBody.x = 0;
            snakeBody.y = -1;
        }


        timer -= Time.deltaTime;
        if (timer < 0)
        {
            
            timer += moveTime; 
            snakeBody.Move();
            snakeSprite.SetSprite(snakeBody.x, snakeBody.y);
            EatApple();
            EatSnake();

        
        }
    }

    public void EatApple()
    {
        
        RaycastHit2D[] items = Physics2D.BoxCastAll(snakeBody._transform.position, new Vector2(0.5f, 0.5f),0,new Vector2(0,0));
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i].transform.tag == "Apple")
            {
                
                //Remove apple
                Destroy(items[i].transform.gameObject);

                //Grow snake
                Grow();

                //Spawn new apple
                appleManager.SpawnApple();

                //Increase move speed
                moveTime *= 0.97f;

                //Play sound
                eatAppleAudio.Play();

                //Play Particles
                eatParticles.Play();

                PitchManager.instance.ChangePitch();
            }          
        }
    }

    public void EatSnake()
    {

        RaycastHit2D[] items = Physics2D.BoxCastAll(snakeBody._transform.position, new Vector2(0.5f, 0.5f), 0, new Vector2(0, 0));
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i].transform.tag == "Snake" && items[i].transform.gameObject != this.gameObject)
            {
                //Dead
                SnakeGameManager.instance.Died();
            }
        }
    }

    public void Grow()
    {
        GameObject newLastBody = Instantiate(snakeBodyGO,lastBody.transform.position - new Vector3(lastBody.x, lastBody.y,0), Quaternion.identity);
        newLastBody.GetComponent<Snakebody>().x = lastBody.x; 
        newLastBody.GetComponent<Snakebody>().y = lastBody.y;
        lastBody.nextPart = newLastBody.GetComponent<Snakebody>();
        lastBody.GetComponent<SnakeSprite>().SetSprite(lastBody.x,lastBody.y);
        lastBody = newLastBody.GetComponent<Snakebody>();
        lastBody.GetComponent<SnakeSprite>().Start();
        lastBody.GetComponent<SnakeSprite>().SetSprite(lastBody.x,lastBody.y);
    }


}
