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
    public GameObject skipBtn;
    public GameObject desc;
    public GameObject GameEnd;
    public GameObject playerSpot;

    GameManager gm;
    
    AudioSource adSource;

    private void Awake()
    {
        gm = GameManager.instance.GetComponent<GameManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        adSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    Coroutine descRoutine;
    public void TrueAnswer()
    {
        // 정답 효과음
        adSource.PlayOneShot(trueSound);

        // 오답 가리기
        foreach(GameObject o in falseAnswer) o.SetActive(false);
        trueAnswer.GetComponent<Button>().enabled = false;

        // 설명, 스킵 버튼 팝업
        desc.SetActive(true);
        skipBtn.SetActive(true);

        // 효과음 종료 후 설명 재생
        StartCoroutine(WaitSound(trueSound));
        adSource.PlayOneShot(descSound);

        descRoutine = StartCoroutine(WaitDesc(descSound));
    }

    IEnumerator WaitSound(AudioClip clip)
    {
        yield return new WaitForSeconds(clip.length);
    }

    IEnumerator WaitDesc(AudioClip clip)
    {
        yield return new WaitForSeconds(clip.length);
        // 설명 종료 후 성문 개방
        OpenDoor();
    }

    public void FalseAnswer()
    {
        adSource.PlayOneShot(falseSound);
    }

    public void OpenDoor()
    {
        gm.is1stMiniGameClear = true;
        playerSpot.SetActive(true);
        GameEnd.GetComponent<DoorController>().OpenDoor();
    }

    public void Skip()
    {
        adSource.Stop();
        StopWaitDesc();
        OpenDoor();
    }

    void StopWaitDesc()
    {
        if(descRoutine != null)
        {
            StopCoroutine(descRoutine);
        }
    }
}
