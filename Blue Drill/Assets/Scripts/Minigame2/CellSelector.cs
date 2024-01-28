using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellSelector : MonoBehaviour
{
    [SerializeField] GridManager gridManager;
   
    public GameObject currentCell; // Keep track of the current cell coordinates
    public GameObject[] bombCells;
    public GameObject rewardCell;
    public int lives = 2;

    private void OnEnable()
    {
        SetStartCell();
       
        SetBombCells();
        SetRewardCells();
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
            currentCell = gridManager.GetCellFromCoordinate(new Vector2Int(2,2));

                HighlightCell(currentCell, Color.red);
        }
         else
            {
                Debug.Log("Cell not found.");
            }
    }

   private void HighlightCell(GameObject cell, Color highlightColor)
{
    if (cell != null)
    {
        // Assuming the image is a child of the cell GameObject
        Image cellImage = cell.GetComponent<Image>();

        if (cellImage != null)
        {
            // Highlight the cell by changing its color
            cellImage.color = highlightColor;
        }
        else
        {
            Debug.LogError("Image component not found on the cell GameObject.");
        }
    }
    else
    {
        Debug.LogError("Highlighted cell GameObject is null.");
    }
}


   private void NavigateTheGrid()
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

    if (gridManager != null && currentCell != null)
    {
        // Get the current cell coordinates
        Vector2Int currentCellCoordinate = gridManager.GetCellCoordinateFromGameObject(currentCell);

        // Calculate the new cell coordinates
        Vector2Int newCellCoordinate = new Vector2Int(currentCellCoordinate.x + newRow, currentCellCoordinate.y + newColumn);

        // Check if the new cell coordinates are valid
        if (gridManager.IsWithinGridBounds(newCellCoordinate))
        {
            // Reset the previous cell color if it exists
            HighlightCell(currentCell, Color.gray);

            // Highlight the new cell with the desired color
            currentCell = gridManager.GetCellFromCoordinate(newCellCoordinate);
            HighlightCell(currentCell, Color.red);
        }
    }
}

    private void SearchGrid()
{
    if (Input.GetKeyDown(KeyCode.Space))
    {
        gridManager.modifiedCells.Add(currentCell);
        UpdateSprite(2);

        for (int i = 0; i < bombCells.Length; i++)
        {
            if (currentCell == bombCells[i])
            {                        
                lives--;
                if (lives < 1)
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


    private void EndGame()
    {
        gridManager.gameInprogress = false;
        gridManager.canvas.gameObject.SetActive(false);
    }

    private void SetBombCells()
    {
        bombCells = new GameObject[2];
        bombCells[0] = gridManager.GetCellFromCoordinate(new Vector2Int(4,4));
        Transform child = bombCells[0].transform.GetChild(0);
        child.gameObject.SetActive(true);
        bombCells[1] = gridManager.GetCellFromCoordinate(new Vector2Int(0,0));
        Transform child2 = bombCells[1].transform.GetChild(0);
        child2.gameObject.SetActive(true);
    }

    private void SetRewardCells()
    {
        rewardCell = gridManager.GetCellFromCoordinate(new Vector2Int(1,1));
        Transform child = rewardCell.transform.GetChild(1);
        child.gameObject.SetActive(true);
    }

    private void UpdateSprite(int child)
    {
        Transform box = currentCell.transform.GetChild(child);
        box.GetComponent<Image>().enabled = false;
    }
    IEnumerator EndGameProcess()
    {
        
        yield return new WaitForSeconds(1.5f);
        EndGame();
    }
}
