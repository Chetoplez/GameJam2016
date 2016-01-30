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
    public GameObject Rock;

    /// <summary>
    /// Magnitude of the rock launch
    /// </summary>
    public float Magnitude = 1.5f;


    private bool mRockLaunched = false;

	void Start () {
        if (Rock == null)
            Debug.LogError("Rock: the rock object is null!");

        if (Rock.GetComponent<Rigidbody2D>() == null)
            Debug.LogError("Rock : the rigidbody attached doesn't have the rigidbody!");
        
        Rock.SetActive(false);
    }
	

    void Reset() {
        mRockLaunched = false;
    }

    void OnTriggerEnter2D(Collider other) {
        if (Keys.IsPlayer(other.gameObject))
        {
            if (!mRockLaunched)
            { }
        }
    }

    void LaunchRock() {
        Rock.SetActive(true);
    }

}
