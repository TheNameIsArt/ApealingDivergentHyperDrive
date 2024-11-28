using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBase : MonoBehaviour
{

    public bool Win = false;
    public int AttackDetect = 0;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().enabled = true;

    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && AttackDetect <= 24)
        {
            AttackDetect = AttackDetect + 1;
        }

        switch (AttackDetect)
        {
            case 2:
                GetComponent<SpriteRenderer>().enabled = false;
                break;
            case 4:
                GetComponent<SpriteRenderer>().enabled = true;
                break;
            case 6:
                GetComponent<SpriteRenderer>().enabled = false;
                break;
            case 8:
                GetComponent<SpriteRenderer>().enabled = true;
                break;
            case 11:
                GetComponent<SpriteRenderer>().enabled = false;
                break;
            case 13:
                GetComponent<SpriteRenderer>().enabled = true;
                break;
            case 16:
                GetComponent<SpriteRenderer>().enabled = false;
                break;
            case 18:
                GetComponent<SpriteRenderer>().enabled = true;
                break;
            case 21:
                GetComponent<SpriteRenderer>().enabled = false;
                break;
            case 23 :
                GetComponent<SpriteRenderer>().enabled = true;
                break;
            case 25:
                GetComponent<SpriteRenderer>().enabled = false;
                break;
        }
    }
}
