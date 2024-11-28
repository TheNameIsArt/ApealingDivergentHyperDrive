using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    SceneRandomizer SceneRandomizer;
    void OnTriggerEnter2D(Collider2D other)
    {
        SceneRandomizer = GameObject.Find("DontDestroyOnLoad").GetComponent<SceneRandomizer>();
        if (other.CompareTag("Player"))
        {
            // Call the win method
            SceneRandomizer.Win = true;
            
            // Destroy the coin
            Destroy(gameObject);
        }
    }
}
