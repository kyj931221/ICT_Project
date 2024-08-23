using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColiderManager : MonoBehaviour
{
    private Animator animator;
    public GameObject HandMenu;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("tirigger");
        if (other.tag == "Finish")
        { 
            animator.SetTrigger("Fin");
        }

         if (other.tag == "Outtro")
         {
            HandMenu.SetActive(true);
         }
    }

}
