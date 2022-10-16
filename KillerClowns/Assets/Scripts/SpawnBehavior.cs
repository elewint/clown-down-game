using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBehavior : MonoBehaviour
{
    private GameObject pivot;
    // Start is called before the first frame update
    void Start()
    {
        // Create new pivot to center of world
        pivot = new GameObject();

        GameObject SpawnParent = GameObject.Find("SpawnParent");
        pivot.transform.SetParent(SpawnParent.transform);

        pivot.transform.position = new Vector3(0, -21.1f, 0);
        transform.SetParent(pivot.transform);
    }

    // Update is called once per frame
    void Update()
    {
        float movementSpeed = Random.Range(5f, 25f);
        pivot.transform.Rotate(Vector3.left * movementSpeed * Time.deltaTime);
    }
}
