using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AppleManager : MonoBehaviour
{

    public GameObject apple;
    private int score = -1;
    public TMP_Text text; 

    // Start is called before the first frame update
    void Start()
    {
        SpawnApple();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnApple()
    {
        score++;
        //HighscoreManager.instance.SaveHighscore(score);
        text.text = score.ToString();
        Instantiate(apple, GetRandomPosition(), Quaternion.identity);
    }

    public Vector2 GetRandomPosition()
    {
        float appleX = Random.Range(-7, 8);
        float appleY = Random.Range(-4, 4);

        RaycastHit2D[] items = Physics2D.BoxCastAll(new Vector2(appleX, appleY), new Vector2(0.5f, 0.5f), 0, new Vector2(0, 0));
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i].transform.tag == "Snake" || items[i].transform.tag == "Apple")
            {
                return GetRandomPosition();
                
            }
        }

        return new Vector2(appleX, appleY);
    }
}
