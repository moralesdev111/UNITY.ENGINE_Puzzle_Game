using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotFunctions : MonoBehaviour
{
    public Image itemSprite;
    public TextMeshProUGUI itemName;
    public Item item;

    public Button removeButton; // Reference to the button
    public Button activeButton;

    private void Start(){
        activeButton.onClick.AddListener(ActiveButtonFunctionaility);
    }
    public void UpdateSlotUIOnNewItem(Item newItem)
    {
        ClearItem();
        item = newItem;
        itemSprite.sprite = item.itemSprite;
        itemName.text = item.name;

        // Add an onClick listener to the button to call RemoveItemFromInventory
        SetupRemoveButtonListener();
    }

    private void SetupRemoveButtonListener()
    {
        removeButton.onClick.RemoveAllListeners();
        removeButton.onClick.AddListener(() => RemoveItemFromInventory(item, Inventory.Instance.items));
    }

    public void ClearItem()
    {
        item = null;
        itemSprite.sprite = null;
        itemName.text = string.Empty;
        removeButton.onClick.RemoveAllListeners(); // Remove any existing listeners
    }

    private void RemoveItemFromInventory(Item item, List<Item> list)
{
    if (item != null)
    {
        Inventory.Instance.RemoveItemFromList(item, list);
        ClearItem();
        Inventory.Instance.uiChangeTriggered?.Invoke();
        // Optionally, delay the UI update to the next frame
      
    }
}

    private void ActiveButtonFunctionaility()
{
    Debug.Log("Active button pressed");
    if (Inventory.Instance.activeItem.Count == 0)
    {
        Inventory.Instance.items.Remove(item);
        Inventory.Instance.activeItem.Add(item);
        Inventory.Instance.uiChangeTriggered?.Invoke();

        // Update the active item slot
        return;
    }
    else
    {
        Debug.Log("Inventory Full bro");
    }

}
}




