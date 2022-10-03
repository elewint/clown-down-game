using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public GameObject spawnObject;
    private int speed = 10;
    private float spawnRadius = 10f;
    private int numOfObjects = 10;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numOfObjects; i++)
        {
            // Vector2 spawnPos2D = Random.insideUnitCircle * spawnRadius;
            // Vector3 spawnPos3D = new Vector3(spawnPos2D.x, 0f, spawnPos2D.y);
            
            // Vector3 spawnPosRelative = transform.position + spawnPos3D;
            Vector3 spawnPosRelative = new Vector3(10f, 10f, 10f);
            
            RaycastHit hit;

            if (Physics.Raycast(spawnPosRelative, Vector3.down, out hit))
            {
                Vector3 spawnPosFinal = hit.point;
                Instantiate(spawnObject, spawnPosFinal, Quaternion.identity);
            }
            
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Rotate(Vector3.up * speed * Time.deltaTime);
        } else if (Input.GetKey(KeyCode.S))
        {
            transform.Rotate(Vector3.down * speed * Time.deltaTime);
        }
    }
}
