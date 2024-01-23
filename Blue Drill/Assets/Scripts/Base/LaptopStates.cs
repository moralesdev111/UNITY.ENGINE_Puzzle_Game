using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaptopStates : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Laptop laptop;
    public float timer = 0;


    public enum States
    {
        idle,
        standby,
        loggedIn,
        blocked
    }

    public States currentState;

    private void Update()
    {
        CurrentState();
    }
    public States CurrentState()
    {

        States nextState = currentState;
        
        switch(currentState)
        {
            case States.idle:
            break;

            case States.standby:
            break;

            case States.loggedIn:            
            laptop.LaptopCanvas.SetActive(true);  
                      
            break;

            case States.blocked:
            timer += Time.deltaTime;
                if(timer > 8f)
                {
                    nextState = States.idle;
                    timer = 0;
                }
            break;
        }

        currentState = nextState;
        return currentState;
    }

    
}
