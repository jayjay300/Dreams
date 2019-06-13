using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharMove : MonoBehaviour {
    public float speed=3;
    public float horizontal;
    Rigidbody2D rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        
        float Horizontal = Input.GetAxis("Horizontal");


        Vector2 movement = new Vector2(Horizontal*speed, 0);

        rb.velocity = movement;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Cloud")
        {
            Debug.Log("test");
            SceneManager.LoadScene(2);

        }
    }
}
