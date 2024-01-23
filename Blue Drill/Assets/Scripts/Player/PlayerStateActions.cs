using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerStateActions : MonoBehaviour
{
    [SerializeField] PlayerStates playerStates;
    [SerializeField] Canvas miniGameCanvas;
 

    void Update()
    {
        StateActions();
    }

    private void StateActions()
    {

        if(playerStates.currentState == PlayerStates.States.idle)
        {
           
        }
        if(playerStates.currentState == PlayerStates.States.walking)
        {
            
        }
        if(playerStates.currentState == PlayerStates.States.minigame)
        {
            miniGameCanvas.gameObject.SetActive(true);
        }
    }
}
