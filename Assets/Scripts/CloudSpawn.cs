using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawn : MonoBehaviour {
    public GameObject[] objects;                // The prefab to be spawned.
    public float spawnTime;            // How long between each spawn.
    private Vector2 spawnPosition;
    public float minTime = 0.1f, maxTime = 4.3f;

    private float time;

    //The time to spawn the object
    


    // Use this for initialization
    void Start()
    {

        SetRandomTime();
        time = 0;
        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        //InvokeRepeating("Spawn", spawnTime, spawnTime);

    }

    void SetRandomTime()
    {
        spawnTime = Random.Range(minTime, maxTime);
        Debug.Log("Next object spawn in " + spawnTime + " seconds.");
    }

    void FixedUpdate()
    {
        //Counts up
        time += Time.deltaTime;
        //Check if its the right time to spawn the object
        if (time >= spawnTime)
        {
           // Debug.Log("Time to spawn: " + enemy.name);
            Spawn();
            SetRandomTime();
            time = 0;
        }
    }


    void Spawn()
    {
        spawnPosition.x = Random.Range(-17, 17);
        spawnPosition.y = -11.0f;
 

        Instantiate(objects[UnityEngine.Random.Range(0, objects.Length - 1)], spawnPosition, Quaternion.identity);
    }
}
