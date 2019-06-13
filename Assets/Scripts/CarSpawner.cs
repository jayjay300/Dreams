using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour {
	public GameObject[] objects; 
	// Use this for initialization
        
	public float spawnTime;            // How long between each spawn.
	private Vector3 spawnPosition;
	public float minTime = 2f, maxTime = 6f;
	public int xdirec;
	private float time;
	public Rigidbody rig;

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
		GameObject spawned = objects [0];
	//	rig = spawned.GetComponent<Rigidbody>();
		Debug.Log ("Spawned");
		spawnPosition = gameObject.transform.position;
		spawnPosition.y = 3.3f;
		//spawnPosition.z = -400;
        Debug.Log(spawnPosition);





		Instantiate(spawned, spawnPosition, Quaternion.identity);

	}
}
