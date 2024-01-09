using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score = 0;
    public Int highScore;
    public float timer = 10f;
    public float minTimePerStar = 1.0f;
    public float maxTimePerStar = 2.0f;
    public float minTimeDegradation = 0.05f;
    public float maxTimeDegradation = 0.1f;
    float totalTime = 0.0f;

    public Text[] scoreDisplay;
    public Text[] timerDisplay;
    public GameObject defaultTimer;
    public GameObject lateTimer;

    // AddScore increments the value of score by 1.
    public void AddScore()
    {
        if (timer > 0f)
        { 
            score++;

            // new 
            timer += Random.Range(minTimePerStar, maxTimePerStar);
            
            if (score > highScore.RuntimeValue)
            {
                highScore.RuntimeValue = score;
            }
        }
    }

    void Update()
    {
        
        totalTime += Time.deltaTime;
        
        if (timer > 0.0f)
        {
            timer -= Time.deltaTime;
            
        }
    }
}
