using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainRotateScript : MonoBehaviour
{
    public GameObject planet;

    public Vector3 axis;

    public float speed = 10;

    void Update()
    {
        transform.RotateAround(planet.transform.position, axis, speed * Time.deltaTime * 60);
    }
}
