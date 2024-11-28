using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soundtrack : MonoBehaviour
{
    public AudioClip song1, song2, song3;
    public static Soundtrack instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void SetSoundTrack(int songNumber)
    {
        if(songNumber == 0)
        {
            this.GetComponent<AudioSource>().clip = song1;
        }
        if (songNumber == 1)
        {
            this.GetComponent<AudioSource>().clip = song2;
        }
        if (songNumber == 2)
        {
            this.GetComponent<AudioSource>().clip = song3;
        }
        this.GetComponent<AudioSource>().Play();
    }

}