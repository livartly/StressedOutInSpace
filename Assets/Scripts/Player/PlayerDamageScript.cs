using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageScript : MonoBehaviour {

    //Heart rigidbody prefab
    public GameObject heartSprite;
    private Rigidbody rb;

    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            Vector2 dir = (transform.position - coll.transform.position).normalized;
            print(dir);
            rb.velocity = (dir * 15);
            PlayerManager.player.TakeDamage();
            GameObject heart = Instantiate(heartSprite, transform.position, Quaternion.identity);
            heart.name = "Heart";
            Destroy(heart, 6);
        }
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Enemy")
        {

        }
    }

}
