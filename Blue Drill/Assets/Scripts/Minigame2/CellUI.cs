using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellUI : MonoBehaviour
{   
     [SerializeField] Cell cell;

    public void UpdateSprite(int child)
    {
        Transform box = cell.currentCell.transform.GetChild(child);
        box.GetComponent<Image>().enabled = false;
    }

    public void HighlightCell(GameObject cell, Color highlightColor)
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
}
