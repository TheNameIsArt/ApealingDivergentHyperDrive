using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HairyScript : MonoBehaviour
{
    public GameObject Hairy;
    public AudioSource pointSound;
    public LogicScript logic;
    public SpawnerScript spawner;
    //public GameObject gameOver;
    // Start is called before the first frame update
    void Start()
    {
        pointSound = GameObject.Find("PointPlayer").GetComponent<AudioSource>();
        logic = GameObject.Find("Logic").GetComponent<LogicScript>();
        spawner = GameObject.Find("Spawner").GetComponent<SpawnerScript>();
        


    }

    // Update is called once per frame
    void Update()
    {


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3 && logic.gameIsOver == false)
        {
            pointSound.Play(1);
            logic.pointGet(1);
            spawner.enemyList.Remove(gameObject);
            Destroy(gameObject);
            //Debug.Log("point givet");
            if (spawner.enemyList.Count == 0)
            {
                logic.winner();
            }
        }
        else
        {
            Destroy(gameObject);
            

        }
    }
}
