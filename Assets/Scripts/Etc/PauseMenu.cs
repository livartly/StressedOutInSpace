using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    public bool isPaused = false;
    public GameObject pausedUIPanel;

    public FadeEffect fadeEffect;

    void Awake()
    {
        pausedUIPanel.SetActive(false);
    }

    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            isPaused = !isPaused;
            if (isPaused)
                Resume();
            else
                Pause();
        }
	}

    public void Resume() {
        pausedUIPanel.SetActive(false);
        Time.timeScale = 1;
    }

    void Pause() {
        pausedUIPanel.SetActive(true);
        Time.timeScale = 0;       
    }
      
    public void Restart(int num)
    {
        fadeEffect.FadeOut(num);
    }

    public void Restart()
    {
        fadeEffect.FadeOut();
    }

    public void Quit() {
        Application.Quit();
    }
}
