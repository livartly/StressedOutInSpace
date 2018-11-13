using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuButtonScript : MonoBehaviour {

    public void Play() {
        SceneManager.LoadScene("GameScene");
    }

    public void Settings() {
        //
    }

    public void Quit() {
        Application.Quit();
    }
}
