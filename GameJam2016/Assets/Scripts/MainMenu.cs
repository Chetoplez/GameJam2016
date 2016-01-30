using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public  Audio AudioManager;

    public void Play() {
        SceneManager.LoadScene(1);
        AudioManager.ButtonClick();
    }

    public void Exit() {
        Application.Quit();
    }
}

