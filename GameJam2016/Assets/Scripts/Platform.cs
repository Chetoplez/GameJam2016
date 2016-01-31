using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour {

    public bool IsRandomic = false; //We can choose that this platform is always active or is activated randomly
    public bool destroyPlatform;
    private Vector3 mStartPosition;
    public bool isDestroyable = false;
    public bool isSpawnable = true;

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
        Spawn(true);
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        //TO DO Animation
        if ((Keys.IsPlayer(other.gameObject) && destroyPlatform) || Keys.IsPlayer(other.gameObject) && isDestroyable)
        {
            gameObject.SetActive(false); 
        }

    }

    public void Spawn(bool s) {
        this.gameObject.SetActive(s);
    }

}
