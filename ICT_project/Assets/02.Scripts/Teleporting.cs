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

    IEnumerator waitTel()
    {
        Debug.Log("������");
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
