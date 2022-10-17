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

            GameObject heart = other.gameObject.transform.GetChild(0).gameObject;
            Rigidbody heartRigidbody = heart.transform.GetChild(0).gameObject.GetComponent<Rigidbody>();
            heartRigidbody.AddForce(heart.transform.up * 300f);
            StartCoroutine(DestroyChild(other.gameObject));
        }
        else if (other.gameObject.tag == "Clown") {
            gameController.incrementScore();
            Destroy(other.gameObject);
        }
    }
    
    IEnumerator DestroyChild(GameObject child) {
        yield return new WaitForSeconds(1);
        Destroy(child);
    }
}
