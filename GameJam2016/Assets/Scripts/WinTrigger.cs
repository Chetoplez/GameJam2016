using UnityEngine;
using System.Collections;

public class WinTrigger : MonoBehaviour {

    public GameController MainGameController;
    public GameObject FinalImage;

    void OnTriggerEnter2D(Collider2D other) {
        if (Keys.IsPlayer(other.gameObject) && MainGameController.isCorrect)
        {
            FinalImage.SetActive(true);
        }
    }

}
