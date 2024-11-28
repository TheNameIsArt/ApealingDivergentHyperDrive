using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Call the win method
            //ChristopherGameManager.Instance.WinGame();
            
            // Destroy the coin
            Destroy(gameObject);
        }
    }
}
