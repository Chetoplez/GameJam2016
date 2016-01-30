using UnityEngine;
using System.Collections;

public class DeathArea : MonoBehaviour {

    public Player MainPlayer;

	// Use this for initialization
	void Start () {
        if (MainPlayer == null) {
            MainPlayer = FindObjectOfType<Player>();
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other) {
        if (Keys.IsPlayer(other.gameObject)) {
            MainPlayer.Die(); //Muoriiiiiiiiiiiiiiiiiiiiiiiiiiiiiir
        }
    }

}
