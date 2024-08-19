using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    public string SceneName;
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            SceneManager.LoadScene(SceneName);
        }
    }
}
