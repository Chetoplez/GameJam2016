using UnityEngine;
using System.Collections;

public class Rock : MonoBehaviour {

    /// <summary>
    /// The rock will be instatiated in this position
    /// </summary>
    public Transform LaunchPosition;
    /// <summary>
    /// This is the launch direction
    /// </summary>
    public Transform LaunchDirection;
    /// <summary>
    /// Rock that will be throwed
    /// </summary>
    public GameObject RockObject;

    /// <summary>
    /// Magnitude of the rock launch
    /// </summary>
    public float Magnitude = 1.5f;


    private bool mRockLaunched = false;

	void Start () {
        if (RockObject == null)
            Debug.LogError("Rock: the rock object is null!");

        if (RockObject.GetComponent<Rigidbody2D>() == null)
            Debug.LogError("Rock : the rigidbody attached doesn't have the rigidbody!");

        RockObject.SetActive(false);
    }
	

    void Reset() {
        mRockLaunched = false;
        RockObject.transform.position = LaunchPosition.position;
        RockObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (Keys.IsPlayer(other.gameObject))
        {
            if (!mRockLaunched)
            {
                LaunchRock();
                mRockLaunched = true;
            }
        }
    }

    void LaunchRock() {
        RockObject.SetActive(true);
        Rigidbody2D rigidbody = RockObject.GetComponent<Rigidbody2D>();
        rigidbody.AddForce( (LaunchDirection.position - LaunchPosition.position) * Magnitude, ForceMode2D.Impulse);
    }

}
