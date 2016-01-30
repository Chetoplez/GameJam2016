using UnityEngine;
using System.Collections;

public class AssignPath : MonoBehaviour {

    public GameObject[] PathPoints;
    private bool mPlayerPassed = false;
    private Player MainPlayer = null;

    void OnTriggerEnter2D(Collider2D other) {
        if (Keys.IsPlayer(other.gameObject) && !mPlayerPassed)
        {
            if(MainPlayer==null)
                MainPlayer= other.gameObject.GetComponent<Player>();
            
            MainPlayer.AssignPath(PathPoints);
            mPlayerPassed = true;
        }
    }

    void Reset() {
        mPlayerPassed = false;
    }

}
