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
            ClearItem(); // Optionally clear the slot after removing the item
        }
    }
}