using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMinigame2 : MonoBehaviour
{

     [Header("References")]
     
    [SerializeField] PlayerStates playerStates;
    [SerializeField] GridManager gridManager;

    void OnTriggerEnter(Collider collider){
        if(collider.gameObject.CompareTag("Player")){
            gridManager.ResetCells();
            gridManager.modifiedCells.Clear();
            gridManager.gameInprogress = true;
             gridManager.canvas.gameObject.SetActive(true);

        }
    }
    void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            if(Input.GetKey(KeyCode.X))
            {
                 playerStates.currentState = PlayerStates.States.minigame2;
            }
           
             
        }
    }

}
