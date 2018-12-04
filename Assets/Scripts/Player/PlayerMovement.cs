using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator anim;
    public GameObject playerCharacter;
    private bool facingRight = false;

    //Private
    private Rigidbody rb;
    private Vector3 movement = Vector3.zero;

    //Basic player settings
    public float maxSpeed = 50, gravity = 1, raycastLength = 8f, rotSpeed = 6;
    private float doubleJump = 1;

    //Layer Mask
    public LayerMask lm;

    //Use for current target later
    public GameObject[] planets;
    private int closestIndex;
    private Quaternion currRotation;

    //Particle System reference
    public ParticleSystem PS;
    public float jetPackTimer = 1;

    void Start()
    {       
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

    void FixedUpdate()
    {
        //Rotation Finding System
        Vector3 relative = transform.InverseTransformPoint(planets[closestIndex].transform.position).normalized;
        var angle = Mathf.Atan2(relative.x, relative.y) * Mathf.Rad2Deg;

        //Hit Componet
        RaycastHit hit;
        //Draw The Raycast
        Debug.DrawRay(transform.position, -GetGravityDirection() * raycastLength);

        //Check if Grounded
        if (Physics.Raycast(transform.position, -GetGravityDirection(), out hit, raycastLength, lm))
        {
            //if Grounded
            if (hit.transform.tag == "Planet" || hit.transform.tag == "ground")
            {
                doubleJump = 1;
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
                {
                    //Jump animation NOT WORKING 
                    anim.Play("jump");

                    //Jump Particle System
                    StartCoroutine(Jetpack(jetPackTimer));
                    PS.Play();

                    //Jump Physics
                    rb.velocity = GetGravityDirection() * PlayerManager.player.GetJumpForce() * Time.deltaTime * 60;
                    currRotation = Quaternion.Euler(0, 0, 0);
                }
            }
            //If Grounded Rotate Faster
            //transform.Rotate(0, 0, -angle);
        }
        else
        {
            //If double jump > 0 allow for a jump
            if (doubleJump > 0)
            {
                //Check for the jump input
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
                {
                    //Jump animation NOT WORKING 
                    anim.Play("jump");

                    //Jump Particle System
                    StartCoroutine(Jetpack(jetPackTimer));
                    PS.Play();

                    //subtract the double jump ability number
                    doubleJump -= 1;
                    //Set velocity upwards
                    rb.velocity = GetGravityDirection() * PlayerManager.player.GetJumpForce() * Time.deltaTime * 60;
                    //print("Jump");
                }
            }

            //If airborn lerp rotation
            //Store Rotation Quaternion

            //Quaternion angleRotation = Quaternion.Euler(0, 0, (-angle * Mathf.Deg2Rad));
            //transform.rotation = Quaternion.Lerp(transform.rotation, angleRotation, Time.deltaTime * rotSpeed);
        }

        //If the player is dead we don't need this....
        if (PlayerManager.player.GetHealth() >= 0)
        {
            //Fix Rotation
            transform.Rotate(0, 0, -angle);
        }

        //Left && Right Movement
        //Movement input variable & Player Left and Right Movement
        movement = new Vector3(Input.GetAxis("Horizontal") * Time.deltaTime, 0, 0);
        if (rb.velocity.magnitude < PlayerManager.player.GetMaxSpeed())
        {            
            rb.AddRelativeForce(-movement * PlayerManager.player.GetSpeed() * 60);
        }

        //Keep player zero'd on Z axis
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);

        //Pull Towards Planet
        Gravity();
        //Check Closest Planet
        CheckClosestPlanet();


        //Check if Grounded
        if (Physics.Raycast(transform.position, -GetGravityDirection(), out hit, raycastLength, lm))
        {
            //if Grounded
            if (hit.transform.tag == "Planet" || hit.transform.tag == "ground" && PlayerManager.player.GetHealth() > 0)
            {
                //If player is walking
                if (rb.velocity.magnitude > 0.3f)
                    anim.Play("walk");
                else
                    anim.Play("idle");
            }

            var local_X_Velocity= transform.InverseTransformDirection(rb.velocity);
            if (movement.magnitude > 0.0001)
            if (local_X_Velocity.x > -.3 && !facingRight)
                SwapDirection();
            else if (local_X_Velocity.x < .3 && facingRight)
                SwapDirection();
        }

        if (PlayerManager.player.GetLost())
        {
            rb = null;
        }

        //If Player is dead
        if (PlayerManager.player.GetHealth() <= 0 || PlayerManager.player.GetLost())
        {
            anim.Play("death");
        }
    }

    void Gravity()
    {
        //Move towards ground
        var holder = -GetGravityDirection() * gravity * Time.deltaTime * 60;
        rb.AddForce(holder);

        //Draw the gravity vector
        //Debug.DrawRay(transform.position, -GetGravityDirection() * 10f, Color.blue);
    }

    void CheckClosestPlanet()
    {

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

    Vector3 GetGravityDirection()
    {
        //Find Gravity Direction
        Vector3 gravityDir = (this.transform.position - planets[closestIndex].transform.position).normalized;
        return gravityDir;
    }

    public void StopPlayer()
    {
        PlayerManager.player.SetSpeed(0);
        PlayerManager.player.SetJumpForce(0);
    }

    Quaternion SetAngle(float angle)
    {
        return Quaternion.Euler(0, 0, angle);
    }

    IEnumerator Jetpack(float val)
    {
        yield return new WaitForSeconds(val);
        PS.Stop();
        StopCoroutine("Jetpack()");
    }

    void SwapDirection() {
        facingRight = !facingRight;
        var temp = playerCharacter.transform.localScale;
        temp.x *= -1;
        playerCharacter.transform.localScale = temp;
    }
}
