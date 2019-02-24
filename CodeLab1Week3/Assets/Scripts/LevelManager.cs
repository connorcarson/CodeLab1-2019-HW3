using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    //public TextMeshProUGUI scoreText;

    public float timeLeft = 30;
    private int wholeTime;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LevelTimer();
        //ScoreDisplay();
    }
    
    void LevelTimer()
    {
        timeLeft -= Time.deltaTime; //Countdown one second, every second
        wholeTime = (int) timeLeft; //Convert float to int, round time in seconds up to whole number
        timerText.text = "" + wholeTime; //display Time
    }
    
    /*void ScoreDisplay()
    {
        scoreText.text = "Score: " + GameManager.instance.Score;
    }*/
}
