using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerScore : MonoBehaviour
{
    public float score;
    public Collider bola;
    public ScoreManager scoreManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other == bola)
        {
            // Add to the score
            scoreManager.AddScore(score);
        }
    }
}
