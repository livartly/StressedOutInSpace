using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageObject : MonoBehaviour {

    //Object declaration
    PickupObject message = new PickupObject("Message", "negitive");

    public AnxietyBarScript anxietyLvl;

    //on collition
    private void OnCollisionEnter(Collision coll)
    {
        //if Player
        if (coll.gameObject.tag == "Player")
        {
            //Add Anxiety level
            anxietyLvl.AddAnxitey();
            //Delete player
            Destroy(gameObject);
        }
    }
}
