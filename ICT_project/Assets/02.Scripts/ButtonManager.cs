using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public GameObject Map;
    public GameObject Error;
    public string SceneName;

   public void SceneLoad()
    {
        SceneManager.LoadScene(SceneName);
        Debug.Log(SceneName);
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
