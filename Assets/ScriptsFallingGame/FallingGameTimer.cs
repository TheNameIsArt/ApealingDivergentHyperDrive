using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FallingGameTimerScript : MonoBehaviour
{
    public float timer = 5;
    private float totalTime = 0;
    public SceneRandomizer sceneRandomizer;
    public TMP_Text timerTxt;
    public bool timerStopper = false;
    private bool Winner;
    bool isWinner = false;
    bool sceneLoading = false;

    // Start is called before the first frame update
    void Start()
    {
        sceneRandomizer = GameObject.Find("DontDestroyOnLoad").GetComponent<SceneRandomizer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (timerStopper == false)
        {
            Time.timeScale = sceneRandomizer.gameSpeedFloat;
            if (timer > totalTime)
            {
                timer = timer - Time.deltaTime;
            }
            else
            {
                isWinner = true;
                if(isWinner == true && !sceneLoading)
                {
                    sceneLoading = true;
                    Invoke("Win", 0.2f);
                }
                
            }
            float roundedtime = (float)System.Math.Round(timer, 2);
            timerTxt.text = "Time left: " + roundedtime.ToString();
        }

        
            
        

    }
    void Win()
    {
        
        sceneRandomizer.Win = true; 
    }
}
