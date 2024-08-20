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

    IEnumerator waitTel()
    {
        Debug.Log("텔포중");
        yield return new WaitForSeconds(1f); 
        Game_Player.transform.position = Taget.transform.position;
    }

    private void OnTriggerEnter(Collider Game_Player)
    {
        Debug.Log(Game_Player.tag);

        if(Game_Player.gameObject.tag == "Player")
        {
            Debug.Log("start");
            StartCoroutine(waitTel());
            Debug.Log("End");
        }
    }
}
