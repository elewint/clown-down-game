using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerCollide : MonoBehaviour {
    private GameController gameController;

    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }
    
    private void OnTriggerEnter(Collider other){
        // Debug.Log("COLLIDER ENTERED!");
        if (other.gameObject.tag == "Child") {
            // gameController.incrementScore();

            // GameObject child = other.gameObject.transform.GetChild(0).gameObject;
            // Rigidbody heart_Rigidbody = child.GetComponent<Rigidbody>();
            // heart_Rigidbody.AddForce(transform.up * 300f);
        }
        else if (other.gameObject.tag == "Clown") {
            // YOU LOSE!
            gameController.GameOver();
        }
        else if (other.gameObject.tag == "ClownSound"){
            other.gameObject.GetComponent<AudioSource>().Play();
        }
    }
}