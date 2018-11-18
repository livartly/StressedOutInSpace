using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MugObject : MonoBehaviour {

    //object declaration
    PickupObject mug = new PickupObject("Mug", "positive");

    public AnxietyBarScript anxietyLvl;

    void OnTriggerEnter(Collider coll)
    {
        //if Player
        if (coll.tag == "Player")
        {
            //Relieve Anxiety
            anxietyLvl.SubtractAnxitey();
            //Delete
            Destroy(gameObject);
        }
    }

}
