using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageScript : MonoBehaviour {

    //Heart rigidbody prefab
    public GameObject heartSprite;
    public float coolDownTimer = 3f;

    private Rigidbody rb;
    private float timer = -99;
    private bool immune = false;

    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Enemy" && !immune)
        {
            Vector2 dir = (transform.position - coll.transform.position).normalized;
            rb.velocity = (dir * 17);
            if (PlayerManager.player.GetHealth() > 0)
            {
                immune = true;
                timer = coolDownTimer;
                PlayerManager.player.TakeDamage();
                GameObject heart = Instantiate(heartSprite, transform.position, Quaternion.identity);
                heart.name = "Heart";
                Destroy(heart, 6);
            }
        }
    }
    void OnCollisionStay(Collision coll)
    {
        if (coll.gameObject.tag == "Enemy" && !immune)
        {
            Vector2 dir = (transform.position - coll.transform.position).normalized;
            rb.velocity = (dir * 17);
            if (PlayerManager.player.GetHealth() > 0)
            {
                immune = true;
                timer = coolDownTimer;
                PlayerManager.player.TakeDamage();
                GameObject heart = Instantiate(heartSprite, transform.position, Quaternion.identity);
                heart.name = "Heart";
                Destroy(heart, 6);
            }
        }
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Enemy")
        {

        }
    }

    private void FixedUpdate()
    {
        if (timer >= 0)
            timer -= Time.deltaTime;
        if (timer < 0)
            immune = false;
    }
}
