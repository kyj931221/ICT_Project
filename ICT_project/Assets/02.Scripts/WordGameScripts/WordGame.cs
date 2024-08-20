using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WordGame : MonoBehaviour
{
    public AudioClip trueSound;
    public AudioClip falseSound;
    public AudioClip descSound;
    public GameObject trueAnswer;
    public GameObject[] falseAnswer;
    public GameObject desc;
    public GameObject GameEnd;
    public GameObject playerSpot;
    
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
        // ���� ȿ����
        adSource.PlayOneShot(trueSound);

        // ���� ������
        foreach(GameObject o in falseAnswer) o.SetActive(false);
        trueAnswer.GetComponent<Button>().enabled = false;

        // ���� �˾�
        desc.SetActive(true);

        // ȿ���� ���� �� ���� ���
        StartCoroutine(WaitSound(trueSound));
        adSource.PlayOneShot(descSound);
        StartCoroutine(WaitDesc(descSound));
    }

    IEnumerator WaitSound(AudioClip clip)
    {
        yield return new WaitForSeconds(clip.length);
    }

    IEnumerator WaitDesc(AudioClip clip)
    {
        yield return new WaitForSeconds(clip.length);
        // ���� ���� �� ���� ����
        playerSpot.SetActive(true);
        GameEnd.GetComponent<DoorController>().OpenDoor();
    }

    public void FalseAnswer()
    {
        adSource.PlayOneShot(falseSound);
    }
}
