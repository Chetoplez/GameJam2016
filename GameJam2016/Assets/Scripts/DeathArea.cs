using UnityEngine;
using System.Collections;

public class DeathArea : MonoBehaviour {

    public Player MainPlayer;
    public GameController MainGameController;

	// Use this for initialization
	void Start () {
        if (MainPlayer == null) {
            MainPlayer = FindObjectOfType<Player>();
        }
        if (MainGameController == null) {
            MainGameController = FindObjectOfType<GameController>();
        }
	}
	

    void OnTriggerEnter2D(Collider2D other) {
        if (Keys.IsPlayer(other.gameObject) && !MainGameController.isCorrect) {
            MainPlayer.Die(); //Muoriiiiiiiiiiiiiiiiiiiiiiiiiiiiiir
        }
    }

}
