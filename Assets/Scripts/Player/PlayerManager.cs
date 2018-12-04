using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    public Animator anim;

    //Some Dank OOP allocation
    public static PlayerClass player = new PlayerClass(10, 10, 3);
    public float speed = 10, jumpForce = 10, maxSpeed = 15;
    public int health = 3;

    //Rigidbody effects
    private Rigidbody rb;

    void Start () {
        //Get animation Component
        anim = GetComponent<Animator>();

        //Set Defaults
        player.SetSpeed(speed);
        player.SetHealth(health);
        player.SetJumpForce(jumpForce);
        player.SetMaxSpeed(maxSpeed);

        //Get the rigidbody componet
        rb = GetComponent<Rigidbody>();
	}

    void Update()
    {
        //If health is 0 or less
        if (player.GetHealth() <= 0)
        {
            print("Player is Dead");
            //Player is dead !rip
            player.SetSpeed(0);
            player.SetJumpForce(0);
            rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.None;

            //Death animation NOT WORKING
            anim.Play("death");
            
        }
        if (player.GetLost()) {
            print("Player is spaced out");
            //Player is Spaced Out
            player.Lost();
            rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.None;
        }
    }
}
