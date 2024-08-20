using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGamesStart : MonoBehaviour
{
    public GameObject MiniGame;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider Game_Player)
    {
        if (Game_Player.gameObject.tag == "Player")
        {
            MiniGame.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
