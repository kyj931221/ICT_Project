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
        // ó���� ù ��° �̹����� ����� ���
        UpdateImageAndAudio();
    }

    public void OnNextButtonClick()
    {
        // �ε��� ������Ʈ
        currentIndex++;
        if (currentIndex < imageArray.Length)
        {
            // �̹����� ����� ������Ʈ
            UpdateImageAndAudio();
            //currentIndex = 0; // ������ �̹��� �� �ٽ� ù �̹�����
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
}
