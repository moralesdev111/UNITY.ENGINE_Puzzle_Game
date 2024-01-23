using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMinigame : MonoBehaviour
{
    void OnTriggerStay(Collider collider)
    {
        ActiveItemSlot activeItemSlot = FindObjectOfType<ActiveItemSlot>();

        if (activeItemSlot != null)
        {            
            if (activeItemSlot.activeitem != null && activeItemSlot.activeitem.itemType == Item.ItemType.tool)
            {
                if (collider.gameObject.CompareTag("Player"))
                {
                    if (Input.GetKey(KeyCode.Z))
                    {
                         Debug.Log("Game Started");
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
