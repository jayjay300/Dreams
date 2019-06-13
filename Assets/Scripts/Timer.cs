using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Timer : MonoBehaviour {
	int timeleft;
	public int min,max;
	// Use this for initialization
	void Start () {
		timeleft = Random.Range (min, max);	
	}
	
	// Update is called once per frame
	void Update () {
		timeleft -= 1;

		Debug.Log (timeleft.ToString());

		if (timeleft <= 0) {
			SceneManager.LoadScene(2);
		}
	}

}
