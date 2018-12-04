using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class AnxietyBarScript : MonoBehaviour {

    private Slider anxiety;
    private float value = 1;
    private Image fillColor;

    public Color startColor = Color.green, finishColor = Color.red;
    //2-0

    void Start() {
        anxiety = transform.GetChild(0).GetComponent<Slider>();
        fillColor = transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<Image>();
        anxiety.value = 0;
    }

	void Update () {

        fillColor.color = Color.Lerp(startColor, finishColor, anxiety.value/anxiety.maxValue);

        //Count Seconds
        value += Time.deltaTime;

        //Modules check every 3 seconds add to anxiety level
        if (Mathf.RoundToInt(value) % 3 == 0)
        {
            value = 1;
            anxiety.value += 2;
        }

        //Handel Lost Condition
        if (anxiety.value >= 100)
        {
            //Throw lose screen
            print("You have lost...");
            PlayerManager.player.Lost();
        }
	}

    //Default Add = 35
    public void AddAnxitey() {
        anxiety.value += 35;
    }

    //Overloaded Add Function pass argument for amt of anxitey gained
    public void AddAnxitey(int num)
    {
        anxiety.value += num;
    }

    //Default Subtract = 35
    public void SubtractAnxitey()
    {
        anxiety.value -= 35;
    }

    //Overloaded Sub Function pass argument for amt of anxitey lost
    public void SubtractAnxitey(int num)
    {
        anxiety.value -= num;
    }
}
