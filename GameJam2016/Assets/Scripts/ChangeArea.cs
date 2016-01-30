using UnityEngine;
using System.Collections;

public class ChangeArea : MonoBehaviour {

    GameController gameController;
    public GameController.sequence newState;

	// Use this for initialization
	void Start () {
        if (gameController == null) {
            gameController = FindObjectOfType<GameController>();
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other) {
        if (Keys.IsPlayer(other.gameObject)) {
            if (gameController.currentState != newState)
            {
                Debug.Log("Abbiam cambiato stato, new state is: " + newState);
                gameController.UpdateSequence(newState);
            }
            else
            {
                Debug.Log("no stato uguale");
            }
        }
    }
}
