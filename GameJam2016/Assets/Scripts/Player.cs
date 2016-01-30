using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour {

    public Rigidbody2D PlayerRigidbody;
    [Range(1, 10)]
    public float WalkSpeed = 1f;
    [Range(1, 25)]
    public float JumpSpeed = 1f;
    [Range(0f,1.0f)]
    public float FallSpeedFactor = 0.5F;
    [Range(0.25f,1f)]
    public float JumpDelay = 0.5f;

    private bool mCanJump=true;
    private float mJumpTimer = 0f;
    
    private bool mIsGrounded = true;
    public bool IsGrounded { get { return mIsGrounded; } }

    private Vector3 mJumpVector=Vector3.zero;
    private Vector3 mStartingPosition;
    private bool mIsFacingRight = true;
    private bool mIsDead = false;


    #region StateMachine

    void Start () {
        mJumpVector.y = JumpSpeed;
        mJumpTimer = JumpDelay;
        mStartingPosition = this.transform.position;
	}
	
	
	void Update () {
        if (!mCanJump)
        {
            if (mJumpTimer >= 0)
                mJumpTimer -= Time.deltaTime;
            else
                mCanJump = true;
        }
	}


    void OnCollisionStay2D(Collision2D collision)
    {
        if (Keys.IsFloor(collision.transform.gameObject))
            mIsGrounded = true;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (Keys.IsFloor(collision.transform.gameObject))
            mIsGrounded = false;
    }


    #endregion

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
        if (mCanJump)
        {
            AddForce(mJumpVector);
            mCanJump = false;
            mJumpTimer = JumpDelay;
        }
    }

    /// <summary>
    /// Move the player!
    /// </summary>
    public void Move(Vector3 move,bool left=true) {
        //If dead, do not anything!
        if (mIsDead) 
            return;

        mIsFacingRight = this.transform.localScale.x > 0;
        if ((mIsFacingRight && left) || (!left && !mIsFacingRight))
            Flip();

        AddForce(move);
    }

    /// <summary>
    /// Flip the character due to our direction
    /// </summary>
    private void Flip() {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }


    /// <summary>
    /// Reset all our status
    /// </summary>
    public void Reset() {
        this.transform.position = mStartingPosition;
        this.mIsDead = false;
    }

    /// <summary>
    /// Die player, die!
    /// </summary>
    public void Die() {
        this.mIsDead = true;
    }



}
