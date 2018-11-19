using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLocations : MonoBehaviour {

    public Transform[] targetPoints;
    public float speed = 1;

    private int transformIndex = 0;
    private int currentLocation = 0;
	
	void Update () {
        transform.position = Vector3.Lerp(transform.position, targetPoints[transformIndex].transform.position, Time.deltaTime * speed);
	}

    public void UpdateCameraLocation(int val) {
        transformIndex = val;
    }
}
