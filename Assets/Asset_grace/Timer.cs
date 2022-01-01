﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 90;
    public bool timerIsRunning = false;

    //TextMeshPro timeText;
    public Text timeText;
    
    
    // Update is called once per frame
    void Start()
    {
        //timeText = GetComponent<TextMeshPro>();
        timerIsRunning = true;
    }
    void Update()
    {
        if(timerIsRunning)
        {
            if(timeRemaining>0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }

            else
            {
                Debug.Log("Time's up");
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }   
    }

    void  DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeRemaining / 60);
        float seconds = Mathf.FloorToInt(timeRemaining % 60);

        //timeText.SetText("The first number is {0} and the 2nd is {1:2} and the 3rd is {3:0}.", 4, 6.345f, 3.5f);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
