using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{

    public Rigidbody2D PlayerRigidbody;
    public BoxCollider2D PlayerCollider;
    [Range(1, 10)]
    public float WalkSpeed = 1f;
    [Range(1, 50)]
    public float JumpSpeed = 1f;
    [Range(0f, 1.0f)]
    public float FallSpeedFactor = 0.5F;
    [Range(0.25f, 1f)]
    public float JumpDelay = 0.5f;


    /// <summary>
    /// This is our path
    /// </summary>
    public GameObject[] PathPoints;
    public float Threshold = 0.2f;


    private bool mCanJump = true;
    private float mJumpTimer = 0f;

    private bool mIsGrounded = true;
    public bool IsGrounded { get { return mIsGrounded; } }

    private Vector3 mJumpVector = Vector3.zero;
    private Vector3 mStartingPosition;
    private bool mIsFacingRight = true;
    private GameObject[] mInitialPath;

    private bool mIsDead = false;
    public bool IsDead { get { return mIsDead; } }
    private Vector3 mContactNormal = Vector3.zero;
    private Vector3 mInitialScale = Vector3.zero;


    private bool mAnimationDone = false;
    private Vector3 mNextPoint = Vector3.zero;
    private int mNextIndex = 0;
    private float mInitialSpeed = 1f;

    #region StateMachine

    void Start()
    {
        mJumpVector.y = JumpSpeed;
        mJumpTimer = JumpDelay;
        mStartingPosition = this.transform.position;
        mInitialScale = this.transform.localScale;
        Debug.Log("Player: start animation");
        this.PlayerRigidbody.isKinematic = true;
        this.PlayerCollider.enabled = false;
        this.mInitialPath = PathPoints;
    }


    void FixedUpdate()
    {
        if (!mCanJump)
        {
            if (mJumpTimer >= 0)
                mJumpTimer -= Time.deltaTime;
            else
                mCanJump = true;
        }

        if (!mAnimationDone && PathPoints.Length>0)
        {
            float step = mInitialSpeed * Time.deltaTime;
            this.transform.Translate(Time.deltaTime * (PathPoints[mNextIndex].transform.position - transform.position));
            if (Vector3.Distance(transform.position, PathPoints[mNextIndex].transform.position) < Threshold)
                NextPoint();
        }

    }



    void OnCollisionStay2D(Collision2D collision)
    {
        if (Keys.IsFloor(collision.gameObject) || Keys.IsRock(collision.gameObject))
            mIsGrounded = true;

        if (Keys.IsFloor(collision.gameObject))
        {
            if (collision.contacts[0].normal.magnitude < 1)
            {
                mContactNormal.x = collision.contacts[0].normal.x;
                mContactNormal.y = collision.contacts[0].normal.y;

                float angle = Vector3.Dot((mIsFacingRight) ? this.transform.right : -this.transform.right, mContactNormal);
                angle = ((mIsFacingRight) ? -angle : angle);

                Quaternion rotation = Quaternion.AngleAxis(angle * 25, Vector3.forward);
                this.transform.rotation = rotation;

            }
            else
            {
                Quaternion rotation = Quaternion.AngleAxis(0f, Vector3.forward);
                this.transform.rotation = rotation;
            }
        }

    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (Keys.IsFloor(collision.gameObject) || Keys.IsRock(collision.gameObject))
            mIsGrounded = false;
    }


    #endregion

    /// <summary>
    /// Add force to our player
    /// </summary>
    private void AddForce(Vector3 force)
    {
        this.PlayerRigidbody.AddForce(force * FallSpeedFactor, ForceMode2D.Impulse);
    }

    /// <summary>
    /// The player jumps!
    /// </summary>
    public void Jump()
    {
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
    public void Move(Vector3 move, bool left = true)
    {
        //If dead, do not anything!
        if (mIsDead || !mAnimationDone)
            return;

        mIsFacingRight = this.transform.localScale.x > 0;
        if ((mIsFacingRight && left) || (!left && !mIsFacingRight))
            Flip();

        AddForce(move);
    }

    /// <summary>
    /// Flip the character due to our direction
    /// </summary>
    private void Flip()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }


    /// <summary>
    /// Reset all our status
    /// </summary>
    public void Reset()
    {
        this.transform.position = mStartingPosition;
        this.mIsDead = false;
        this.transform.localScale = mInitialScale;
        this.mNextIndex = 0;
        this.mAnimationDone = false;
        this.PlayerRigidbody.isKinematic = true;
        this.PlayerCollider.enabled = false;
        PathPoints= mInitialPath;
    }

    /// <summary>
    /// Die player, die!
    /// </summary>
    public void Die()
    {
        this.mIsDead = true;
        GameController gc = FindObjectOfType<GameController>();
        if (gc != null)
        {
            gc.PlayerDie();
        }

    }

    /// <summary>
    /// Change the scale of our player
    /// </summary>
    /// <param name="newscale"></param>
    public void ChangeScale(float newscale)
    {
        Vector3 newVectorScale = Vector3.zero;
        newVectorScale.z = this.mInitialScale.z;
        newVectorScale.x = this.mInitialScale.x * newscale;
        newVectorScale.y = this.mInitialScale.y * newscale;
        this.transform.localScale = newVectorScale;

    }


    /// <summary>
    /// Calculate the next point of the path
    /// </summary>
    public void NextPoint()
    {
        mNextIndex++;

        if (mNextIndex == 3 || mNextIndex == 6)
            Flip();

        if (mNextIndex >= (PathPoints.Length - 1))
        {
            mAnimationDone = true;
            this.PlayerRigidbody.isKinematic = false;
            this.PlayerCollider.enabled = true;
            Debug.Log("Animation done! Now you can walk!");
        }
    }

    /// <summary>
    /// Assign a new path to follow to the player
    /// </summary>
    /// <param name="path"></param>
    public void AssignPath(GameObject[] path) {
        this.PathPoints = path;
        mNextIndex = 0;
        mAnimationDone = false;
    }


}
