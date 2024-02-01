using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseOxygenExclude : MonoBehaviour
{
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] Animator animator;
    public bool exclude = true;

    
    private void OnTriggerStay(Collider collider)
    {
        if(collider.CompareTag("Player"))
        {
            exclude = true;
            playerMovement.waterMovement = false;
            animator.SetBool("waterMovement",false);
            
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.CompareTag("Player"))
        {
            AudioManager.Instance.StopMusic();
            AudioManager.Instance.PlayMusic("base");
        }
    }
    private void OnTriggerExit(Collider collider)
    {
        if(collider.CompareTag("Player"))
        {
            exclude = false;
            playerMovement.waterMovement = true;
            animator.SetBool("waterMovement",true);
            AudioManager.Instance.StopMusic();
            AudioManager.Instance.PlayMusic("underwater");
        }
    }
    
}
