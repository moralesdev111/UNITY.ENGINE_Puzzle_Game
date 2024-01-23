using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMinigame : MonoBehaviour
{
    [SerializeField] GameObject startDrillingCanvas;
    [SerializeField] Minigame minigame;

    void OnTriggerStay(Collider collider)
    {
        ActiveItemSlot activeItemSlot = FindObjectOfType<ActiveItemSlot>();
        PlayerStates playerStates = collider.GetComponent<PlayerStates>();

        if (activeItemSlot != null)
        {
            if (activeItemSlot.activeitem != null && activeItemSlot.activeitem.itemType == Item.ItemType.tool)
            {
                if (collider.gameObject.CompareTag("Player") && !minigame.gameInprogress)
                {
                    startDrillingCanvas.SetActive(true);
                    if (Input.GetKey(KeyCode.Z))
                    {
                        minigame.gameInprogress = true;
                        startDrillingCanvas.SetActive(false);
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
    
    void OnTriggerExit(Collider collider)
    {
        startDrillingCanvas.SetActive(false);
    }
}
