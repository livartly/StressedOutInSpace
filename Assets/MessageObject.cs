using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageObject : MonoBehaviour {

    //Object declaration
    PickupObject message = new PickupObject("Message", "negitive");

    //on collition
    private void OnCollisionEnter(Collision coll)
    {
        //if Player
        if (coll.gameObject.tag == "Player")
        {
            //Print out object info
            print(message.GetName() + '\n' + message.GetType());
            //Delete player
            Destroy(gameObject);
        }
    }
}
