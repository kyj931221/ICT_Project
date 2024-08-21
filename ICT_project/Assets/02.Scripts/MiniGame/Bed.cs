using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject Next_Scene_Teleport;
    public GameObject Complete_Image;
    public int score;
    public TextMeshProUGUI scoreText;
    public GameObject Devet_Spawner;
    public GameObject Devet;
    
    // Start is called before the first frame update
    void Start()
    {
       score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(score >= 20)
        {
            Next_Scene_Teleport.SetActive(true);
            Complete_Image.SetActive(true);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Cube")
        {
            Destroy(collision.gameObject);
            score += 2;
            scoreText.text = "Score: " + score + " / 20��";

            if (score % 10 == 0 && score != 0)
            {
                Debug.Log("Devet Spawn Start");
                Instantiate(Devet, Devet_Spawner.transform.position, Quaternion.identity);
                Debug.Log("Devet Spawn");
            }
        }
        /*else if (collision.transform.tag == "BigCube")
        {
            Destroy(collision.gameObject);
            score += 10;
            scoreText.text = "Score: " + score;
        }*/
    }
    /*private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Cube")
        {
            Destroy(other.gameObject);
            score++;
        }
        else if(other.tag == "BigCube")
        {
            Destroy(other.gameObject);
            score+=10;
        }
    }*/

    //public void DevetSpawn()
    //{
    //    if (score % 10 == 0)
    //    {
    //        Debug.Log("Devet Spawn Start");
    //        Instantiate(Devet, Devet_Spawner.transform.position, Quaternion.identity);
    //        Debug.Log("Devet Spawn");
    //    }
    //}
}
