using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class DoorController : MonoBehaviour
{
    public GameObject door;
    public GameObject canvas;
    public GameObject nextSceneTel;
    public AudioClip openClip;
    public AudioClip gameStartClip;

    AudioSource adSource;

    // Start is called before the first frame update
    void Start()
    {
        adSource = GetComponent<AudioSource>();
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
            adSource.PlayOneShot(gameStartClip);
        }
    }

    public void OpenDoor()
    {
        adSource.PlayOneShot(openClip);
        door.SetActive(false);
        canvas.SetActive(false);
        gameObject.GetComponent<BoxCollider>().enabled = false;
        nextSceneTel.SetActive(true);
    }
}
