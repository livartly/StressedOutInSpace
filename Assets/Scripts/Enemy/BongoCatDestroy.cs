using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BongoCatDestroy : MonoBehaviour {

    public GameObject BongoCat;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //Destroy BongoCat
            Destroy(BongoCat);
            Destroy(gameObject);
        }
    }
}
