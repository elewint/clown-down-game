using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class GameController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public GameObject nightText;
    public GameObject sunObject;
    public Camera mainCamera;
    public GameObject SpawnParent;
    
    public GameObject postProcessingObject;
    private MouseLook mouseLook;

    private bool nightTime = false;
    private int score = 0;
    private Light sun;
    private Volume ppVolume;
    
    private float time = 0f;
    private float dayLength = 45f;
    private float nightLength = 45f;
    private bool firstNight = true;
    
    private void Start()
    {
        GameObject ClownPlayer = GameObject.Find("ClownPlayer");
        mouseLook = ClownPlayer.GetComponent<FirstPersonController>().m_MouseLook;
        
        // GameOver();
        mouseLook.SetCursorLock(true);
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

    public void GameOver()
    {
        mouseLook.SetCursorLock(false);
        PlayerPrefs.SetInt("Score", score);
        SceneManager.LoadScene("GameOver");
    }
    
    public bool isNightTime()
    {
        return nightTime;
    }

    private void nightTransition()
    {
        if (firstNight)
        {
            StartCoroutine(ShowNightText());
            firstNight = false;
        }

        sun.color = Color.red;
        mainCamera.backgroundColor = new Color(0.007f, 0.1f, 0.16f);
        ppVolume.weight = 1f;

        while (SpawnParent.transform.childCount > 0) {
            DestroyImmediate(SpawnParent.transform.GetChild(0).gameObject);
        }
    }
    
    private void dayTransition()
    {
        sun.color = new Color(1, 0.9568627f, 0.8392157f);
        mainCamera.backgroundColor = new Color(0.1058824f, 0.5832241f, 0.8980392f);
        ppVolume.weight = 0f;

        while (SpawnParent.transform.childCount > 0) {
            DestroyImmediate(SpawnParent.transform.GetChild(0).gameObject);
        }
    }
    
    IEnumerator ShowNightText()
    {
        nightText.SetActive(true);
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(5f);
        nightText.SetActive(false);
        Time.timeScale = 1f;
    }
}
