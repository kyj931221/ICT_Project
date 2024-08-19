using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporting : MonoBehaviour
{
    // 특정 오브젝트의 위치값을 입력받아서 이동한다.
    public Transform Taget;
    public GameObject Game_Player;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider Game_Player)
    {
        if(Game_Player.gameObject.tag == "Player")
        {
            Game_Player.transform.position = Taget.transform.position;
        }
    }
}
