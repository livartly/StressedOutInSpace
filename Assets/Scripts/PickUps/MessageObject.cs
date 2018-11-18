using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageObject : MonoBehaviour {

    //Object declaration
    PickupObject message = new PickupObject("Message", "negitive");

    public AnxietyBarScript anxietyLvl;
    public ShowMessageScript textMessage;
    //on collition
    void OnTriggerEnter(Collider coll)
    {
        //if Player
        if (coll.tag == "Player")
        {
            //Add Anxiety level
            anxietyLvl.AddAnxitey();

            //Show Text Message
            textMessage.ShowMessage();

            //Delete player
            Destroy(gameObject);
        }
    }
}
