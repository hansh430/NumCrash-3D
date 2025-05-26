using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    private int currentScore = 0;
    private void Awake()
    {
        Instance = this;
    }
    public void UpdateScore(int score)
    {
        currentScore += score;
        EventHandler.OnScoreChange(currentScore);
    }
}
