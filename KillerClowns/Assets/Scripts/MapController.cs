using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public GameObject childPrefab;
    public GameObject clownPrefab;
    public GameObject spawnPlane;
    public GameObject spawnParent;
    public GameController gc;

    private GameObject spawnObject;
    private int speed = 25;
    // private float spawnRadius = 10f;
    // private int numOfObjects = 10;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnChildren", 0f, 3f);
        spawnObject = childPrefab;
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
    
    private void SpawnChildren()
    {
        if (gc.isNightTime())
        {
            spawnObject = clownPrefab;
        }
        else
        {
            spawnObject = childPrefab;
        }

        RaycastHit hit;
        
        Vector3 rayStartPos = spawnPlane.transform.position;
        rayStartPos.x = Random.Range(-10f, 10f);

        if (Physics.Raycast(rayStartPos, spawnPlane.transform.up * -1.0f, out hit) && hit.transform.tag == "Map")
        {
            // Raycast Debugging
            // Debug.Log("Spawned!");
            // Debug.DrawLine(rayStartPos, hit.point, Color.white, 100f);

            // Set rotation of child
            Quaternion startRot = Quaternion.LookRotation(hit.normal);
            startRot *= Quaternion.Euler(90, 0, 0);
            startRot *= Quaternion.Euler(0, 90, 0);

            // Make rotation face camera
            if (rayStartPos.x < -2f)
            {
                startRot *= Quaternion.Euler(0, -45, 0);
            } else if (rayStartPos.x > 2f)
            {
                startRot *= Quaternion.Euler(0, 45, 0);
            }
            
            // Spawn child
            GameObject newSpawnObj = Instantiate(spawnObject, hit.point, startRot);
            newSpawnObj.transform.SetParent(spawnParent.transform);
            
            Destroy(newSpawnObj, 20f);
        }
        // else
        // {
        //     Debug.Log("Miss");
        // }
    }
}
