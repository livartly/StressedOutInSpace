using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour {

    public float speed;
    public Transform player;

	void LateUpdate () {

        //Get the players location
        Vector3 changePos = player.transform.position;

        //Set the Z distance so it doesn't change
        changePos.z = transform.position.z;

        transform.position = Vector3.Slerp(transform.position, changePos, Time.deltaTime * speed);
	}
}
