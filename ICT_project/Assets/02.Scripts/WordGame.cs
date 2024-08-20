using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WordGame : MonoBehaviour
{
    public AudioClip trueSound;
    public AudioClip falseSound;
    public GameObject trueAnswer;
    public GameObject[] falseAnswer;
    public GameObject NextBtn;

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

    public void TrueAnswer()
    {
        //adSource.PlayOneShot(trueSound);
        foreach(GameObject o in falseAnswer) o.SetActive(false);
        trueAnswer.SetActive(true);
        NextBtn.SetActive(true);
    }

    public void FalseAnswer()
    {
        //adSource.PlayOneShot(falseSound);
    }

    public void NextScene()
    {
        SceneManager.LoadScene("Game_Scene");
    }
}
