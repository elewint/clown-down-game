using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CollideAction : MonoBehaviour {
    private GameController gameController;

    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }
    
    private void OnTriggerEnter(Collider other){
        // Debug.Log("COLLIDER ENTERED!");
        if (other.gameObject.tag == "Child") {
            //other.gameObject.SetActive(false);
            // Debug.Log("Player hit!");
            gameController.incrementScore();


            GameObject child = other.gameObject.transform.GetChild(0).gameObject;
            Rigidbody balloon_Rigidbody = child.GetComponent<Rigidbody>();
            balloon_Rigidbody.AddForce(transform.up * 300f);
        }
        else if (other.gameObject.tag == "Clown") {
            // YOU LOSE!
            SceneManager.LoadScene("GameOver");
        }
    }
}