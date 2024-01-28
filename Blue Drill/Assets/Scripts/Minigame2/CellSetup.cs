using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellSetup : MonoBehaviour
{
    [SerializeField] Cell cell;
    [SerializeField] GridManager gridManager;
    [SerializeField] GridManagerMethods gridManagerMethods;
    [SerializeField] CellUI cellUI;

    private void Start()
    {
        SetStartCell();       
        SetBombCells();
        SetRewardCells();
    }

    private void SetStartCell()
    {
        if (gridManager != null)
        {
            cell.currentCell = gridManagerMethods.GetCellFromCoordinate(new Vector2Int(2,2));

                cellUI.HighlightCell(cell.currentCell, Color.red);
        }
         else
            {
                Debug.Log("Cell not found.");
            }
    }

     private void SetBombCells()
    {
        cell.bombCells = new GameObject[2];
        cell.bombCells[0] = gridManagerMethods.GetCellFromCoordinate(new Vector2Int(4,4));
        Transform child = cell.bombCells[0].transform.GetChild(0);
        child.gameObject.SetActive(true);
        cell.bombCells[1] = gridManagerMethods.GetCellFromCoordinate(new Vector2Int(0,0));
        Transform child2 = cell.bombCells[1].transform.GetChild(0);
        child2.gameObject.SetActive(true);
    }

    private void SetRewardCells()
    {
        cell.rewardCell = gridManagerMethods.GetCellFromCoordinate(new Vector2Int(1,1));
        Transform child = cell.rewardCell.transform.GetChild(1);
        child.gameObject.SetActive(true);
    }
}
