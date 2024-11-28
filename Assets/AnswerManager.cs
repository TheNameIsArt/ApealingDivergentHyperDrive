using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AnswerManager : MonoBehaviour
{
    public Button wrongButton;
    public Button wrongButton1;
    public Button wrongButton2;
    public Button wrongButton3;
    public Button correctButton;
    public Button wrongButton4;
    public Button wrongButton5;
    public Button wrongButton6;
    public Button wrongButton7;
    public Button wrongButton8;
    public Button wrongButton9;
    public Button wrongButton10;
    public SceneRandomizer SceneRandomizer;
    public TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        SceneRandomizer = GameObject.Find("DontDestroyOnLoad").GetComponent<SceneRandomizer>();

        if (correctButton != null)
        {
            correctButton.onClick.AddListener(OnCorrectButtonClick);
        }

        if (wrongButton1 != null)
        {
            wrongButton1.onClick.AddListener(OnWrongButtonClick);
        }
        if (wrongButton2 != null)
        {
            wrongButton2.onClick.AddListener(OnWrongButtonClick);
        }
        if(wrongButton3 != null)
        {
            wrongButton3.onClick.AddListener(OnWrongButtonClick);
        }
        if(wrongButton4 != null)
        {
            wrongButton4.onClick.AddListener(OnWrongButtonClick);
        }
        if(wrongButton5 != null)
        {
            wrongButton5.onClick.AddListener(OnWrongButtonClick);
        }
        if (wrongButton6 != null)
        {
            wrongButton6.onClick.AddListener(OnWrongButtonClick);
        }
        if (wrongButton7 != null)
        {
            wrongButton7.onClick.AddListener(OnWrongButtonClick);
        }
        if (wrongButton8 != null)
        {
            wrongButton8.onClick.AddListener(OnWrongButtonClick);
        }
        if (wrongButton9 != null)
        {
            wrongButton9.onClick.AddListener(OnWrongButtonClick);
        }
        if (wrongButton10 != null)
        {
            wrongButton10.onClick.AddListener(OnWrongButtonClick);
        }
    }

    void OnCorrectButtonClick()
    {
        Debug.Log("Correct");
        text.text = "You're too sweet!";
        Invoke("Win", 1f);
    }

    void OnWrongButtonClick()
    {
        Debug.Log("Wrong!");
        text.text = "F#ck you!";
        Invoke("Lose", 1f);
    }

    
    void Win()
    {
        SceneRandomizer.Win = true;
    }
    void Lose()
    {
        SceneRandomizer.gameOver();
    }
}
