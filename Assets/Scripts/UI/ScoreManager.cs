using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static float score = 0;
    public TextMeshProUGUI text;
    [Header("事件监听")] 
    public FloatEventSO ScoreIncrease;

    private void OnEnable()
    {
        ScoreIncrease.onEventRaised += scoreIncreaseEvent;
    }

    private void OnDisable()
    {
        ScoreIncrease.onEventRaised -= scoreIncreaseEvent;
    }

    public void scoreIncreaseEvent(float increaseVal)
    {
        score += increaseVal;
        
        text.SetText("Score:" + (int)score);
    }
}
