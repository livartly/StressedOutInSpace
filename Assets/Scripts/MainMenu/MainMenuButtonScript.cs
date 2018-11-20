using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine;

public class MainMenuButtonScript : MonoBehaviour {

    private AudioSource source;

    //Audio sounds for mouse over and on Clicked
    public AudioClip mouseOver, onClicked;

    //The AudioMixer for the game
    public AudioMixer mixer;

    //Resoultion dropdown panel
    public Dropdown resolutionDropDown;

    //Array to store resolutions
    Resolution[] resolutions;

    public void Start()
    {
        //Get the audio source componet
        source = GetComponent<AudioSource>();

        //Get Screen Resolution avalibilites
        resolutions = Screen.resolutions;

        //Clear the drop down list
        resolutionDropDown.ClearOptions();

        //String list of all the avaliable resoultions on the PC
        List<string> avaliableResolutions = new List<string>();

        //index for current size
        int currentIndex = -1;

        for (int i = 0; i < resolutions.Length; i++)
        {
            //Add in the new options
            string newOption = resolutions[i].width + " x " + resolutions[i].height;
            avaliableResolutions.Add(newOption);

            //Check to see what size the users PC is currently running
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
                currentIndex = i;
        }

        //Add avaliable resolutions
        resolutionDropDown.AddOptions(avaliableResolutions);
        //Set Current value ("Size")
        resolutionDropDown.value = currentIndex;
        resolutionDropDown.RefreshShownValue();
    }

    //Play Button Function
    public void Play() {
        SceneManager.LoadScene("GameScene");
    }

    //"Back Button" function
    public void MainMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }

    //Set Main volume Mix
    public void SetMainVolume(float val) {
        mixer.SetFloat("Master", val);
    }
    //SFX volume music
    public void SetSFXVolume(float val)
    {
        mixer.SetFloat("SFX", val);
    }
    //Music Volume
    public void SetMusicVolume(float val)
    {
        mixer.SetFloat("Music", val);
    }

    public void MouseOverSound() {
        source.PlayOneShot(mouseOver, 0.3f);
    }

    public void OnClickedSound() {
        source.PlayOneShot(onClicked, 0.5f);
    }

    //Game Quality: low, (med)<- default, high, ultra
    public void SetGameQuality(int val) {
        QualitySettings.SetQualityLevel(val);
    }

    //Quit Application
    public void Quit() {
        Application.Quit();
    }

    //On Resolution size change
    public void SetResolution(int val) {
        Resolution resolution = resolutions[val];
        //The True is the full screen button if we want to add it 
        Screen.SetResolution(resolution.width, resolution.height, true);
    }
}
