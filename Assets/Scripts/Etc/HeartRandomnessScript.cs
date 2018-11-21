using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartRandomnessScript : MonoBehaviour {

    private Rigidbody rb;
    public float speed;

	void Start () {
        rb = GetComponent<Rigidbody>();
        rb.velocity = Random.insideUnitSphere * speed;
	}

    
}
