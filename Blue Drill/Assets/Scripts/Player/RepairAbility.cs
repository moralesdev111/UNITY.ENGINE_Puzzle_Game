using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairAbility : MonoBehaviour, IRemoveButtonFunctionality
{
    [SerializeField] ActiveItemSlot activeItemSlot;
    [SerializeField] PlayerInputs playerInputs;
    public Equipment equipment;

    
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Equipment"))
        {
            equipment = collider.gameObject.GetComponent<Equipment>();            
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.CompareTag("Equipment"))
        {
            equipment = null;       
        }
    }

    public void CheckIfCanRepair()
    {
        if (activeItemSlot.activeitem != null)
        {
            if (activeItemSlot.activeitem.itemType == Item.ItemType.resource)
            {
                if (Input.GetKeyDown(playerInputs.repairKey))
                {
                    if (equipment != null)
                    {
                        if(equipment.currentHealth != 5)
                        {
                            equipment.RepairEquipment(activeItemSlot.activeitem.yield); 
                            RemoveButtonFunctionality(); 
                        }
                                   
                    }
                }
            }
        }
    }

    public void RemoveButtonFunctionality()
    {
    activeItemSlot.activeItemSprite.sprite = null;    
    Inventory.Instance.activeItem.Clear();
    Inventory.Instance.uiChangeTriggered?.Invoke();
    }
}
