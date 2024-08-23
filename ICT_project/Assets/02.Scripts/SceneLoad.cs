using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    GameManager gm;

    private void Awake()
    {
        gm = GameManager.instance.GetComponent<GameManager>();
    }

    // public string SceneName;
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            Transform tmpTRP = other.transform;
            int tmpIdx = SceneManager.GetActiveScene().buildIndex;
            gm.BackToStory(tmpIdx, tmpTRP);
        }
    }
}
