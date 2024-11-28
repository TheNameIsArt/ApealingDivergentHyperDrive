using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitchManager : MonoBehaviour
{

    public AudioSource audioSource;
    public static PitchManager instance;

    private void Awake()
    {
        instance = this; 
    }


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ChangePitch()
    {
        audioSource.pitch = Random.Range(0.5f, 1.8f);
    }

}
