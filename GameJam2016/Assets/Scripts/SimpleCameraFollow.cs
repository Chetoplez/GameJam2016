using UnityEngine;
using System.Collections;

public class SimpleCameraFollow : MonoBehaviour {

    public Player MainPlayer;
    [Range(0.1f,10f)]
    public float CameraSpeed = 1f;

    private Vector3 mDesiredPosition = Vector3.zero;
    private float mStartingZ = 0f;

	void Start () {
        if (MainPlayer == null)
            Debug.LogError("Main Camera : please attach the player");
        mStartingZ = this.transform.position.z;
    }
	
	
	void FixedUpdate () {

        mDesiredPosition = MainPlayer.transform.position;
        mDesiredPosition.z = mStartingZ;
        this.transform.position = mDesiredPosition;
	}
}
