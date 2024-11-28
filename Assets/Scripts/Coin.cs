using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    SceneRandomizer SceneRandomizer;
    private void Start()
    {
        SceneRandomizer = GameObject.Find("DontDestroyOnLoad").GetComponent<SceneRandomizer>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Call the win method
            
            
            // Destroy the coin
            Destroy(gameObject);

            SceneRandomizer.Win = true;
        }
    }
}
