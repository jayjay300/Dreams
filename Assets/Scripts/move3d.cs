using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class move3d : MonoBehaviour
{
    public float walkspeed = 1f;
    public float jumpspeed = 1f;
    public float posy;
    public float bottom;
    Rigidbody rb;
    Collider coll;


    bool pressedJump = false;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        coll = GetComponent<Collider>();
    }
    void OnTriggerEnter(Collider other)
    {

		if (other.transform.tag == "Car")
		{
			Debug.Log("testCAR");

			SceneManager.LoadScene(2);
		}

    }
    // Update is called once per frame
    void Update()
    {
        posy = gameObject.GetComponent<Rigidbody>().position.y;
        if (posy < bottom)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }
        WalkHandler();
        JumpHandler();

    }
	void FixedUpdate(){
		if (SceneManager.GetActiveScene().buildIndex == 9) {
			Debug.Log ("velocity" + rb.velocity.z);
			if (rb.velocity.z > 2 || rb.velocity.z < -2 || rb.velocity.y > 0.5) {
				SceneManager.LoadScene (2);
			}
		}
	}

    void WalkHandler()
    {



        rb.velocity = new Vector3(0, rb.velocity.y, 0);
        float distance = walkspeed * Time.deltaTime;

        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

    //    if(vAxis<0)
      //  {
   
     //           transform.Rotate(Vector3.up * Time.deltaTime, transform.position.y);
            
     //   }
        Vector3 movement = new Vector3(hAxis * distance,0f, vAxis * distance);

        Vector3 currPosition = transform.position;

        Vector3 newPosition = currPosition + movement;


        rb.MovePosition(newPosition);

    }

    void JumpHandler()
    {
        // Jump axis
        float jAxis = Input.GetAxis("Jump");
        bool isGrounded = CheckGrounded();

        if (jAxis > 0f)
        {

            if (pressedJump == false && isGrounded == true)
            {
                pressedJump = true;
                // Jumping vector
                Vector3 jumpVector = new Vector3(0f, jumpspeed, 0f);

                // Make the player jump by adding velocity
                rb.velocity = rb.velocity + jumpVector;

            }

        }
        else
        {

            pressedJump = false;
        }
    }
    bool CheckGrounded()
    {
        // Object size in x
        float sizeX = coll.bounds.size.x;
        float sizeZ = coll.bounds.size.z;
        float sizeY = coll.bounds.size.y;

        // Position of the 4 bottom corners of the game object
        // We add 0.01 in Y so that there is some distance between the point and the floor
        Vector3 corner1 = transform.position + new Vector3(sizeX / 2, -sizeY / 2 + 0.01f, sizeZ / 2);
        Vector3 corner2 = transform.position + new Vector3(-sizeX / 2, -sizeY / 2 + 0.01f, sizeZ / 2);
        Vector3 corner3 = transform.position + new Vector3(sizeX / 2, -sizeY / 2 + 0.01f, -sizeZ / 2);
        Vector3 corner4 = transform.position + new Vector3(-sizeX / 2, -sizeY / 2 + 0.01f, -sizeZ / 2);

        // Send a short ray down the cube on all 4 corners to detect ground
        bool grounded1 = Physics.Raycast(corner1, new Vector3(0, -1, 0), 0.01f);
        bool grounded2 = Physics.Raycast(corner2, new Vector3(0, -1, 0), 0.01f);
        bool grounded3 = Physics.Raycast(corner3, new Vector3(0, -1, 0), 0.01f);
        bool grounded4 = Physics.Raycast(corner4, new Vector3(0, -1, 0), 0.01f);

        // If any corner is grounded, the object is grounded
        return (grounded1 || grounded2 || grounded3 || grounded4);
    }
}
