using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement; 
using UnityEngine.UI;

public class BalloonGun : MonoBehaviour
{
    public GameObject spawnObject; 
    public GameObject handBalloonAnimal; 
    public GameObject parent;
    public Slider cooldownSlider;

    private Vector3 gunSize;
    private MeshCollider gunRenderer;
    private Color balloonColor;
    private GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        gunSize = GetComponent<Collider>().bounds.size;
        handBalloonAnimal = handBalloonAnimal.transform.GetChild(0).gameObject;

        balloonColor = Random.ColorHSV(0f, 1f, 1f, 1f, 0.75f, 1f);
        balloonColor.a = 0.8f;
        handBalloonAnimal.GetComponent<Renderer>().material.color = balloonColor;
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        
        cooldownSlider.value = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldownSlider.value < 1f && cooldownSlider.value > 0.5f)
        {
            cooldownSlider.value += (Time.deltaTime / 20f);
        }
        else if (cooldownSlider.value < 1f && cooldownSlider.value <= 0.5f)
        {
            cooldownSlider.value += (Time.deltaTime / 10f);
        }

        transform.position = parent.transform.position;
        transform.rotation = parent.transform.rotation;

        if (CrossPlatformInputManager.GetButtonDown("Fire1") && Time.timeScale == 1f && cooldownSlider.value > 0.1f)
        {
            cooldownSlider.value -= 0.1f;

            Vector3 newPosition = transform.position + new Vector3(gunSize.x / 2, gunSize.y / 2, 0);
            GameObject newSpawnObj = Instantiate(spawnObject, newPosition, Random.rotation);
            newSpawnObj.transform.GetChild(0).gameObject.GetComponent<Renderer>().material.color = balloonColor;

            balloonColor = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            balloonColor.a = 0.8f;
            handBalloonAnimal.GetComponent<Renderer>().material.color = balloonColor;

            //newSpawnObj.transform.localScale += new Vector3(10f, 10f, 10f);
            Rigidbody balloon_Rigidbody = newSpawnObj.GetComponent<Rigidbody>();
            balloon_Rigidbody.AddForce(transform.right * 600f);

            Destroy(newSpawnObj, 10f);
        }

         if (transform.position.y < -80) {
             gameController.GameOver();
            }
    }
}
