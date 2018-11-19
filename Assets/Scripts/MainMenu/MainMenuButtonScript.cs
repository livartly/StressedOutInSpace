using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine;

public class MainMenuButtonScript : MonoBehaviour {

    private AudioSource source;
    public AudioClip mouseOver, onClicked;
    public AudioMixer mixer;

    public void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void Play() {
        SceneManager.LoadScene("GameScene");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void SetVolume(float val) {
        mixer.SetFloat("Volume", val);
        Debug.Log(val);
    }

    public void MouseOverSound() {
        source.PlayOneShot(mouseOver, 0.3f);
    }

    public void OnClickedSound() {
        source.PlayOneShot(onClicked, 0.5f);
    }

    public void Quit() {
        Application.Quit();
    }
}
