using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuMoveScript : MonoBehaviour {

    public float speed;

    public Vector3 offset;

    private void Awake()
    {
        offset = transform.position;
    }

    void Update () {

        Vector2 dir = Camera.main.ScreenToViewportPoint(Input.mousePosition);

        Vector3 fixPos = new Vector3(dir.x + offset.x, dir.y + offset.y, transform.position.z);

        transform.position = Vector3.Slerp(transform.position, fixPos, Time.deltaTime * speed * 60);
    }
}
