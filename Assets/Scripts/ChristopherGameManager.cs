using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChristopherGameManager : MonoBehaviour
{
    public static ChristopherGameManager Instance;

    void Awake()
    {
        // Ensure there's only one instance of ChristopherGameManager
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void WinGame()
    {
        // Implement your win logic here
        Debug.Log("You Win!");
        // For example, load a win scene or display a win message
    }
}
