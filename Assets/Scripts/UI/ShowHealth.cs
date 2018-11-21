using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ShowHealth : MonoBehaviour {

    public Image[] Hearts;

	void Update () {
        for (int i = PlayerManager.player.GetHealth(); i < Hearts.Length; i++)
        {
            Hearts[i].enabled = false;
        }
	}
}
