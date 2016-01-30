using UnityEngine;
using System.Collections;

public class SimpleCameraFollow : MonoBehaviour {

    public Player MainPlayer;
    [Range(0.1f,10f)]
    public float CameraSpeed = 1f;
    
    public SpriteRenderer DeathBackground;
    public float BackgroundAlphaFactor = 0.1f;


    private Vector3 mDesiredPosition = Vector3.zero;
    private float mStartingZ = 0f;
    private Color mBackgroundColor = new Color(255,255,255);



	void Start () {
        if (MainPlayer == null)
            Debug.LogError("Main Camera : please attach the player");
        if (DeathBackground == null)
            Debug.LogError("Main camera: please attach the black background");
        
        mStartingZ = this.transform.position.z;
        mBackgroundColor.a = 0f;
    }
	
	
	void FixedUpdate () {
        mDesiredPosition = MainPlayer.transform.position;
        mDesiredPosition.z = mStartingZ;
        this.transform.position = mDesiredPosition;

        ChangeDeathColor();

	}

    void ChangeDeathColor() {

        if (MainPlayer.IsDead)
            mBackgroundColor.a += (mBackgroundColor.a < 1f) ? Time.deltaTime * BackgroundAlphaFactor : 0f;
        else
            mBackgroundColor.a -= (mBackgroundColor.a > 0f) ? Time.deltaTime * BackgroundAlphaFactor : 0f;

        DeathBackground.color = mBackgroundColor;
    }

}
