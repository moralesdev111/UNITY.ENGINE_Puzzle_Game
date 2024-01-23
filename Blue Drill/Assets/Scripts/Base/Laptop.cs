using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class Laptop : MonoBehaviour
{
    [Header("References")]
    [SerializeField] PlayerStates playerStates;
    [SerializeField] GameObject laptopCanvas;

    
    void OnTriggerStay(Collider collider)
    {
        if(collider.CompareTag("Player"))
        {
            if(Input.GetKey(KeyCode.P))
            {
                laptopCanvas.SetActive(true);
            playerStates.currentState = PlayerStates.States.freezingUI;
            }            
        }
    }

    public void ExitLaptopUI()
    {
        laptopCanvas.SetActive(false);
        playerStates.currentState = PlayerStates.States.idle;
    }
}
