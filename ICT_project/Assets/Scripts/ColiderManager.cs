using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColiderManager : MonoBehaviour
{
    //[Header("Collider에 닿으면 행동")]
    //[SerializeField] GameObject Title;
    //[SerializeField] GameObject StartBtton;
    //[SerializeField] GameObject ExitBtton;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "intro")
        {
            //Title.SetActive(true);
            //StartBtton.SetActive(true);
            //ExitBtton.SetActive(true);
        }
    }
}
