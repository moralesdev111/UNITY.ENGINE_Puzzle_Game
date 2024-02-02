using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    [SerializeField] OilBank oilBank;
      [SerializeField] MoneyBank moneyBank;
      [SerializeField] Item drillItem;
    [SerializeField] GridManager gridManager;
    [SerializeField] CellNavigation cellNavigation;
    [SerializeField] CellUI cellUI;
    [SerializeField] Status status;
    [SerializeField] GridManagerMethods gridManagerMethods;
    [SerializeField] OilPerHour oilPerHour;
   
    public GameObject currentCell; // Keep track of the current cell coordinates
    public GameObject[] bombCells;
    public GameObject[] takenCells = new GameObject[3];
    public GameObject rewardCell;


    private void Update()
    {
        cellNavigation.NavigateTheGrid();
        SearchGrid();
        if(gridManager.startTimeCD)
        {
           
            
            gridManager.countDown -= Time.deltaTime;
                if(gridManager.countDown <= gridManager.barrier)
                {
                    
                    gridManager.startTimeCD = false;
                    
            }
           
        }
    }


    private void SearchGrid()
{
    if (Input.GetKeyDown(KeyCode.Space))
    {
        gridManager.modifiedCells.Add(currentCell);
        cellUI.UpdateSprite(2);

        for (int i = 0; i < bombCells.Length; i++)
        {
            if (currentCell == bombCells[i])
            {                        
                status.lives--;
                if (status.lives < 1)
                {
                    gridManager.countDown = 5f;
                    gridManager.startTimeCD = true;
                    Debug.Log("Dead");
                    StartCoroutine(EndGameProcess());
                    
                }
                break;
            }
            else if (currentCell == rewardCell)
            {
                oilPerHour.canStartOilRatePerHour = true;
                 moneyBank.AddToBank(drillItem.yield);
        oilBank.AddToBank(drillItem.yield);
                StartCoroutine(EndGameProcess());
                break;
            }
        }
    }
}

IEnumerator EndGameProcess()
    {
        yield return new WaitForSeconds(1.5f);
        status.EndGame();
    }
    

     public Vector2Int RandomizeCell()
    {
        int randomColumn, randomRow;
        Vector2Int randomPlacement;

        do
        {
            randomColumn = Random.Range(0, 5);
            randomRow = Random.Range(0, 5);

            randomPlacement = new Vector2Int(randomColumn, randomRow);
        } while (IsCellTaken(randomPlacement));

        return randomPlacement;
    }

    public bool IsCellTaken(Vector2Int cell)
    {
        // Check if the cell is in the takenCells array
        for (int i = 0; i < takenCells.Length; i++)
        {
            if (takenCells[i] != null)
            {
                Vector2Int takenCellPosition = gridManagerMethods.GetCellCoordinateFromGameObject(takenCells[i]);

                if (cell == takenCellPosition)
                {
                    // The cell is taken, return true
                    return true;
                }
            }
        }

        // The cell is not taken, return false
        return false;
    }
}
