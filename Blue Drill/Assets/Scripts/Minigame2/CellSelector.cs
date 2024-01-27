using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CellSelector : MonoBehaviour
{
    [SerializeField] GridManager gridManager;
    public Image cellImage = null;
    public Dictionary<Vector2Int, Image> cellCoordinateImageDictionary = new Dictionary<Vector2Int, Image>();
    private Vector2Int currentCell; // Keep track of the current cell coordinates
    private Vector2Int[] bombCells;
    public Sprite bombSprite;

    private void Start()
    {
        SetStartCell();
        SetBombCells();
    }

    private void Update()
    {
        NavigateTheGrid();
        SearchGrid();
    }

    private void SetStartCell()
    {
        if (gridManager != null)
        {
            currentCell = gridManager.GetCellAtPosition(2, 2);

            if (cellCoordinateImageDictionary.TryGetValue(currentCell, out Image selectedCellImage))
            {
                HighlightCell(selectedCellImage);
            }
            else
            {
                Debug.Log("Cell not found.");
            }
        }
    }

    private void HighlightCell(Image cellImage)
    {
        cellImage.color = Color.red;
    }

    private void NavigateTheGrid()
    {
        // Check for arrow key input
        int newRow = currentCell.x;
        int newColumn = currentCell.y;

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            newRow--;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            newRow++;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            newColumn--;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            newColumn++;
        }

        if(gridManager!= null)
        {
             Vector2Int newCell = gridManager.GetCellAtPosition(newRow, newColumn);

        // Check if the new cell coordinates are valid
        if (cellCoordinateImageDictionary.TryGetValue(newCell, out Image selectedCellImage))
        {
            // Reset the previous cell color
            cellCoordinateImageDictionary[currentCell].color = Color.white;

            // Highlight the new cell
            HighlightCell(selectedCellImage);

            // Update the current cell coordinates
            currentCell = newCell;
        }
        }
    }
    
    private void SearchGrid()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(cellCoordinateImageDictionary.TryGetValue(currentCell, out Image selectedCellImage))
            {
                selectedCellImage.enabled = false;

                if(CheckForBombCell(currentCell)) // check if coincides with any of the array values
                    {
                        Debug.Log("You lose");
                    }
            }           
        }
    }

    private void SetBombCells()
    {
        bombCells = new Vector2Int[2];
        bombCells[0] = new Vector2Int(4,4);
        bombCells[1] = new Vector2Int(0,0);        
    }

    private bool CheckForBombCell(Vector2Int target)
    {
        for(int i = 0; i < bombCells.Length; i++)
        {
            if(target == bombCells[i])
            {
                 if(cellCoordinateImageDictionary.TryGetValue(target, out Image targetImage))
                 {
                    targetImage.sprite = bombSprite;
                     return true;
                 }
                 
            }
        }
        return false;
    }
}
