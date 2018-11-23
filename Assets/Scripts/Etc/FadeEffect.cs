using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class FadeEffect : MonoBehaviour {

    public Animator anim;

    public int NextLevel;

    public void FadeOut(int num) {
        anim.SetTrigger("Fade");
        NextLevel = num;
    }

    public void OnAnimComplete() {
        SceneManager.LoadScene(NextLevel);
    }

}
