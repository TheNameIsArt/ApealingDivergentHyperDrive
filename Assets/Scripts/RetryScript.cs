using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetryScript : MonoBehaviour
{
    public SceneRandomizer SceneRandomizer;
    // Start is called before the first frame update
    void Start()
    {
        SceneRandomizer = GameObject.Find("DontDestroyOnLoad").GetComponent<SceneRandomizer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneRandomizer.restart();
        }
    }
}
