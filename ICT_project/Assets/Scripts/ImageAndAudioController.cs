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
    public AudioSource audioSource;
    public Text[] textArray;
    public GameObject NextSecnebtn;

    private int currentIndex = 0;

    void Start()
    {
        // 처음에 첫 번째 이미지와 오디오 재생
        UpdateImageAndAudio();
    }

    public void OnNextButtonClick()
    {
        // 인덱스 업데이트
        currentIndex++;
        if (currentIndex < imageArray.Length)
        {
            // 이미지와 오디오 업데이트
            UpdateImageAndAudio();
            //currentIndex = 0; // 마지막 이미지 후 다시 첫 이미지로
            if(currentIndex == imageArray.Length - 1 ) NextSecnebtn.SetActive(true);
        }
        else
        {
            currentIndex--;
        }
    }

    public void OnBackButtonClick()
    {
        if(currentIndex > 0)
        {
            // 인덱스 업데이트
            currentIndex--;

            // 이미지와 오디오 업데이트
            UpdateImageAndAudio();
        }
    }

    public void OnNextSceneButtonClick()
    {
        SceneManager.LoadScene("Game_Scene");
    }

    private void UpdateImageAndAudio()
    {
        // 이미지 업데이트
        imageDisplay.sprite = imageArray[currentIndex];

        // 오디오 재생
        if (audioSource != null && audioArray[currentIndex] != null)
        {
            audioSource.clip = audioArray[currentIndex];
            audioSource.Play();
        }

        // 자막 재생

    }
}
