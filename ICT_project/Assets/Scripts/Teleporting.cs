using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporting : MonoBehaviour
{
    // Ư�� ������Ʈ�� ��ġ���� �Է¹޾Ƽ� �̵��Ѵ�.
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
