using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputDetector3 : MonoBehaviour
{

    public bool IsVictoryAchieved;
    public int SpaceDetect = 0;
    SceneRandomizer SceneRandomizer;
    public UniversalTimerScript timer;
    public GameObject VictoryText;


    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        SceneRandomizer = GameObject.Find("DontDestroyOnLoad").GetComponent<SceneRandomizer>();
        timer = GameObject.Find("Timer").GetComponent<UniversalTimerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && SpaceDetect <= 24)
        {
            SpaceDetect = SpaceDetect + 1;
        }

        switch (SpaceDetect)
        {
            case 2:
                GetComponent<SpriteRenderer>().enabled = true;
                break;
            case 3:
                GetComponent<SpriteRenderer>().enabled = false;
                break;
            case 6:
                GetComponent<SpriteRenderer>().enabled = true;
                break;
            case 7:
                GetComponent<SpriteRenderer>().enabled = false;
                break;
            case 11:
                GetComponent<SpriteRenderer>().enabled = true;
                break;
            case 12:
                GetComponent<SpriteRenderer>().enabled = false;
                break;
            case 16:
                GetComponent<SpriteRenderer>().enabled = true;
                break;
            case 17:
                GetComponent<SpriteRenderer>().enabled = false;
                break;
            case 21:
                GetComponent<SpriteRenderer>().enabled = true;
                break;
            case 22:
                GetComponent<SpriteRenderer>().enabled = false;
                break;
        }
        if (SpaceDetect >= 25 && IsVictoryAchieved == false)
        { 
            Debug.Log("Victory!!!");
            GetComponent<SpriteRenderer>().enabled = true;
            VictoryText.SetActive(true);
            timer.timerStopper = true;
            Invoke("Victory", 1f);
        }
    }
    void Victory()
    {
        SceneRandomizer.Win = true;
        
    }
}