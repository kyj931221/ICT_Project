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
        // ���� ȿ����
        adSource.PlayOneShot(trueSound);

        // ���� ������
        foreach(GameObject o in falseAnswer) o.SetActive(false);
        trueAnswer.GetComponent<Button>().enabled = false;

        // ����, ��ŵ ��ư �˾�
        desc.SetActive(true);
        skipBtn.SetActive(true);

        // ȿ���� ���� �� ���� ���
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
        // ���� ���� �� ���� ����
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
