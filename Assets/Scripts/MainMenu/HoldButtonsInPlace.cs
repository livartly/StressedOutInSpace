using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldButtonsInPlace : MonoBehaviour {

    public Transform positionsHolder;

	void LateUpdate () {
        transform.position = positionsHolder.position;
	}
}
