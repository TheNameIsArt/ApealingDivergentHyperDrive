using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject Hairy;
    //private float timer = 0;
    public float spawnRate;
    public List<GameObject> enemyList = new List<GameObject>();
    public LogicScript logic;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        spawnHarry();
    }
    void spawnHarry()
    {

        for (var i = 1; i < 10; i++)

            enemyList.Add(Instantiate(Hairy, new Vector3(Random.Range(-7, 7), Random.Range(-4, 4), 90), transform.rotation));
        // Call instantiate here


    }
}