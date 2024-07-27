using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerCounterScript : MonoBehaviour
{
    
    [SerializeField]
    float timeRemaining = 120;

    [SerializeField]
    TextMeshProUGUI timerText;

    [SerializeField]
    GameOverScript gameOverScript;

    void Update()
    {
        if(timeRemaining > 0) {
            timeRemaining -= Time.deltaTime;
        }else if(timeRemaining < 0 )
        {
            timeRemaining = 0;
            timerText.color = Color.red;
            gameOverScript.gameOver();
        }
         float minutes = Mathf.FloorToInt(timeRemaining / 60);
         float seconds = Mathf.FloorToInt(timeRemaining % 60);
         timerText.text = string.Format("{0:00} : {1:00}",minutes,seconds);
    }

}
