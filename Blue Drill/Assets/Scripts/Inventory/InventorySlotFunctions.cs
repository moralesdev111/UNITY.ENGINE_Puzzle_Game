using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotFunctions : MonoBehaviour
{
    public Image itemSprite;
    public TextMeshProUGUI itemName;
    public Item item;

    public Button removeButton; // Reference to the button

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
        removeButton.onClick.AddListener(RemoveItemFromInventory);
    }

    public void ClearItem()
    {
        item = null;
        itemSprite.sprite = null;
        itemName.text = string.Empty;
        removeButton.onClick.RemoveAllListeners(); // Remove any existing listeners
    }

    private void RemoveItemFromInventory()
    {
        if (item != null)
        {
            Inventory.Instance.Remove(item);
            ClearItem(); // Optionally clear the slot after removing the item
        }
    }
}
