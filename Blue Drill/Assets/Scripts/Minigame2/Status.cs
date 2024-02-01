using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    [SerializeField] GridManager gridManager;
    [SerializeField] GridManagerMethods gridManagerMethods;
    [SerializeField] Status status;
    [SerializeField] PlayerStates playerStates;
    [SerializeField] Minigame minigame;
    [SerializeField] CellSetup cellSetup;
    [SerializeField] Cell cell;

    public int lives = 2;
    public bool gameInprogress = false;
    public bool canStart = true;


    public void StartGame()
    {
        canStart = false;
        gridManagerMethods.VisuallyResetCells();
        gridManager.modifiedCells.Clear();
        Array.Clear(cell.takenCells,0, cell.takenCells.Length);
        cellSetup.SetBombCells();
        cellSetup.SetRewardCell();
        status.gameInprogress = true;
        gridManager.canvas.gameObject.SetActive(true);
    }
    public void EndGame()
    {
        
        AudioManager.Instance.PlaySFX("drill");
        minigame.cantStartFirstGame = true;
        gameInprogress = false;
        gridManager.canvas.gameObject.SetActive(false);
        playerStates.currentState = PlayerStates.States.idle;
    }
}