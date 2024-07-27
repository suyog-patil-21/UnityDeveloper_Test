using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    
    [SerializeField]
    float thresholdValue = 18f;

    [SerializeField]
    Vector3 characterInitalPosition;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(transform.position.x > thresholdValue || transform.position.x < (thresholdValue * -1)||
                transform.position.y > thresholdValue || transform.position.y < (thresholdValue * -1 )||
                transform.position.z > thresholdValue || transform.position.z < (thresholdValue * -1)  ){
            Debug.Log("Player Out of the Region");
            transform.position = characterInitalPosition;
        }
        
    }
}
