using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMinigame : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameObject startDrillingCanvas;
    [SerializeField] Minigame minigame;
    [SerializeField] GridManager gridManager;
    [SerializeField] EquipmentManager equipmentManager;
    [SerializeField] Canvas goFixPipesCanvas;

    void OnTriggerStay(Collider collider)
    {
        ActiveItemSlot activeItemSlot = FindObjectOfType<ActiveItemSlot>();
        PlayerStates playerStates = collider.GetComponent<PlayerStates>();
    
    if(minigame.cantStartFirstGame)
        {if(gridManager.countDown <= gridManager.barrier)
        {
             if (activeItemSlot != null)
        {
            if (activeItemSlot.activeitem != null && activeItemSlot.activeitem.itemType == Item.ItemType.tool)
            {
                if (collider.gameObject.CompareTag("Player") && !minigame.gameInprogress)
                {
                    startDrillingCanvas.SetActive(true);
                    if (Input.GetKey(KeyCode.Z))
                    {
                        if(equipmentManager.canDrill)
                        {
                            AudioManager.Instance.PlaySFX("drill",1);
                        minigame.cantStartFirstGame = false;
                        minigame.gameInprogress = true;
                        startDrillingCanvas.SetActive(false);
                        Debug.Log("Game Started"); // trigger minigame player state
                        playerStates.currentState = PlayerStates.States.minigame;
                        }
                        else
                        {
                            goFixPipesCanvas.gameObject.SetActive(true);
                            StartCoroutine(TurnOffGoFixPipesCanvas());
                        }
                        
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
}
    
    void OnTriggerExit(Collider collider)
    {
        startDrillingCanvas.SetActive(false);
    }

    IEnumerator TurnOffGoFixPipesCanvas()
    {
        yield return new WaitForSeconds(2f);
        goFixPipesCanvas.gameObject.SetActive(false);
    }
}
