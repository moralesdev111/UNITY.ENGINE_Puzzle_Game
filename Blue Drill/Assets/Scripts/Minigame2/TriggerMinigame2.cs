using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMinigame2 : MonoBehaviour
{

     [Header("References")]
    
    [SerializeField] Status status;
    [SerializeField] PlayerStates playerStates;

/*
    void OnTriggerStay(Collider collider)
    {
        if(status.canStart)
        {
            if (collider.gameObject.CompareTag("Player"))
        {
            if(Input.GetKey(KeyCode.X))
            {
                 playerStates.currentState = PlayerStates.States.minigame2;
                 status.StartGame();
            }           
        }
        }
    }*/
}
