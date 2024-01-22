using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] PlayerMovement playerMovement; 

    
    private void Update()
    {    
        playerMovement.Move();   
    }




}
    
    
