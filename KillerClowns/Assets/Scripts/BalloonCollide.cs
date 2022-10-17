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
            // Debug.Log("Child hit!");
            gameController.incrementScore();

            GameObject child = other.gameObject.transform.GetChild(0).gameObject;
            Rigidbody heart_Rigidbody = child.GetComponent<Rigidbody>();
            heart_Rigidbody.AddForce(transform.up * 300f);
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "Clown") {
            gameController.incrementScore();
            Destroy(other.gameObject);
        }
    }
}
