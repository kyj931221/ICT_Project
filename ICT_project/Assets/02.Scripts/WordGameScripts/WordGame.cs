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
        // 정답 효과음
        adSource.PlayOneShot(trueSound);

        // 오답 가리기
        foreach(GameObject o in falseAnswer) o.SetActive(false);
        trueAnswer.GetComponent<Button>().enabled = false;

        // 설명 팝업
        desc.SetActive(true);

        // 효과음 종료 후 설명 재생
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
        // 설명 종료 후 성문 개방
        playerSpot.SetActive(true);
        GameEnd.GetComponent<DoorController>().OpenDoor();
    }

    public void FalseAnswer()
    {
        adSource.PlayOneShot(falseSound);
    }
}
