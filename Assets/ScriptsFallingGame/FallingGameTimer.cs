using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FallingGameTimerScript : MonoBehaviour
{
    private float timer = 5;
    private float totalTime = 0;
    public SceneRandomizer sceneRandomizer;
    public TMP_Text timerTxt;
    public bool timerStopper = false;

    // Start is called before the first frame update
    void Start()
    {
        sceneRandomizer = GameObject.Find("DontDestroyOnLoad").GetComponent<SceneRandomizer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!timerStopper)
        {
            if (timer > totalTime)
            {
                timer = timer - Time.deltaTime;
            }
            else
            {
                sceneRandomizer.Win = true;
            }
            float roundedtime = (float)System.Math.Round(timer, 2);
            timerTxt.text = "Time left: " + roundedtime.ToString();
        }

    }
}
