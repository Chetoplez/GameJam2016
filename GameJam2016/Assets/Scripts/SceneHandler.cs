using UnityEngine;
using System.Collections;

public class SceneHandler : MonoBehaviour {

    public GameObject[] Masks;
    public GameController MainGameController;

    private Color mColor = new Color(0,0,0);

    void Start() {
        mColor.a = 0.5f;
    }

	void Update () {
       
        if (MainGameController.currentState == GameController.sequence.first)
        {
            Masks[0].SetActive(false);
            Masks[1].SetActive(true);
            Masks[2].SetActive(true);
            Masks[3].SetActive(true);
        }

        if (MainGameController.currentState == GameController.sequence.second)
        {
            Masks[0].SetActive(true);
            Masks[1].SetActive(false);
            Masks[2].SetActive(true);
            Masks[3].SetActive(true);
        }

        if (MainGameController.currentState == GameController.sequence.third)
        {
            Masks[0].SetActive(true);
            Masks[1].SetActive(true);
            Masks[2].SetActive(false);
            Masks[3].SetActive(true);
        }


        if (MainGameController.currentState == GameController.sequence.fourth)
        {
            Masks[0].SetActive(true);
            Masks[1].SetActive(true);
            Masks[2].SetActive(true);
            Masks[3].SetActive(false);
        }

	}
}
