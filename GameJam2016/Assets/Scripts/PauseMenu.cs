using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

    public Button Pause;
    public Button Resume;
    public Button Exit;

    private bool mIsPause;


	// Use this for initialization
	void Start () {
        
        if (Pause == null) {
            Debug.LogError("Button Pause is null");
        }

        if(Resume == null)
        {
            Debug.LogError("Button Resume is null");
        }

        if (Exit == null) {
            Debug.LogError("Button Exit is null");
        }
         ActivateDeactivateButton(false);
	}

    void ActivateDeactivateButton(bool active) {
        Pause.gameObject.SetActive(!active);
        Resume.gameObject.SetActive(active);
        Exit.gameObject.SetActive(active);
    }


    public void ResumeMethod() {
        ActivateDeactivateButton(false);
        Time.timeScale = 1;
    }

    public void PauseMethod() {
        ActivateDeactivateButton(true);
        Time.timeScale = 0;
    }

    public void ExitMethod() {
        Application.Quit();
    }
        
}
