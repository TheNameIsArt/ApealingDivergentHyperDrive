using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCon : MonoBehaviour
{

    private int WinDetect = 0;
    private bool win = false;

    void Win()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            WinDetect = WinDetect + 1;
        }
        else
            if(WinDetect >= 26)
        {
            win = true;
            Debug.Log("Win Detected");
        }

    }

    private void Update()
    {
        Win();
    }
}
