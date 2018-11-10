using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    //Private boiiis
    private Rigidbody rb;
    private Vector3 movement = Vector3.zero;

    //Basic player settings
    public float speed, gravity;

    //Use for current target later
    public GameObject planet;

	void Start () {
        //Grab the rigidbody componet
        rb = GetComponent<Rigidbody>();
	}
	
	void Update () {
        //To-do add a raycast and check ifGrounded

        //Keep player zero'd on Z axis
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);

        //Movement input variable & Player Left and Right Movement
        movement = new Vector3(Input.GetAxis("Horizontal") * Time.deltaTime, 0, 0);
        rb.AddRelativeForce(-movement * speed * 60);

        //Rotation Finding System
        Vector3 relative = transform.InverseTransformPoint(planet.transform.position);
        var angle = Mathf.Atan2(relative.x, relative.y) * Mathf.Rad2Deg;
        transform.Rotate(0, 0, -angle);

        //Call The Gravity Update
        Gravity();
	}

    void Gravity() {
        //Find Gravity Direction
        Vector3 gravityDir = (this.transform.position - planet.transform.position).normalized;
        //Move towards ground
        rb.velocity = -gravityDir * gravity * Time.deltaTime * 60;
    }
}
