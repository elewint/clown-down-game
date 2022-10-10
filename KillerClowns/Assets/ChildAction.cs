using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildAction : MonoBehaviour {

     void OnTriggerEnter(Collider other){
             if (other.gameObject.tag == "Player") {
                 gameObject.SetActive(false);
             }
      }
}