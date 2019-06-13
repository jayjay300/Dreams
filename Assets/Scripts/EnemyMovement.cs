using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    public float speed = 5;
    public float x;
    Rigidbody2D rb;
    // Use this for initialization
    void Start () {
        x = transform.position.x;
        rb = GetComponent<Rigidbody2D>();
        //speed = Random.Range(0.3f, 3.0f);


    }



    // Update is called once per frame
    void Update () {
        x = transform.position.x;

        if(x < -15)
        {

            Destroy(gameObject);
        }
        Vector2 movement = new Vector2(speed*-1, 0);

        rb.velocity = movement;
    }
}
