using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class TimerScript : MonoBehaviour
{
    private float timer = 10;
    private float totalTime = 0;
    public SceneRandomizer sceneRandomizer;
    public LogicScript LogicScript;
    public TMP_Text timerTxt;
    
    // Start is called before the first frame update
    void Start()
    {
        sceneRandomizer = GameObject.Find("DontDestroyOnLoad").GetComponent<SceneRandomizer>();
        LogicScript = GameObject.Find("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > totalTime)
        {
            timer = timer - Time.deltaTime;
        }
        else
        {
            LogicScript.gameOver();
            sceneRandomizer.gameOver();
        }
        float roundedtime = (float)System.Math.Round(timer, 2);
        timerTxt.text = "Time left: " + roundedtime.ToString();
    }
}
