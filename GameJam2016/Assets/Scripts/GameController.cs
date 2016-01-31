using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

   public enum sequence {
        first=0,
        second=1,
        third=2,
        fourth=3
    }


    public sequence[] sequenceCorrect;
    public ArrayList mCurrentSequence;
    public sequence currentState;
    public bool isCorrect = true;
    private int mHowManyChanges;
    public HandlePlatform clouds;
    public HandlePlatform branches;
    public Player MainPlayer;
  

    private bool mResetInput = false;
    private float mResetTimer = 0f;
    private float mResetTimerValue = 2f;


    //Istanziare Audio

    // Use this for initialization
    void Start () {
        mCurrentSequence = new ArrayList();
        mHowManyChanges = 0;
        sequenceCorrect = new sequence[] { sequence.first, sequence.second, sequence.third, sequence.fourth };
        isCorrect = true;
        if (clouds == null) {
            Debug.LogError("Clouds is null in GameController");
        }

        if (branches == null) {
            Debug.LogError("Branches is null in GameController");
        }

     	}

    void Update() {
        if (mResetInput)
        {
            if (mResetTimer >= 0)
                mResetTimer -= Time.deltaTime;
            else
            {
                mResetInput = false;
                Reset();
            }
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
        Debug.Log("UpdateSequence, sequenceCorrect.lenght is: " + sequenceCorrect.Length);
        if (mHowManyChanges < (sequenceCorrect.Length - 1))
        {
            mHowManyChanges++;
        }

        if (newState.Equals(sequenceCorrect[mHowManyChanges]))
        { //the sequence is correct
            mCurrentSequence.Add(newState);
            MainPlayer.objectPlayer[mHowManyChanges - 1].SetActive(false);
            currentState = newState;
            isCorrect = true;
            Debug.Log("UpdateSequence new state is the state correct");
        }
        else {
            // The sequence is incorrect
            currentState = newState;
            string tag = GetCorrespondingTag(newState);
            if (tag == Keys.TAG_STATE_SECOND || tag == Keys.TAG_STATE_FOURTH) //Scene with platform
            {
                Debug.Log("UpdateSequence the sequence is incorrect");
                GameObject gameObject = GameObject.FindGameObjectWithTag(tag);
                HandlePlatform hp = gameObject.GetComponent<HandlePlatform>();
                hp.DestroyPlatformOnCollision(true);
                hp.spawnObject(false);
                isCorrect = false;
            }
            else { //Other scene?
                Debug.Log("Forse dobbiamo attivare altri eventi");
            }
        }
    }

    public void PlayerDie() {
        mResetInput = true;
        mResetTimer = mResetTimerValue;
   
        //Reset();
    }


    public void Reset()
    {
        mHowManyChanges = 0;
        clouds.Reset();
        branches.Reset();
        MainPlayer.Reset();
        isCorrect = true;
    }

    

}
