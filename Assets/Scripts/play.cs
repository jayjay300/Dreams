using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class play : MonoBehaviour {
    public int min = 3, max = 5;
    int room;
	// Use this for initialization
	void Start () {
        room = Random.Range(min, max);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("space"))
        {
			
            SceneManager.LoadScene(room);
        }
    }
}
