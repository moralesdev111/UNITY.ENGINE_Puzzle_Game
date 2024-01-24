using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaptopStates : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Laptop laptop;
    public float timer = 0;
    public float blockedTime = 8f;


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
            laptop.startLaptopCanvas.SetActive(false);
            break;

            case States.standby:
            laptop.startLaptopCanvas.SetActive(true);
            break;

            case States.loggedIn: 
            laptop.startLaptopCanvas.SetActive(false);           
            laptop.laptopCanvas.SetActive(true);  
                      
            break;

            case States.blocked:   
            laptop.startLaptopCanvas.SetActive(false); 
            laptop.laptopBlockedCanvas.SetActive(true);

            if(BlockingFunction() > 6f)
            {
                laptop.laptopBlockedCanvas.SetActive(false);
            }
            if(BlockingFunction() > blockedTime)
                {
                    nextState = States.idle;
                    timer = 0;
                }
            
            break;
            
        }

        currentState = nextState;
        return currentState;
    }

    private float BlockingFunction()
    {
       return timer += Time.deltaTime;                
    }

    
}
