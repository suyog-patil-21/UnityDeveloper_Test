using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn: MonoBehaviour
{
    
    [SerializeField]
    float thresholdValue = 18f;

    [SerializeField]
    GameOverScript gameOverScript;

    public bool isOver;

    void FixedUpdate()
    {
        bool outOfRegion = transform.position.x > thresholdValue || transform.position.x < (thresholdValue * -1)||
                transform.position.y > thresholdValue || transform.position.y < (thresholdValue * -1 )||
                transform.position.z > thresholdValue || transform.position.z < (thresholdValue * -1);
        if( outOfRegion && !isOver ){
            isOver = true;
            Debug.Log("Player Out of the Region");
            gameOverScript.gameOver();
        }
        
    }
}
