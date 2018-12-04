using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    //Some Dank OOP allocation
    public static PlayerClass player = new PlayerClass(10, 10, 3);
    public float speed = 10, jumpForce = 10, maxSpeed = 15;
    public int health = 3;

    //Rigidbody effects
    private Rigidbody rb;
    private float timer = -99;
    private bool hasLost = false;

    public FadeEffect fader;

    void Start () {
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
        }
        if (player.GetLost()) {
            print("Player is spaced out");
            //Player is Spaced Out
            player.Lost();
            rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.None;
        }

        if (timer >= 0)
            timer -= Time.deltaTime;

        if (timer < 0 && hasLost)
        {
            fader.FadeOut(3);
        }

        if (player.GetLost() || player.GetHealth() <= 0 && timer < 0)
        {
            print("Test");
            timer = 4;
            hasLost = true;
        }
    }
}
