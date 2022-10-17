using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class GameController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public GameObject sunObject;
    public Camera mainCamera;
    public GameObject SpawnParent;
    
    public GameObject postProcessingObject;
    public bool nightTime = false;

    private int score = 0;
    private Light sun;
    private Volume ppVolume;
    
    private float time = 0f;
    private float dayLength = 5f;
    private float nightLength = 5f;
    
    private void Start()
    {
        sun = sunObject.GetComponent<Light>();
        ppVolume = postProcessingObject.GetComponent<Volume>();
    }
    
    private void Update()
    {
        if (time > dayLength && !nightTime)
        {
            nightTime = true;
            nightTransition();
        }
        else if (time > dayLength + nightLength)
        {
            nightTime = false;
            dayTransition();
            time = 0f;
        }
        else
        {
            time += Time.deltaTime;
            Quaternion sunRotation = Quaternion.Euler(360 * (time / (dayLength + nightLength)), 0, 0);
            // sunObject.transform.(Vector3.left * (360f / dayLength + nightLength));
            sunObject.transform.rotation = sunRotation;
        }

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
        Debug.Log("It's nighttime!");
        sun.color = Color.red;
        mainCamera.backgroundColor = new Color(0.007f, 0.1f, 0.16f);
        ppVolume.weight = 1f;

        while (SpawnParent.transform.childCount > 0) {
            DestroyImmediate(SpawnParent.transform.GetChild(0).gameObject);
        }
    }
    
    private void dayTransition()
    {
        Debug.Log("It's daytime!");
        sun.color = new Color(1, 0.9568627f, 0.8392157f);
        mainCamera.backgroundColor = new Color(0.1058824f, 0.5832241f, 0.8980392f);
        // ppVolume.GetComponent<Volume>().weight = 0f;
    }
}
