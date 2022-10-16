using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonCollide : MonoBehaviour
{
    private GameController gameController;

    // Start is called before the first frame update
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
            Rigidbody heart_Rigidbody = child.GetComponent<Rigidbody>();
            heart_Rigidbody.AddForce(transform.up * 300f);
            Destroy(child);
        }
        else if (other.gameObject.tag == "Clown") {
            Destroy(other.gameObject);
        }
    }
}
