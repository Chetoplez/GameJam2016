using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

   public enum sequence {
        first,
        second,
        third,
        fourth
    }


    public sequence[] sequenceCorrect;
    private ArrayList mCurrentSequence;
    public sequence currentState;
    private int mHowManyChanges;
    public HandlePlatform clouds;
    public HandlePlatform branches;


    //Istanziare Audio

    // Use this for initialization
    void Start () {
        mHowManyChanges = 0;
        if (clouds == null) {
            Debug.LogError("Clouds is null in GameController");
        }

        if (branches == null) {
            Debug.LogError("Branches is null in GameController");
        }
	}
	
    string GetCorrespondingTag(sequence state) {
        string tag = null;
        switch (state) {
            case sequence.first: {
                    tag = Keys.TAG_STATE_FIRST;
                    break;
                }
            case sequence.second:
                {
                    tag = Keys.TAG_STATE_SECOND;
                    break;
                }
            case sequence.third:
                {
                    tag = Keys.TAG_STATE_THIRD;
                    break;
                }
            case sequence.fourth:
                {
                    tag = Keys.TAG_STATE_FOURTH;
                    break;
                }

        }
        return tag;
    }

    public void UpdateSequence(sequence newState) {
        if(mHowManyChanges < (sequenceCorrect.Length - 1))
        mHowManyChanges++;

        if (newState == sequenceCorrect[mHowManyChanges])
        { //the sequence is correct
            mCurrentSequence.Add(newState);
        }
        else {
            // The sequence is incorrect
            string tag = GetCorrespondingTag(newState);
            if (tag == Keys.TAG_STATE_SECOND || tag == Keys.TAG_STATE_THIRD) //Scene with platform
            {
                GameObject gameObject = GameObject.FindGameObjectWithTag(tag);
                HandlePlatform hp = gameObject.GetComponent<HandlePlatform>();
                hp.DestroyPlatformOnCollision(true);
            }
            else { //Other scene?
                Debug.Log("Forse dobbiamo attivare altri eventi");
            }
        }
    }

    public void PlayerDie() {
        //Verifica che si devo fare altre cose...
        Reset();
    }


    public void Reset()
    {
        mHowManyChanges = 0;
        clouds.Reset();
        branches.Reset();
    }

}
