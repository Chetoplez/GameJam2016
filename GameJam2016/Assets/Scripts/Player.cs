using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour {

    public Rigidbody2D PlayerRigidbody;
    [Range(1, 10)]
    public float WalkSpeed = 1f;
    [Range(1, 10)]
    public float JumpSpeed = 1f;
    [Range(0f,1.0f)]
    public float FallSpeedFactor = 0.5F;

    private bool mCanJump;


    private Vector3 mJumpVector=Vector3.zero;

	void Start () {
        mJumpVector.y = JumpSpeed;

	}
	
	
	void Update () {
	
	}


    /// <summary>
    /// Add force to our player
    /// </summary>
    private void AddForce(Vector3 force) {
        this.PlayerRigidbody.AddForce(force * FallSpeedFactor, ForceMode2D.Impulse);
    }

    /// <summary>
    /// The player jumps!
    /// </summary>
    public void Jump() {
        AddForce(mJumpVector);
    }

    /// <summary>
    /// Move the player!
    /// </summary>
    public void Move(Vector3 move) {
        AddForce(move);
    }


}
