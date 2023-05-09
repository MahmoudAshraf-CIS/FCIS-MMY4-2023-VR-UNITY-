using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    public int _currentScore = 0;

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void AddScore(int score)
    {
        _currentScore += score;
    }

    public void RemoveScore(int score)
    {
        _currentScore -= score;
    }
}
