using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    // public GameObject spawnObject;
    // public GameObject spawnPlane;
    // public GameObject spawnParent;
    private int speed = 10;
    // private float spawnRadius = 10f;
    // private int numOfObjects = 10;

    // Start is called before the first frame update
    void Start()
    {
        // RaycastHit hit;
        
        // Vector3 rayStartPos = spawnPlane.transform.position;

        // if (Physics.Raycast(rayStartPos, spawnPlane.transform.up * -1.0f, out hit))
        // {
        //     Debug.Log("Hit");
        //     Debug.DrawLine(rayStartPos, hit.point, Color.white, 100f);
        //     Quaternion startRot = Quaternion.LookRotation(hit.normal);
        //     startRot *= Quaternion.Euler(90, 0, 0);
        //     GameObject newSpawnObj = Instantiate(spawnObject, hit.point, startRot);
        //     newSpawnObj.transform.SetParent(spawnParent.transform);
        // }
        // else
        // {
        //     Debug.Log("Miss");
        // }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Rotate(Vector3.left * speed * Time.deltaTime);
        } else if (Input.GetKey(KeyCode.S))
        {
            transform.Rotate(Vector3.right * speed * Time.deltaTime);
        }
    }
}
