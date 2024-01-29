using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStates : MonoBehaviour
{
    [Header("References")]
    [SerializeField] PlayerInputs playerInputs;
    [SerializeField] PlayerMovement playerMovement;

    public enum States
    {
        idle,
        walking,
        idleSwim,
        swimming,
        minigame,
        minigame2,
        freezingUI
    }

    public States currentState;

    public States UpdateState()
    {
        States nextState = currentState;
        switch (currentState)
        {
            case States.idle:
            if(playerInputs.direction.magnitude >= 0.01f)
            {
                nextState = States.walking;
            }
            break;
             case States.walking:
                if (playerInputs.direction.magnitude <= 0.01f)
                {
                    nextState = States.idle;
                }
                if (playerMovement.waterMovement)
                {
                    nextState = States.swimming;
                }
                break;

            case States.swimming:
                if (!playerMovement.waterMovement)
                {
                    nextState = States.walking;
                }
                else if (playerInputs.direction.magnitude < 0.01f)
                {
                    nextState = States.idleSwim;
                }
                break;

            case States.idleSwim:
                if (playerInputs.direction.magnitude >= 0.01f)
                {
                    nextState = States.swimming;
                }
                break;
            case States.minigame:            
            break;
            case States.minigame2:            
            break;
            case States.freezingUI:            
            break;
        }
        currentState = nextState;
        return currentState;
    }
}
