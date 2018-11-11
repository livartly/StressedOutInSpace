using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    //Private boiiis
    private Rigidbody rb;
    private Vector3 movement = Vector3.zero;

    //Basic player settings
    public float speed = 10, maxSpeed = 50, jumpForce = 10, gravity = 1, raycastLength = 8f;

    //Layer Mask
    public LayerMask lm;

    //Use for current target later
    public GameObject planet;

	void Start () {
        //Grab the rigidbody componet
        rb = GetComponent<Rigidbody>();

        //Invert Layermask Selection
        lm = ~lm;
        rb.useGravity = false;
	}
	
	void Update () {

        RaycastHit hit;
        //Draw The Raycast
        Debug.DrawRay(transform.position, -GetGravityDirection() * raycastLength);

        //Check if Grounded
        if (Physics.Raycast(transform.position, -GetGravityDirection(), out hit, raycastLength, lm))
        {
            //if Grounded
            if (hit.transform.tag == "Ground")
            {
                Debug.Log("Grounded");
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
                {
                    rb.velocity = GetGravityDirection() * jumpForce * Time.deltaTime * 60;
                    print("Jump");
                }
            }
        }

        //Left && Right Movement
        //Movement input variable & Player Left and Right Movement
        movement = new Vector3(Input.GetAxis("Horizontal") * Time.deltaTime, 0, 0);
        rb.AddRelativeForce(-movement * speed * 60);

        //Keep player zero'd on Z axis
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);

        //Rotation Finding System
        Vector3 relative = transform.InverseTransformPoint(planet.transform.position);
        var angle = Mathf.Atan2(relative.x, relative.y) * Mathf.Rad2Deg;
        transform.Rotate(0, 0, -angle);

        //Pull Towards Planet
        Gravity();
    }

    void Gravity() {
        //Move towards ground
        var holder = -GetGravityDirection() * gravity * Time.deltaTime * 60;
        rb.AddForce(holder);
        //transform.position -= GetGravityDirection() * gravity * Time.deltaTime;
        Debug.DrawRay(transform.position, -GetGravityDirection() * 10f, Color.blue);
    }

    Vector3 GetGravityDirection() {
        //Find Gravity Direction
        Vector3 gravityDir = (this.transform.position - planet.transform.position).normalized;       
        return gravityDir;
    }
}
