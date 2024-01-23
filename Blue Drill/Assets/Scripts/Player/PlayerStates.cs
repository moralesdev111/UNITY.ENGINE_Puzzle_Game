using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStates : MonoBehaviour
{
    [SerializeField] PlayerInputs playerInputs;
    public enum States
    {
        idle,
        walking,
        minigame,
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
        }
        currentState = nextState;
        return currentState;
    }
}
