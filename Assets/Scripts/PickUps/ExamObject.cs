using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExamObject : MonoBehaviour {

    //object declaration
    PickupObject exam = new PickupObject("Exam", "negative");

    public AnxietyBarScript anxietyLvl;

    //on collition
    void OnTriggerEnter(Collider coll)
    {
        //if Player
        if (coll.tag == "Player")
        {
            //Add Anxiety level
            anxietyLvl.AddAnxitey();

            //Delete exam
            Destroy(gameObject);
        }
    }
}
