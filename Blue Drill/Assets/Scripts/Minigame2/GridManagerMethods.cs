using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridManagerMethods : MonoBehaviour
{
    [SerializeField] Cell cellSelector;
    [SerializeField] GridManager gridManager;
    [SerializeField] Status status;
    [SerializeField] Cell cell;


    public Vector2Int GetCellCoordinateFromGameObject(GameObject cellObject)
    {
        for (int row = 0; row < gridManager.rows; row++)
        {
            for (int column = 0; column < gridManager.columns; column++)
            {
                if (gridManager.grid[row, column] == cellObject)
                {
                    return new Vector2Int(row, column);
                }
            }
        }
        Debug.LogError("Cell not found.");
        return new Vector2Int(-1, -1);
    }

    public bool IsWithinGridBounds(Vector2Int cellCoordinate)
    {
        return cellCoordinate.x >= 0 && cellCoordinate.x < gridManager.rows && cellCoordinate.y >= 0 && cellCoordinate.y < gridManager.columns;
    }

    public GameObject GetCellFromCoordinate(Vector2Int cellPosition)
    {
        if (IsWithinGridBounds(cellPosition))
        {
            return gridManager.grid[cellPosition.x, cellPosition.y];
        }
        else
        {
            Debug.Log("Out of bounds");
            return null;
        }
    }

   public void VisuallyResetCells()
{
   
    status.lives = 2;
    foreach (GameObject cell in gridManager.modifiedCells)
    {
        Transform child2 = cell.transform.GetChild(2);
        Image childImage = child2.GetComponent<Image>();
        if (child2 != null)
        {
            childImage.enabled = true;
            child2.gameObject.SetActive(true);
            Debug.Log("Activated third child in cell: " + cell.name);
        }
        else
        {
            Debug.LogError("Third child not found in cell: " + cell.name);
        }


        if(cell == cellSelector.rewardCell)
        {
             Transform child1 = cell.transform.GetChild(1);
             child1.gameObject.SetActive(true);

        }
        else if(cell == cellSelector.bombCells[0] || cell == cellSelector.bombCells[1])
        {   
            Transform child0 = cell.transform.GetChild(0);
            child0.gameObject.SetActive(true);
        }        
    }

    foreach (GameObject takenCell in cell.takenCells)
        {
            if (takenCell != null)
            {
                // Reset visual state for each cell
                ResetVisualState(takenCell);
            }
        }
    Debug.Log("Reset complete.");
}

private void ResetVisualState(GameObject cellObject)
    {
       
        if (cellObject == cellSelector.rewardCell)
        {
            Transform child1 = cellObject.transform.GetChild(1);
            child1.gameObject.SetActive(false);
        }
        else if (cellObject == cellSelector.bombCells[0] || cellObject == cellSelector.bombCells[1])
        {
            Transform child0 = cellObject.transform.GetChild(0);
            child0.gameObject.SetActive(false);
        }
    }
}
