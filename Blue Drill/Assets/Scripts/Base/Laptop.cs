using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class Laptop : MonoBehaviour
{
     public int randomNumber;

    [Header("References")]
    [SerializeField] PlayerStates playerStates;
    public GameObject LaptopCanvas;
    [SerializeField] LaptopStates laptopStates;

    
    void OnTriggerStay(Collider collider)
    {
        if(laptopStates.currentState != LaptopStates.States.blocked)
        {
        if(collider.CompareTag("Player"))
        {
            if(BlockComputer())
            {
                if(Input.GetKey(KeyCode.P))
            {
                playerStates.currentState = PlayerStates.States.freezingUI; 
                laptopStates.currentState = LaptopStates.States.loggedIn;                            
                
            }  
            }
            else if(!BlockComputer() && Input.GetKey(KeyCode.P))
            {
                laptopStates.currentState = LaptopStates.States.blocked;
            }
                     
        }
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if(laptopStates.currentState != LaptopStates.States.blocked)
        {
            laptopStates.currentState = LaptopStates.States.standby;

            if(collider.CompareTag("Player"))
            {
                RandomNumberGenerator();
            }
        }
        else 
        {
            return;
        }
        
    }

    void OnTriggerExit(Collider collider)
    {
        if(collider.CompareTag("Player"))
        {
            if(laptopStates.currentState != LaptopStates.States.blocked)
            {
                laptopStates.currentState = LaptopStates.States.idle;
            }
            
        }
    }

    public void ExitLaptopUIButton()
    {
        LaptopCanvas.SetActive(false);
        laptopStates.currentState = LaptopStates.States.standby;
        playerStates.currentState = PlayerStates.States.idle;
    }

    public int RandomNumberGenerator()
    {
       return randomNumber = Random.Range(0,5);
    }
    public bool BlockComputer()
    {        
        return randomNumber > 1;
    }
}
