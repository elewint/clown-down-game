using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public GameObject sunObject;
    public Camera mainCamera;

    private int score = 0;
    private Light sun;
    
    private void Start()
    {
        sun = sunObject.GetComponent<Light>();
    }
    
    private void Update()
    {
        // Move the sun
        // Check for nighttime
        // If nighttime, don't move sun
    }
    
    public void incrementScore()
    {
        score++;
        scoreText.text = "Score: " + score.ToString();
    }

    private void nightTransition()
    {
        sun.color = Color.red;
        
    }
}
