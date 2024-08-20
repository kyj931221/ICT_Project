using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public GameObject door;
    public GameObject canvas;
    public GameObject nextSceneTel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    { 
        if(other.transform.tag == "Player")
        {
            canvas.SetActive(true);
        }
    }

    public void OpenDoor()
    {
        door.SetActive(false);
        canvas.SetActive(false);
        gameObject.GetComponent<BoxCollider>().enabled = false;
        nextSceneTel.SetActive(true);
    }
}
