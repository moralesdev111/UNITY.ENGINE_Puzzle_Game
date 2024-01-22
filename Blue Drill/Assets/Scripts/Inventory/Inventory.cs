using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton

    public static Inventory Instance;
    private void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("More than one inventory found ERROR");
            return;
        }
        Instance = this;
    }

    #endregion
    public int space = 6;
    public List<Item> items = new List<Item>();
    public List<Item> activeItem = new List<Item>();
    public delegate void OnItemChanged();
    public OnItemChanged uiChangeTriggered;

    public bool AddItemToList(Item item, List<Item> list)
    {
        if (list.Count >= space)
        {
            Debug.Log("Inventory Full"); 
            return false;           
        }
        list.Add(item);

        if (uiChangeTriggered != null)
        {
            uiChangeTriggered.Invoke();
        }      
        return true;      
    }

    public void RemoveItemFromList(Item item, List<Item> list)
    {
        list.Remove(item);

        if (uiChangeTriggered != null)
        {
            uiChangeTriggered.Invoke();
        }            
    }
}