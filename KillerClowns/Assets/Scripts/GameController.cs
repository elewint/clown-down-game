using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score = 0;
    
    public void incrementScore()
    {
        score++;
        scoreText.text = "Score: " + score.ToString();
    }
}
