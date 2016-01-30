using UnityEngine;
using System.Collections;

public class FallingRock : MonoBehaviour {

    private bool mIsGrounded=false;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (Keys.IsPlayer(collision.gameObject) && !mIsGrounded)
        {
            Player player = collision.gameObject.GetComponent<Player>();
            player.Die();
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

	
	
}
