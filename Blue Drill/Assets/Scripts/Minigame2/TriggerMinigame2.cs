using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMinigame2 : MonoBehaviour
{

     [Header("References")]
    
    [SerializeField] GridManager gridManager;


    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
             gridManager.ResetCells();
            gridManager.modifiedCells.Clear();
            gridManager.gameInprogress = true;
             gridManager.canvas.gameObject.SetActive(true);
        }
    }

}
