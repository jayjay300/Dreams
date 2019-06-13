using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Car : MonoBehaviour {
	public Rigidbody rig;
	public int xdirec;
	// Use this for initialization
	void Start () {
		rig = gameObject.GetComponent<Rigidbody> ();
		if (transform.position.z < 0) {
			xdirec = 1;

		} else {

			xdirec = -1;
			gameObject.transform.Rotate (0, 180, 0);
		}
		rig.velocity = new Vector3 (0, 0, 200*xdirec);
	}
	
	// Update is called once per frame
	void Update () {
		if(rig.velocity.z < 25 && rig.velocity.z > -25 ){

			Destroy (gameObject);
	}

	
}

	void OnTriggerEnter(Collider other)
	{
		if (other.transform.tag == "Player")
		{
			Debug.Log("test");
			SceneManager.LoadScene(2);
		}
}
}