using UnityEngine;
using System.Collections;

public class ScaleTrigger : MonoBehaviour {

    public bool GrowingFromPoint = false;
    public float ScaleFactor = 0.5f;
    public Transform ReferencePoint;
    public Transform EndPoint;

    private float mMaxDistance = 0f;
    private Vector3 mNewScale = Vector3.zero;
    private Player mPlayer = null;

    void Start() {
        mMaxDistance = Vector3.Distance(ReferencePoint.position , EndPoint.position);
    }


    void OnTriggerStay2D(Collider2D other) {
        if (Keys.IsPlayer(other.gameObject))
        {
            float playerDistance = Vector3.Distance(other.gameObject.transform.position ,ReferencePoint.position);
            float scaleFactor = playerDistance / mMaxDistance;
            scaleFactor = 1 - scaleFactor;
            scaleFactor = Mathf.Clamp(scaleFactor, ScaleFactor, 1f);
            
            if(mPlayer==null)
                mPlayer= other.gameObject.GetComponent<Player>();
            
            mPlayer.ChangeScale(scaleFactor);
        }
    }





}
