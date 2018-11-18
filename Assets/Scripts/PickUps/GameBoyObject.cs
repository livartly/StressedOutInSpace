using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoyObject : MonoBehaviour
{

    //object declaration
    PickupObject gameboy = new PickupObject("Gameboy", "positive");

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
