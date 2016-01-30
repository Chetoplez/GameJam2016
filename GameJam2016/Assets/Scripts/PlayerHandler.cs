using UnityEngine;
using System.Collections;

public class PlayerHandler : MonoBehaviour {

    public Player MainPlayer;

    private Vector3 mLeftVector = new Vector3(-1f,0f,0f);
    private Vector3 mRightVector = new Vector3(1f, 0f, 0f);

	
	void Start () {
	    if(MainPlayer==null)
            Debug.LogError("Player is missing");
	}
	
	
	void Update () {

        if (LeftInput())
            MainPlayer.Move(mLeftVector,true);

        if (RightInput())
            MainPlayer.Move(mRightVector,false);

        if (JumpInput() && MainPlayer.IsGrounded)
            MainPlayer.Jump();
	}


    bool LeftInput() {
        return Input.GetKey(KeyCode.A);
    }

    bool RightInput() {
        return Input.GetKey(KeyCode.D);
    }

    bool JumpInput() {
        return Input.GetKey(KeyCode.Space);
    }


}
