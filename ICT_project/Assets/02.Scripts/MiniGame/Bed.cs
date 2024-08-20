using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject score10;
    public GameObject score20;
    public int score;
    public Text scoreText;
    
    // Start is called before the first frame update
    void Start()
    {
       score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(score>=10 && score < 20)
        {
            score10.SetActive(true);
        }
        else if(score >= 20)
        {
            score20.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Cube")
        {
            Destroy(collision.gameObject);
            score++;
            scoreText.text = "Score: " + score;
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
}
