using UnityEngine;
using System.Collections;

public class CameraBound : MonoBehaviour {

    private SimpleCameraFollow smf;


    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("MainCamera"))
        {
            Debug.Log("Camera collided with walll");
            if(smf==null)
             smf= other.GetComponent<SimpleCameraFollow>();
            
            smf.WallX = this.transform.position.x;
            smf.WallContact = true;
        }
    }


  

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("MainCamera"))
        {
            Debug.Log("See you camera");
            if (smf == null)
                smf = other.GetComponent<SimpleCameraFollow>();

            smf.WallContact = false;
        }
    }
    
}
