using UnityEngine;


public class Laptop : MonoBehaviour, IRandomNumberGenerateable
{
     public int randomNumber;

    [Header("References")]
    [SerializeField] PlayerStates playerStates;
    public GameObject laptopCanvas;
    public GameObject startLaptopCanvas;
    public GameObject laptopBlockedCanvas;
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
                GenerateRandomNumber();
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
        laptopCanvas.SetActive(false);
        laptopStates.currentState = LaptopStates.States.standby;
        playerStates.currentState = PlayerStates.States.idle;
    }

    public int GenerateRandomNumber()
    {
       return randomNumber = Random.Range(0,5);
    }
    public bool BlockComputer()
    {        
        return randomNumber > 1;
    }
}
