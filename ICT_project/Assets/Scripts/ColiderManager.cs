using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColiderManager : MonoBehaviour
{
    [Header("Collider�� ������ SetActive")]
    [SerializeField] GameObject Title;
    [SerializeField] GameObject StartBtton;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "intro")
        {
            Title.SetActive(true);
            StartBtton.SetActive(true);
        }
    }
}
