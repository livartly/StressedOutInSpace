using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour {

    public float speed;
    public float distanceFromPlayer;
    public Transform player;

    private void Awake()
    {
        if (distanceFromPlayer > 0)
            distanceFromPlayer *= -1;
    }

    void LateUpdate () {

        //Get the players location
        Vector3 changePos = player.transform.position;

        //Set the Z distance so it doesn't change
        changePos.z = distanceFromPlayer;

        transform.position = Vector3.Slerp(transform.position, changePos, Time.deltaTime * speed);
	}
}
