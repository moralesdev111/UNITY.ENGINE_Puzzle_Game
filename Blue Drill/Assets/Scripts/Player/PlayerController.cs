using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] PlayerMovement playerMovement; 
    [SerializeField] PlayerStates playerStates;
    
    private void Update()
    {    
        playerStates.UpdateState();
        playerMovement.Move();   
    }
}
    
    
