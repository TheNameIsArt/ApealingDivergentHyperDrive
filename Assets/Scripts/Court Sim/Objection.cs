using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class Objection : MonoBehaviour
{
    public AudioSource blahblah; // Reference to the AudioSource
    private bool canPressSpace = false; // Whether the player can press space
    private float stopTime; // Random time when the sound will stop
    public GameObject timer;
    private UniversalTimerScript timerScript;
    private SceneRandomizer SceneRandomizer;
    public GameObject Button;
    public TMP_Text speechText;
    public TMP_Text enemyTxt;
    public GameObject playerSpeechBoble;
    public GameObject EnemySpeechBoble;
    public AudioSource objectionspeech;
    private bool blablabool =false;
    public AudioSource erhm;

    void Start()
    {
        SceneRandomizer = GameObject.Find("DontDestroyOnLoad").GetComponent<SceneRandomizer>();
        PlaySound();
    }

    void Update()
    {
        // Stop the sound at the random time
        if (blahblah.isPlaying && Time.time >= stopTime && blablabool == true)
        {
            blablabool = false;
            blahblah.Stop();
            canPressSpace = true; // Enable space press
            Debug.Log("Sound stopped! Press Space!");
            timer.SetActive(true);
            timerScript = timer.GetComponent<UniversalTimerScript>();
            Debug.Log("Timescript got!");
            return;
        }

        // Check for spacebar press
        if (canPressSpace && Input.GetKeyDown(KeyCode.Space))
        {
           correctPres();

        }

        //if spacebar pressed at wrong time play win method
        if(!canPressSpace && Input.GetKeyUp(KeyCode.Space) && blahblah.isPlaying)
        {
            Lose();
        }
        //if spacebar pressed to early gameover method 
    }

    void PlaySound()
    {
        blahblah.Play();
        blablabool = true;
        float randomDuration = Random.Range(1f, 5f); // Generate a random time between 2 and 5 seconds
        stopTime = Time.time + randomDuration; // Calculate when to stop the sound
        canPressSpace = false; // Reset the state
        Debug.Log("Sound playing... it will stop randomly!");
    }
    void Won()
    {
        SceneRandomizer.Win = true;
    }
    void correctPres()
    {
        
        Debug.Log("Space pressed in time! You win!");
        canPressSpace = false; // Reset the state
        timerScript.timerStopper = true;
        playerSpeechBoble.SetActive(true);
        EnemySpeechBoble.SetActive(false);
        objectionspeech.Play();
        Button.SetActive(false);
        enemyTxt.text = "Damn...";
        speechText.text = "You just won your case!";
        Invoke("Won", 2f);
    }
    void Lose()
    {
        blahblah.Stop();
        Time.timeScale = 0f;
        erhm.Play();
        enemyTxt.text = "Hahaha I won!";
        Button.SetActive(false);
        speechText.text = "Wait your turn! Case dismissed.";
        Invoke("GameOver", 2f);
    }

    void GameOver()
    {
        SceneRandomizer.gameOver();
    }
}
