using UnityEngine;
using System.Collections;

public class Rock : MonoBehaviour {

    /// <summary>
    /// The rock will be instatiated in this position
    /// </summary>
    public Vector3 LaunchPosition;
    /// <summary>
    /// This is the launch direction
    /// </summary>
    public Vector3 LaunchDirection;
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
        RockObject.transform.position = LaunchPosition;
        RockObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider other) {
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
        rigidbody.AddForce( (LaunchDirection - LaunchPosition) * Magnitude, ForceMode2D.Impulse);
    }

}
