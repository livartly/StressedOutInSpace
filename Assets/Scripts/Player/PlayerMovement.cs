using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    //Private boiiis
    private Rigidbody rb;
    private Vector3 movement = Vector3.zero;

    //Basic player settings
    public float speed = 10, maxSpeed = 50, jumpForce = 10, gravity = 1, raycastLength = 8f, rotSpeed = 6;
    private float doubleJump = 1;

    //Layer Mask
    public LayerMask lm;

    //Use for current target later
    public GameObject[] planets;
    private int closestIndex;
    private Quaternion currRotation;

    void Start () {
        //Grab the rigidbody componet
        rb = GetComponent<Rigidbody>();

        //Invert Layermask Selection
        lm = ~lm;
        rb.useGravity = false;

        GameObject[] numOfPlanets = GameObject.FindGameObjectsWithTag("Planet");
        planets = new GameObject[numOfPlanets.Length];
        for (int i = 0; i < numOfPlanets.Length; i++)
        {
            planets[i] = numOfPlanets[i];
        }
    }
	
	void FixedUpdate () {

        //Rotation Finding System
        Vector3 relative = transform.InverseTransformPoint(planets[closestIndex].transform.position);
        var angle = Mathf.Atan2(relative.x, relative.y) * Mathf.Rad2Deg;


        //Hit Componet
        RaycastHit hit;
        //Draw The Raycast
        Debug.DrawRay(transform.position, -GetGravityDirection() * raycastLength);

        //Check if Grounded
        if (Physics.Raycast(transform.position, -GetGravityDirection(), out hit, raycastLength, lm))
        {
            //if Grounded
            if (hit.transform.tag == "Planet")
            {
                doubleJump = 1;
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
                {
                    rb.velocity = GetGravityDirection() * jumpForce * Time.deltaTime * 60;
                    currRotation = SetAngle(angle);
                }
            }
            //If Grounded Rotate Faster
            transform.Rotate(0, 0, -angle);
        }
        else
        {
            //If double jump > 0 allow for a jump
            if (doubleJump > 0)
            {
                //Check for the jump input
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
                {
                    //subtract the double jump ability number
                    doubleJump -= 1;
                    //Set velocity upwards
                    rb.velocity = GetGravityDirection() * jumpForce * Time.deltaTime * 60;                      
                    //print("Jump");
                }
            }
            //If airborn lerp rotation
            //Store Rotation Quaternion

            Quaternion angleRotation = Quaternion.Euler(0, 0, angle);

            transform.rotation = Quaternion.Slerp(currRotation, angleRotation, Time.deltaTime * rotSpeed);
        }

        //Left && Right Movement
        //Movement input variable & Player Left and Right Movement
        movement = new Vector3(Input.GetAxis("Horizontal") * Time.deltaTime, 0, 0);
        rb.AddRelativeForce(-movement * speed * 60);

        //Keep player zero'd on Z axis
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);

        //Pull Towards Planet
        Gravity();
        //Check Closest Planet
        CheckClosestPlanet();
    }

    void Gravity() {
        //Move towards ground
        var holder = -GetGravityDirection() * gravity * Time.deltaTime * 60;
        rb.AddForce(holder);

        //Draw the gravity vector
        Debug.DrawRay(transform.position, -GetGravityDirection() * 10f, Color.blue);
    }

    void CheckClosestPlanet() {

        float distance = 9999;

        for (int i = 0; i < planets.Length; i++)
        {
            if (distance > (transform.position - planets[i].transform.position).magnitude)
            {
                distance = (transform.position - planets[i].transform.position).magnitude;
                closestIndex = i;
            }
        }
    }

    Vector3 GetGravityDirection() {
        //Find Gravity Direction
        Vector3 gravityDir = (this.transform.position - planets[closestIndex].transform.position).normalized;       
        return gravityDir;
    }

    public void StopPlayer() {
        this.speed = 0;
    }

    public Quaternion SetAngle(float angle) {
        return Quaternion.Euler(0, 0, angle);
    }
}
