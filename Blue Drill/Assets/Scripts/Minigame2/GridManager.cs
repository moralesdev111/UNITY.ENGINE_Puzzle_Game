using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] CellSelector cellSelector;
    public int rows = 5;
    public int columns = 5;
    public GameObject gridPrefab;
    public Canvas canvas;    
    public GameObject[,] grid;
    private Vector2Int cellCoordinate = new Vector2Int();
    
 
    private void Awake()
    {
        CreateGrid();
    }

    private void CreateGrid()
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

                Image cellImage = newCell.GetComponent<Image>();
                cellSelector.cellCoordinateImageDictionary.Add(new Vector2Int(row,column),cellImage);
            }
        }
    }

    public Vector2Int GetCellAtPosition(int row, int column)
    {
        // Check if the specified position is within the grid boundaries
        if (row >= 0 && row < rows && column >= 0 && column < columns)
        {
            // Access the cell at the specified position
            cellCoordinate.x = row;
            cellCoordinate.y = column;
            return cellCoordinate;
        }
        else
        {
            Debug.Log("Out of bounds");
            return new Vector2Int(-1, -1);
        }
    }
}
