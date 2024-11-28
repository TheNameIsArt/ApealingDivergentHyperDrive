using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputDetection : MonoBehaviour
{

    public bool IsVictoryAchieved = false;
    public int SpaceDetect = 0;



    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && SpaceDetect <= 24)
        {
            SpaceDetect = SpaceDetect + 1;
            Debug.Log("Space has been pressed: " + SpaceDetect + " amount of times.");
        }

        switch (SpaceDetect)
        {
            case 1:
                GetComponent<SpriteRenderer>().enabled = false;
                break;
            case 3:
                GetComponent<SpriteRenderer>().enabled = true;
                break;
            case 5:
                GetComponent<SpriteRenderer>().enabled = false;
                break;
            case 7:
                GetComponent<SpriteRenderer>().enabled = true;
                break;
            case 10:
                GetComponent<SpriteRenderer>().enabled = false;
                break;
            case 12:
                GetComponent<SpriteRenderer>().enabled = true;
                break;
            case 15:
                GetComponent<SpriteRenderer>().enabled = false;
                break;
            case 17:
                GetComponent<SpriteRenderer>().enabled = true;
                break;
            case 20:
                GetComponent<SpriteRenderer>().enabled = false;
                break;
            case 22:
                GetComponent<SpriteRenderer>().enabled = true;
                break;
        }
        
        if (SpaceDetect >= 25 && IsVictoryAchieved == false)
        {
            GetComponent<SpriteRenderer>().enabled = false;
            IsVictoryAchieved = true;
        }

    }
}
