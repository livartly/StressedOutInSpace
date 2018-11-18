using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class WonScript : MonoBehaviour {

    //Player movement reference
    public PlayerMovement player;

    //Timer object
    public float timer;

    //Has won boolean
    private bool hasWon = false;

    //Check of collition
    private void OnCollisionEnter(Collision coll)
    {
        //Check to see if it was the player
        if (coll.gameObject.tag == "Player")
        {
            hasWon = true;
        }
    }

    private void Update()
    {
        if (hasWon)
        {
            //Disable movement script
            player.StopPlayer();

            //Timer for wait to win
            if (timer >= 0)
                timer -= Time.deltaTime;

            if (timer < 0)
            {
                //Change to win screen
                SceneManager.LoadScene("WinScreen");
            }
        }
    }

}
