using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        int score = PlayerPrefs.GetInt("Score", 0);
        scoreText.text = "Your score was: " + score.ToString();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
