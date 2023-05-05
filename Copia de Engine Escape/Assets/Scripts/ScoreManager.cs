using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int currentScore;
    
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void AddPoints(int points)
    {
        currentScore += points;
    }

    public void SubtractPoints(int points)
    {
        currentScore -= points;
    }


    public int GetScore()
    {
        return currentScore;
    }

}
