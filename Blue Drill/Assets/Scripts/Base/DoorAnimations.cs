using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimations : MonoBehaviour
{
    
    [Header("References")]
    [SerializeField] Animator animator;

    
    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            animator.SetBool("Closing",false);
            animator.SetBool("Opening",true);

        }
    }
    void OnTriggerExit(Collider collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collider exited");
            animator.SetBool("Opening",false);
            animator.SetBool("Closing",true);

        }
    }
}
