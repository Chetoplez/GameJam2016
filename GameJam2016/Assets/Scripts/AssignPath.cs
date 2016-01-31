using UnityEngine;
using System.Collections;

public class AssignPath : MonoBehaviour {

    public GameObject[] PathPoints;
    public bool TransitionDuringPath = false;
    public SimpleCameraFollow MainCamera;


    private bool mPlayerPassed = false;
    private Player MainPlayer = null;

    void Start() {
        if (MainCamera == null)
            Debug.LogError("AssignPath: MainCamera is not assigned!" + this.gameObject.name);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (Keys.IsPlayer(other.gameObject) && !mPlayerPassed)
        {
            if(MainPlayer==null)
                MainPlayer= other.gameObject.GetComponent<Player>();
            if (TransitionDuringPath)
                MainCamera.ActivateTransition();

            MainPlayer.AssignPath(PathPoints);
            mPlayerPassed = true;
        }
    }

    void Reset() {
        mPlayerPassed = false;
    }

}
