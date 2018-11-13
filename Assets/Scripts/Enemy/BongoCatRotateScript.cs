using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BongoCatRotateScript : MonoBehaviour {

    public float speed = 3;

	void Update () {
        transform.Rotate(new Vector3(0, 0, Time.deltaTime * speed * 60));	
	}
}
