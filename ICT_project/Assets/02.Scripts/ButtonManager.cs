using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public GameObject Map;
    public GameObject Error;
    public string SceneName;
    public AudioClip mapSound;
    AudioSource audioSource;
    public AudioClip TutoSound;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void SceneLoad()
    {
        SceneManager.LoadScene(SceneName);
        Debug.Log(SceneName);
    }
    public void Home()
    {
        SceneManager.LoadScene("01.Main_Title_Scene");
        Debug.Log("Home");
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("ExitGame");
    }

    public void MapOpen()
    {
        audioSource.PlayOneShot(mapSound);
        Map.SetActive(true);
    }

    public void MapClose()
    { 
        Map.SetActive(false);
    }

    public void ErrorOpen()
    {
        Error.SetActive(true);
    }

    public void ErrorClose()
    {
        Error.SetActive(false);
    }

    public void TutoBtn()
    {
        audioSource.PlayOneShot(TutoSound);
    }
}
