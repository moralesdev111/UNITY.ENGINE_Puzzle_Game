using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    Inventory inventory;
    public Transform itemsParent;
    public GameObject slotPrefab;

    private InventorySlotFunctions[] slots; // Array to store references to instantiated slots

    void Start()
    {
        inventory = Inventory.Instance;
        inventory.uiChangeTriggered += UpdateUI;
        InitializeInventorySlots(); // Call a separate method to initialize slots.
    }

    void InitializeInventorySlots()
    {
        // Instantiate new slots for each potential inventory slot
        slots = new InventorySlotFunctions[inventory.space];
        for (int i = 0; i < inventory.space; i++)
        {
            GameObject slotObject = Instantiate(slotPrefab, itemsParent);
            slots[i] = slotObject.GetComponent<InventorySlotFunctions>();
        }
    }

    void UpdateUI()
    {
        // Update the UI with items if they exist in the inventory
        for (int i = 0; i < inventory.items.Count && i < slots.Length; i++)
        {
            slots[i].UpdateSlotUIOnNewItem(inventory.items[i]);
        }
    }
}