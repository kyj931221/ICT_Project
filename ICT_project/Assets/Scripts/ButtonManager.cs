using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public GameObject Map;
    public GameObject Error;

   public void SceneLoad()
    {
        SceneManager.LoadScene("TestScene");
        Debug.Log("LoadScene");
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("ExitGame");
    }

    public void MapOpen()
    {
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
}
