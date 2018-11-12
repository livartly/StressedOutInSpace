using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MugObject : MonoBehaviour {

    //object declaration
    PickupObject mug = new PickupObject("Mug", "positive");

    //On collistion
    private void OnCollisionEnter(Collision coll)
    {
        //if Player
        if (coll.gameObject.tag == "Player")
        {
            //See what type it is
            print(mug.GetName() + '\n' + mug.GetType());
            //Delete
            Destroy(gameObject);
        }
    }

}
