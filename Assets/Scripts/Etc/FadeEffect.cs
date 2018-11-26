using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class FadeEffect : MonoBehaviour {

    public Animator anim;

    public int NextLevel;

    public void FadeOut(int num) {
        Time.timeScale = 1;
        anim.SetTrigger("Fade");
        NextLevel = num;
    }
    public void FadeOut()
    {
        Time.timeScale = 1;
        anim.SetTrigger("Fade");
        NextLevel = Application.loadedLevel;
    }

    public void OnAnimComplete() {
        Time.timeScale = 1;
        SceneManager.LoadScene(NextLevel);
    }

}
