using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIScore : MonoBehaviour
{
    public TMP_Text scoretext;
    public ScoreManager scoreManager;

    private void Update()
    {
        scoretext.text = scoreManager.score.ToString();
    }

}
