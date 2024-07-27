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
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(timeRemaining > 0) {
            timeRemaining -= Time.deltaTime;
        }else if(timeRemaining < 0 )
        {
            timeRemaining = 0;
            timerText.color = Color.red;
        }
         float minutes = Mathf.FloorToInt(timeRemaining / 60);
         float seconds = Mathf.FloorToInt(timeRemaining % 60);
         timerText.text = string.Format("{0:00} : {1:00}",minutes,seconds);
    }

}
