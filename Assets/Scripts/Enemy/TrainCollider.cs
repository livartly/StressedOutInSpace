using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainCollider : MonoBehaviour {

    public GameObject player;

    void OnCollisionEnter(Collision coll)
    {
        if (PlayerManager.player.GetHealth() >= 0 || !PlayerManager.player.GetLost())
        {
            if (coll.gameObject.tag == "Player")
            {
                player.transform.parent = gameObject.transform;
            }
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        player.transform.parent = null;
    }
}
