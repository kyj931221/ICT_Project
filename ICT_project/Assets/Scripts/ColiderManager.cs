using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColiderManager : MonoBehaviour
{
    private Animator animator;
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
    }
}
