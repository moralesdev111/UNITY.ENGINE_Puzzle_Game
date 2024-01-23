using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStates : MonoBehaviour
{
    [Header("References")]
    [SerializeField] PlayerInputs playerInputs;

    public enum States
    {
        idle,
        walking,
        minigame,
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
            if(playerInputs.direction.magnitude <= 0.01f)
            {
                nextState = States.idle;
            }
            break;
            case States.minigame:            
            break;
            case States.freezingUI:            
            break;
        }
        currentState = nextState;
        return currentState;
    }
}
