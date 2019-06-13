using UnityEngine;
using System.Collections;

public class CompleteCameraController : MonoBehaviour
{

    public GameObject player;       //Public variable to store a reference to the player game object
    public Vector3 playerlocation;
    //public Quaternion playerrotation,newplayerrotation;
    public float hAxis, vAxis;
   // private Vector3 offset;         //Private variable to store the offset distance between the player and camera
    public int speedMod=5;
	public bool Rotate=true;
    //private bool turning = false;
    //private int direction = 0;//0=north, 1=east, 2=south, 3=west
    // Use this for initialization
    void Start()
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        //offset = transform.position - player.transform.position;
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
      
      //  playerlocation = player.transform.position;
        
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        hAxis = Input.GetAxis("Horizontal");
        vAxis = Input.GetAxis("Vertical");
      // if ((hAxis != 0 || vAxis != 0) && (turning = false))
      // {
		if(Rotate==true)
            CameraRotate();
      //      turning = true;
      //  }
      //  if(hAxis==0)
      //  { transform.LookAt(player.transform); }
    }

    void CameraRotate()
    {

        if (hAxis > 0 && vAxis == 0)
        {

            // while(transform.rotation.y < 81) { 
            if (gameObject.transform.rotation.eulerAngles.y < 90 || gameObject.transform.rotation.eulerAngles.y > 93)
            {
                transform.RotateAround(player.transform.position, new Vector3(0.0f, 90.0f, 0.0f), 20 * Time.deltaTime * speedMod);
                Debug.Log(gameObject.transform.rotation.eulerAngles.y.ToString());
            }

        }
        if (hAxis < 0 && vAxis == 0)
        {
            if (gameObject.transform.rotation.eulerAngles.y < 270 || gameObject.transform.rotation.eulerAngles.y > 273)
            {
                transform.RotateAround(player.transform.position, new Vector3(0.0f, 90.0f, 0.0f), -20 * Time.deltaTime * speedMod);
                Debug.Log(gameObject.transform.rotation.eulerAngles.y.ToString());
            }


        }
        if (vAxis > 0 && hAxis == 0)
        {
            if (gameObject.transform.rotation.eulerAngles.y < 0 || gameObject.transform.rotation.eulerAngles.y > 5)
            {
                transform.RotateAround(player.transform.position, new Vector3(0.0f, 90.0f, 0.0f), 20 * Time.deltaTime * speedMod);
                Debug.Log(gameObject.transform.rotation.eulerAngles.y.ToString());
            }


        }
        if (vAxis < 0 && hAxis == 0)
        {
            if (gameObject.transform.rotation.eulerAngles.y < 180 || gameObject.transform.rotation.eulerAngles.y > 185)
            {
                transform.RotateAround(player.transform.position, new Vector3(0.0f, 90.0f, 0.0f), -20 * Time.deltaTime * speedMod);
                Debug.Log(gameObject.transform.rotation.eulerAngles.y.ToString());
            }


        }

    }
}