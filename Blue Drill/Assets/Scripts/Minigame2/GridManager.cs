using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

public class GridManager : MonoBehaviour
{
    public int rows = 5;
    public int columns = 5;
    public GameObject gridPrefab;
    public Canvas canvas;
    public GameObject[,] grid;
    public List<GameObject> modifiedCells = new List<GameObject>();
    public bool gameInprogress = false;
    [SerializeField] CellSelector cellSelector;


    private void Awake()
    {
        CreateGrid();
    }

     void CreateGrid()
    {
        grid = new GameObject[rows, columns];

        for (int row = 0; row < rows; row++)
        {
            for (int column = 0; column < columns; column++)
            {
                GameObject newCell = Instantiate(gridPrefab, Vector3.zero, Quaternion.identity);
                newCell.name = row.ToString() + "_" + column.ToString();

                // Set the cell's parent to the canvas
                newCell.transform.SetParent(canvas.transform, false);

                // Set the cell's position using RectTransform
                RectTransform rectTransform = newCell.GetComponent<RectTransform>();
                rectTransform.anchoredPosition = new Vector2(column * rectTransform.sizeDelta.x, -row * rectTransform.sizeDelta.y);

                // Store the reference to the cell in the grid array
                grid[row, column] = newCell;
            }
        }
    }

    public Vector2Int GetCellCoordinateFromGameObject(GameObject cellObject)
    {
        for (int row = 0; row < rows; row++)
        {
            for (int column = 0; column < columns; column++)
            {
                if (grid[row, column] == cellObject)
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
        return cellCoordinate.x >= 0 && cellCoordinate.x < rows && cellCoordinate.y >= 0 && cellCoordinate.y < columns;
    }

    public GameObject GetCellFromCoordinate(Vector2Int cellPosition)
    {
        if (IsWithinGridBounds(cellPosition))
        {
            return grid[cellPosition.x, cellPosition.y];
        }
        else
        {
            Debug.Log("Out of bounds");
            return null;
        }
    }

   public void ResetCells()
{
    cellSelector.lives = 2;
    foreach (GameObject cell in modifiedCells)
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
        else if(cell == cellSelector.bombCells[0] || cell == cellSelector.bombCells[0])
        {   
            Transform child0 = cell.transform.GetChild(0);
            child0.gameObject.SetActive(true);
        }        
    }
    Debug.Log("Reset complete.");
}
}
