using UnityEngine;
using System.Collections;

public class SimpleCameraFollow : MonoBehaviour {

    public Player MainPlayer;
    [Range(0.1f,10f)]
    public float CameraSpeed = 1f;
    
    public SpriteRenderer DeathBackground;
    public float BackgroundAlphaFactor = 0.1f;
    public float TransitionSeconds = 1f;

    

    private Vector3 mDesiredPosition = Vector3.zero;
    private float mStartingZ = 0f;
    private Color mBackgroundColor = new Color(255,255,255);


    private bool mTransitionActivate = false;
    private bool mTransitionEnd = false;
    private float mTransitionTimer = 0f;
    private bool mReverse = false;

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

        //ChangeDeathColor();

        if (mTransitionActivate)
        {
            if (!mTransitionEnd)
            {
                if (!mReverse)
                {

                    mBackgroundColor.a += Time.deltaTime * BackgroundAlphaFactor;
                    if (mBackgroundColor.a >= 0.95f)
                        mReverse = true;
                }
                else
                {
                    mBackgroundColor.a -= Time.deltaTime * BackgroundAlphaFactor;
                    if (mBackgroundColor.a <= 0.05f)
                        mTransitionEnd = true;
                }
            }
            else
                mTransitionActivate = false;

            DeathBackground.color = mBackgroundColor;
        }
        else
            ChangeDeathColor();

	}

    void ChangeDeathColor() {

        if (MainPlayer.IsDead)
            mBackgroundColor.a += (mBackgroundColor.a < 1f) ? Time.deltaTime * BackgroundAlphaFactor : 0f;
        else
            mBackgroundColor.a -= (mBackgroundColor.a > 0f) ? Time.deltaTime * BackgroundAlphaFactor : 0f;

        DeathBackground.color = mBackgroundColor;
    }


    public void ActivateTransition() {
        if (mTransitionActivate) return;
        Debug.Log("Transition Activated");
        mTransitionActivate = true;
        mReverse = false;
        mTransitionEnd = false;
    }


}
