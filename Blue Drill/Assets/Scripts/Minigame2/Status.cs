using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    [SerializeField] GridManager gridManager;
    [SerializeField] GridManagerMethods gridManagerMethods;
    [SerializeField] Status status;


    public int lives = 2;
    public bool gameInprogress = false;
    public bool canStart = true;


    public void StartGame()
    {
        canStart = false;
        gridManagerMethods.ResetCells();
        gridManager.modifiedCells.Clear();
        status.gameInprogress = true;
        gridManager.canvas.gameObject.SetActive(true);
    }
    public void EndGame()
    {
        canStart = true;
        gameInprogress = false;
        gridManager.canvas.gameObject.SetActive(false);
    }

    
    
}