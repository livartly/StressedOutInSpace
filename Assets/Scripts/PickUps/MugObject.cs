using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MugObject : MonoBehaviour {

    //object declaration
    PickupObject mug = new PickupObject("Mug", "positive");

    public AnxietyBarScript anxietyLvl;

    //On collistion
    private void OnCollisionEnter(Collision coll)
    {
        //if Player
        if (coll.gameObject.tag == "Player")
        {
            //Relieve Anxiety
            anxietyLvl.SubtractAnxitey();
            //Delete
            Destroy(gameObject);
        }
    }

}
