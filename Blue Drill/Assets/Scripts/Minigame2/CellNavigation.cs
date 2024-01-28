using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellNavigation : MonoBehaviour
{
    [SerializeField] Cell cell;
    [SerializeField] GridManager gridManager;
    [SerializeField] GridManagerMethods gridManagerMethods;
    [SerializeField] CellUI cellUI;


    public void NavigateTheGrid()
{
    // Check for arrow key input
    int newRow = 0;
    int newColumn = 0;

    if (Input.GetKeyDown(KeyCode.UpArrow))
    {
        newRow = -1;
    }
    else if (Input.GetKeyDown(KeyCode.DownArrow))
    {
        newRow = 1;
    }
    else if (Input.GetKeyDown(KeyCode.LeftArrow))
    {
        newColumn = -1;
    }
    else if (Input.GetKeyDown(KeyCode.RightArrow))
    {
        newColumn = 1;
    }

    if (gridManager != null && cell.currentCell != null)
    {
        // Get the current cell coordinates
        Vector2Int currentCellCoordinate = gridManagerMethods.GetCellCoordinateFromGameObject(cell.currentCell);

        // Calculate the new cell coordinates
        Vector2Int newCellCoordinate = new Vector2Int(currentCellCoordinate.x + newRow, currentCellCoordinate.y + newColumn);

        // Check if the new cell coordinates are valid
        if (gridManagerMethods.IsWithinGridBounds(newCellCoordinate))
        {
            // Reset the previous cell color if it exists
            cellUI.HighlightCell(cell.currentCell, Color.gray);

            // Highlight the new cell with the desired color
            cell.currentCell = gridManagerMethods.GetCellFromCoordinate(newCellCoordinate);
            cellUI.HighlightCell(cell.currentCell, Color.red);
        }
    }
}
}
