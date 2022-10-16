using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
            other.gameObject.SetActive(false);
            // Debug.Log("Player hit!");
            gameController.incrementScore();
        }
    }
}