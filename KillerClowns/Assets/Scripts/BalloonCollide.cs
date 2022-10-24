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
            other.gameObject.GetComponent<Collider>().enabled = false;
            gameController.incrementScore();

            GameObject heart = other.gameObject.transform.GetChild(0).gameObject;
            Rigidbody heartRigidbody = heart.transform.GetChild(0).gameObject.GetComponent<Rigidbody>();
            
            if (other.gameObject.transform.childCount > 1) {
                GameObject child = other.gameObject.transform.GetChild(1).gameObject;
                Destroy(child);
            }
            
            heartRigidbody.AddForce(heart.transform.up * 300f);
            StartCoroutine(DestroyHeart(heart));
        }
        else if (other.gameObject.tag == "Clown") {
            gameController.incrementScore();
            Destroy(other.gameObject);
        }
    }
    
    IEnumerator DestroyHeart(GameObject heart) {
        yield return new WaitForSeconds(1);
        Destroy(heart);
    }
}
