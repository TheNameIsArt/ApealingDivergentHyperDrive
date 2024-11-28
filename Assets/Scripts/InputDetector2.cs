using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputDetector2 : MonoBehaviour
{

    public bool IsVictoryAchieved = false;
    public int SpaceDetect = 0;



    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().enabled = false;
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
            case 1:
            GetComponent<SpriteRenderer>().enabled = true;
                break;
            case 2:
            GetComponent<SpriteRenderer>().enabled = false;
                break;
            case 5:
            GetComponent<SpriteRenderer>().enabled = true;
                break;
            case 6:
            GetComponent<SpriteRenderer>().enabled = false;
                break;
            case 10:
            GetComponent<SpriteRenderer>().enabled = true;
                break;
            case 11:
            GetComponent<SpriteRenderer>().enabled = false;
                break;
            case 15:
            GetComponent<SpriteRenderer>().enabled = true;
                break;
            case 16:
            GetComponent<SpriteRenderer>().enabled = false;
                break;
            case 20:
            GetComponent<SpriteRenderer>().enabled = true;
                break;
            case 21:
            GetComponent<SpriteRenderer>().enabled = false;
                break;
            case 24:
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
