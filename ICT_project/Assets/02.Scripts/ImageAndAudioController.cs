using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ImageAndAudioController : MonoBehaviour
{
    public Image imageDisplay;
    public Sprite[] imageArray;
    public AudioClip[] audioArray;
    public AudioClip pageClip;
    public AudioSource audioSource;
    public Text[] textArray;
    public GameObject NextSecnebtn;

    private int currentIndex;
    private GameManager gm;
    private bool isAudioPlaying = false;
    private Coroutine co;

    private void Awake()
    {
        gm = GameManager.instance.GetComponent<GameManager>();
        currentIndex = gm.curStoryIdx;
    }
    void Start()
    {
        // ó���� ù ��° �̹����� ����� ���
        UpdateImageAndAudio();
    }

    public void OnNextButtonClick()
    {
        if(isAudioPlaying == true)
        {
            audioSource.Stop();
            if (co != null)
            {
                StopCoroutine(co);
                LoadGame();
            }
            return;
        }

        // �ε��� ������Ʈ
        currentIndex++;
        if (currentIndex < imageArray.Length)
        {
            // �̹����� ����� ������Ʈ
            UpdateImageAndAudio();
            ConnectToGame();
            //currentIndex = 0; // ������ �̹��� �� �ٽ� ù �̹�����
            if (currentIndex == imageArray.Length - 1) NextSecnebtn.SetActive(true);
        }
        else
        {
            currentIndex--;
        }
    }

    public void OnBackButtonClick()
    {
        if (currentIndex > 0)
        {
            // �ε��� ������Ʈ
            currentIndex--;

            // �̹����� ����� ������Ʈ
            UpdateImageAndAudio();
        }
    }

    public void OnNextSceneButtonClick()
    {
        SceneManager.LoadScene("Game_Scene");
    }

    private void UpdateImageAndAudio()
    {
        audioSource.PlayOneShot(pageClip);
        gm.curStoryIdx = currentIndex;
        // �̹��� ������Ʈ
        imageDisplay.sprite = imageArray[currentIndex];

        // ����� ���
        if (audioSource != null && audioArray[currentIndex] != null)
        {
            audioSource.clip = audioArray[currentIndex];
            audioSource.Play();
        }

        // �ڸ� ���

    }

    public void ConnectToGame()
    {
        if (Array.IndexOf(gm.GameConnectIDX, currentIndex) > -1)
        {
            if (currentIndex == 2 && gm.is1stMiniGameClear == true)
            {
                return ;
            }
            if (currentIndex == 3 && gm.is2ndtMiniGameClear == true)
            {
                 return;
            }

            if (currentIndex == 2)
            {
                audioSource.Stop();
                LoadGame();
            }
            else if (currentIndex == 3)
            {
                isAudioPlaying = true;
                co = StartCoroutine(WaitForAudio());
            }
            
        }
        return;
    }

    IEnumerator WaitForAudio()
    {
        yield return new WaitForSeconds(audioSource.clip.length);
        LoadGame();
    }

    void LoadGame()
    {
        gm.curSceneIdx = SceneManager.GetActiveScene().buildIndex;
        gm.curTransform = GameObject.Find("OVRCameraRigInteraction").transform;
        gm.curStoryIdx = currentIndex;
        SceneManager.LoadScene(currentIndex);
    }
}
