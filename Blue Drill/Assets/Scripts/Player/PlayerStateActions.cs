using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerStateActions : MonoBehaviour
{
    [Header("References")]
    [SerializeField] PlayerStates playerStates;
    [SerializeField] PlayerInputs playerInputs;
    [SerializeField] Canvas miniGameCanvas;
 

    public void StateActions()
    {
        if(playerStates.currentState == PlayerStates.States.idle)
        {
           
        }
        if(playerStates.currentState == PlayerStates.States.walking)
        {
            
        }
        if(playerStates.currentState == PlayerStates.States.minigame)
        {
            playerInputs.direction = new Vector3(0,0,0);
            miniGameCanvas.gameObject.SetActive(true);
            
        }
        if(playerStates.currentState == PlayerStates.States.minigame2)
        {
            playerInputs.direction = new Vector3(0,0,0);
            
           
            
        }
        if(playerStates.currentState == PlayerStates.States.freezingUI)
        {
            playerInputs.direction = new Vector3(0,0,0);
        }        
    }
}
