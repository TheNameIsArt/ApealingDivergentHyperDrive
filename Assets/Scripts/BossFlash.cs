using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFlash : MonoBehaviour
{

    public bool Win = false;
    public int AttackDetect = 0;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().enabled = false;

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
            case 3:
                GetComponent<SpriteRenderer>().enabled = true;
                break;
            case 4:
                GetComponent<SpriteRenderer>().enabled = false;
                break;
            case 7:
                GetComponent<SpriteRenderer>().enabled = true;
                break;
            case 8:
                GetComponent<SpriteRenderer>().enabled = false;
                break;
            case 12:
                GetComponent<SpriteRenderer>().enabled = true;
                break;
            case 13:
                GetComponent<SpriteRenderer>().enabled = false;
                break;
            case 17:
                GetComponent<SpriteRenderer>().enabled = true;
                break;
            case 18:
                GetComponent<SpriteRenderer>().enabled = false;
                break;
            case 22:
                GetComponent<SpriteRenderer>().enabled = true;
                break;
            case 23:
                GetComponent<SpriteRenderer>().enabled = false;
                break;
        }
    }
}
