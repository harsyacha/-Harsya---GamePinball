using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private void Start()    
    {
        ResetScore();
    }
    public float score;

    // Adds to the score
    public void AddScore(float addition)
    {
        score += addition;
    }

    // Resets the score to 0
    public void ResetScore()
    {
        score = 0;
    }
}
