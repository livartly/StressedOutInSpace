using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ShowMessageScript : MonoBehaviour {

    public Sprite[] sprites;
    public float displayTime;

    private Image image;
    private float timer;
    private bool show = false;
    private int indexOfSprite = -1;

    void Start()
    {
        image = GetComponent<Image>();
        image.enabled = false;
    }

    void Update()
    {
        if (timer >= 0)
        {
            timer -= Time.deltaTime;
        }
        else
            image.enabled = false;

        if (show && timer >= 0) {
            image.enabled = true;
            image.sprite = sprites[indexOfSprite];
            show = false;
        }
    }

    public void ShowMessage() {
        print("Text Message");
        timer = displayTime;
        indexOfSprite = Random.Range(0, sprites.Length-1);
        show = true;
    }
}
