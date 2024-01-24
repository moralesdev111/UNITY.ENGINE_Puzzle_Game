using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] PlayerMovement playerMovement; 
    [SerializeField] PlayerStates playerStates;
    [SerializeField] PlayerStateActions playerStateActions;
    [SerializeField] RepairAbility repairAbility;
    

    private void Update()
    {    
        playerStates.UpdateState();
        playerStateActions.StateActions();
        playerMovement.Move();   
        repairAbility.CheckIfCanRepair();
    }
}
    
    
