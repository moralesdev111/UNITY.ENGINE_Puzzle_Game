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
   
    public GameObject currentCell; // Keep track of the current cell coordinates
    public GameObject[] bombCells;
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
    
}
