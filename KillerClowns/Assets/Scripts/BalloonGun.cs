using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonGun : MonoBehaviour
{
    public GameObject spawnObject; 
    public Vector3 gunSize;
    private MeshCollider gunRenderer;


    // Start is called before the first frame update
    void Start()
    {
        gunSize = GetComponent<Collider>().bounds.size;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            print("space key was pressed");
            print(transform.position);
            Vector3 newPosition = transform.position + new Vector3(gunSize.x /2, gunSize.y / 2, 0);
            print(transform.position);
            print(gunSize.x);
            GameObject newSpawnObj = Instantiate(spawnObject, newPosition, Quaternion.identity);
            //newSpawnObj.transform.localScale += new Vector3(10f, 10f, 10f);
            Rigidbody balloon_Rigidbody = newSpawnObj.GetComponent<Rigidbody>();
            balloon_Rigidbody.AddForce(transform.right * 600f);
        }
    }
}
