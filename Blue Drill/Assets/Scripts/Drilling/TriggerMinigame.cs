using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMinigame : MonoBehaviour
{
    void OnTriggerStay(Collider collider)
    {
        ActiveItemSlot activeItemSlot = FindObjectOfType<ActiveItemSlot>();
        PlayerStates playerStates = collider.GetComponent<PlayerStates>();

        if (activeItemSlot != null)
        {            
            if (activeItemSlot.activeitem != null && activeItemSlot.activeitem.itemType == Item.ItemType.tool)
            {
                if (collider.gameObject.CompareTag("Player"))
                {
                    if (Input.GetKey(KeyCode.Z))
                    {
                         Debug.Log("Game Started"); // trigger minigame player state
                         playerStates.currentState = PlayerStates.States.minigame;
                    }
                }                           
            }     
            else
            {
                // Handle the case where activeitem is null or itemType is not tool
                return;
            }       
        }
    }
}
