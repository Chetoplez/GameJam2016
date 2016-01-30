using UnityEngine;
using System.Collections;

public class HandlePlatform : MonoBehaviour {

    private Platform[] mAllPlatform;
    private ArrayList mIsRandomicPlatform = new ArrayList();
    private int mMax = 100;
    private int mMin = 1;
    public bool randomicPlatform;


	// Use this for initialization
	void Start () {
        randomicPlatform = true;
        mAllPlatform = gameObject.GetComponentsInChildren<Platform>();
        if(mAllPlatform.Length == 0) { Debug.LogError("Error in platform handler, there aren't platform."); }
        for (int i = 0; i < mAllPlatform.Length; i++) {
            if (mAllPlatform[i].IsRandomic) {
                mIsRandomicPlatform.Add(mAllPlatform[i]);
            }
        }

      
    }

    public void ChooseRandomicPlatform() {
        for (int i = 0; i < mIsRandomicPlatform.Count; i++) {
            int random = Random.Range(mMin, mMax);
            int rest = random % (i + 1);
            Debug.Log("Random is: " + random + " rest is: " + rest);
            if (rest == 1) {
                Platform p = mIsRandomicPlatform[i] as Platform;
                p.gameObject.SetActive(true);
            }
        }     
    }

    void Update() {
        if(randomicPlatform &&!(mIsRandomicPlatform.Count == 0))
            {
                ChooseRandomicPlatform();
                randomicPlatform = false;
            }
    }

    public void Reset() {
        for (int i = 0; i < mAllPlatform.Length; i++) {
            Platform p = mAllPlatform[i] as Platform;
            p.Reset();
        }
        randomicPlatform = true;
    }

    public void DestroyPlatformOnCollision(bool destroy) {
        for (int i = 0; i < mAllPlatform.Length; i++) {
            mAllPlatform[i].destroyPlatform = destroy;
        }
    }


}
