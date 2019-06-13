using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour {
    public float speed = 3;
    public float y;
    Rigidbody2D rb;
    // Use this for initialization
    void Start () {
        y = transform.position.y;
        rb = GetComponent<Rigidbody2D>();
        speed = Random.Range(0.3f, 3.0f);


    }



    // Update is called once per frame
    void Update () {
        y = transform.position.y;

        if(y > 11)
        {

            Destroy(gameObject);
        }
        Vector2 movement = new Vector2(0, speed);

        rb.velocity = movement;
    }
}
