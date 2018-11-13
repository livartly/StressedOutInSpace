using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuMoveScript : MonoBehaviour {

    private Rigidbody2D rb;
    public float speed;

	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}

	void Update () {

        Vector2 dir = Camera.main.ScreenToViewportPoint(Input.mousePosition);

        Vector3 fixPos = new Vector3(dir.x, dir.y, transform.position.z);

        transform.position = Vector3.Slerp(transform.position, fixPos, Time.deltaTime * speed * 60);
    }
}
