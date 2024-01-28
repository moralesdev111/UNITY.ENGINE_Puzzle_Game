using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
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
                    Debug.Log("Dead");
                    StartCoroutine(EndGameProcess());
                }
                break;
            }
            else if (currentCell == rewardCell)
            {
                Debug.Log("You win");
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
