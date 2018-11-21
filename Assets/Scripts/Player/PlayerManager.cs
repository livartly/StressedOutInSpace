using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    //Some Dank OOP allocation
    public static PlayerClass player = new PlayerClass(10, 10, 3);
    public float speed = 10, jumpForce = 10;
    public int health = 3;

    //Rigidbody effects
    private Rigidbody rb;

    void Start () {
        //Set Defaults
        player.SetSpeed(speed);
        player.SetHealth(health);
        player.SetJumpForce(jumpForce);

        //Get the rigidbody componet
        rb = GetComponent<Rigidbody>();
	}

    void Update()
    {
        //If health is 0 or less
        if (player.GetHealth() <= 0)
        {
            //Player is dead !rip
            player.SetSpeed(0);
            player.SetJumpForce(0);
            rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.None;
            //Play ragdoll physics lol.
        }
    }
}
