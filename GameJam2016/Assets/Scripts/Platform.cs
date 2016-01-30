using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour {

    public bool IsRandomic = false; //We can choose that this platform is always active or is activated randomly
    public bool destroyPlatform;
    private Vector3 mStartPosition;


     // Use this for initialization
    void Start () {
        mStartPosition = gameObject.transform.position;
        gameObject.SetActive(!IsRandomic);
        destroyPlatform = false;
    }
	
    public void Reset() {
        destroyPlatform = false;
        gameObject.transform.position = mStartPosition;
        gameObject.SetActive(!IsRandomic);         
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (Keys.IsPlayer(other.gameObject) && destroyPlatform) {
            gameObject.SetActive(false);
        }
    }

}
