using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public GameObject Cube;
    public GameObject Spawner;
    public float LifeTime;
    
    // Start is called before the first frame update
    void Start()
    {
        if(gameObject.transform.tag=="Cube")
        {
            Destroy(gameObject,LifeTime);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnCube()
    {
        Debug.Log("Cube Spawn Start");
        Instantiate(Cube,Spawner.transform.position,Quaternion.identity);
        Debug.Log("Cube Spawn");
    }
}
