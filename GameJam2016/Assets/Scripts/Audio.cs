using UnityEngine;
using System.Collections;
using FMOD.Studio;
using FMODUnity;

public class Audio : MonoBehaviour {

    FMOD.Studio.EventInstance ambient;
    FMOD.Studio.ParameterInstance tubarbells;
    FMOD.Studio.ParameterInstance heartBeat;

    FMOD.Studio.EventInstance buttonClick;

    public GameController gameController;
    public bool StartAmbient = true;

    // Use this for initialization
    void Start () {
        ///*Implementazione di Fmod*/
        var studioSystem = FMODUnity.RuntimeManager.StudioSystem;
        ambient = FMODUnity.RuntimeManager.CreateInstance("event:/Ambiente/Vento");
        buttonClick = FMODUnity.RuntimeManager.CreateInstance("event:/Menu/Pulsante");
       
        if(StartAmbient)
            ambient.start();

        if (gameController == null && StartAmbient) {
            gameController = FindObjectOfType<GameController>();
        }
    }

    // Update is called once per frame
    void Update () {
        if (StartAmbient)
        {
            ambient.getParameter("TubaBells", out tubarbells);
            if (gameController.mCurrentSequence.Count >= 3)
            {
                tubarbells.setValue(0.5f);
            }
            else
            {
                tubarbells.setValue(0f);
            }
        }
   	}


    public void ButtonClick() {
        buttonClick.start();
    }
}
