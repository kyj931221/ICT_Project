using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public GameObject Cube;
    public GameObject Spawner;
    public float LifeTime;
    public AudioClip SpawnCilp;
    public AudioSource SpawnSource;
    
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
        SpawnSource.PlayOneShot(SpawnCilp);
        Debug.Log("Cube Spawn");
    }
}
