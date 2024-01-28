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
            }
        }
    }
}
