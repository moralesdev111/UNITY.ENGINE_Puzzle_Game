
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

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public bool Add(Item item)
    {
        if (items.Count >= space)
        {
            Debug.Log("Inventory Full"); 
            return false;           
        }
        items.Add(item);

        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }      
        return true;      
    }

    public void Remove(Item item)
    {
        items.Remove(item);
        
        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }
}
