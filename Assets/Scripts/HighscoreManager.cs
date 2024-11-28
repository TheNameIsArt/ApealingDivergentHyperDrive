using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreManager : MonoBehaviour
{

    public static HighscoreManager instance;
    public TMP_Text highscoreText;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        highscoreText.text = LoadHighscore().ToString();
    }

    public void SaveHighscore(int score)
    {
        if (score > LoadHighscore())
        {
            PlayerPrefs.SetInt("Highscore", score);
            PlayerPrefs.Save();
        }
    }

    public int LoadHighscore()
    {
        int score = PlayerPrefs.GetInt("Highscore");
        return score;
    }

    public void ResetHighscore()
    {
        PlayerPrefs.SetInt("Highscore", 0);
        PlayerPrefs.Save();
    }
}