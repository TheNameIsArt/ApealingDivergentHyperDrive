using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    private float timer = 0;
    public float totalTime;
    public GameObject logic;
    public LogicScript logicScript;
    
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.Find("Logic");
        logicScript = logic.GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < totalTime)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            logicScript.gameOver();
        }
    }
}
