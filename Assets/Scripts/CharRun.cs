using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharRun : MonoBehaviour {
    public float speed=3;
    public float vAxis,vertical;
    public int jumpspeed = 1;
    public bool isGrounded = true, pressedJump;
    Rigidbody2D rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

            jump();

           


        
       // Vector2 movement = new Vector2(Horizontal*speed, 0);

       // rb.velocity = movement;
    }

  
    private void jump()
    {
		vAxis = Input.GetAxis("Jump");

      /*  if (transform.position.y > -1.55f)
        {
            isGrounded = false;

        }
        else
        {
            isGrounded = true;

        } */


        if (vAxis > 0f && pressedJump == false)
        {
            pressedJump = true;

            if (isGrounded == true)
            {

                
                // Jumping vector
                
                    Vector2 jumpVector = new Vector2(0f, jumpspeed *3);
                    // rb.AddForce(Vector2.up * 100 * vAxis);
                    // Make the player jump by adding velocity
                    rb.velocity = rb.velocity + jumpVector;
                isGrounded = false;


            }

        }
        else
        { 
            pressedJump = false;
            vertical = gameObject.transform.position.y;
            //if (isGrounded == false)
           // {
               Vector2 jumpVector = new Vector2(0f, jumpspeed  *-0.25f);

                // Make the player jump by adding velocity
                rb.velocity = rb.velocity + jumpVector;
                if(vertical <= -1.55f)
                {
                   
                    jumpVector = new Vector2(0f, 0);

                    // Make the player jump by adding velocity
                    rb.velocity = jumpVector;
                    isGrounded = true;
                }

           // }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Mud")
        {
            Debug.Log("test");
            SceneManager.LoadScene(2);

        }
    }
}
