using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerCollide : MonoBehaviour {
    public AudioClip[] clownSounds;
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
            AudioSource audioSource = other.gameObject.GetComponent<AudioSource>();

            int soundChoice = Random.Range(0, clownSounds.Length + 2);

            if (soundChoice >= 0 && soundChoice < clownSounds.Length) {
                audioSource.clip = clownSounds[soundChoice];
                audioSource.Play();
            }
        }
    }
}