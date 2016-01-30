using UnityEngine;
using System.Collections;
using FMOD.Studio;
using FMODUnity;

public class Audio : MonoBehaviour {

    FMOD.Studio.EventInstance ambient;
    FMOD.Studio.ParameterInstance tubarbells;
    FMOD.Studio.ParameterInstance heartBeat;
    public GameController gameController;

    // Use this for initialization
    void Start () {
        ///*Implementazione di Fmod*/
        var studioSystem = FMODUnity.RuntimeManager.StudioSystem;
        ambient = FMODUnity.RuntimeManager.CreateInstance("event:/Ambiente/Vento");
        ambient.start();
        if (gameController == null) {
            gameController = FindObjectOfType<GameController>();
        }
    }

    // Update is called once per frame
    void Update () {
        if (gameController.mCurrentSequence.Count >= 3)
        {
            tubarbells.setValue(0.5f);
            ambient.getParameter("TubaBells", out heartBeat);
        }
        else {
            tubarbells.setValue(0f);
            ambient.getParameter("TubaBells", out heartBeat);
        }  
   	}
}
