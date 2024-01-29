using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairAbility : MonoBehaviour, IRemoveButtonFunctionable
{
    [SerializeField] ActiveItemSlot activeItemSlot;
    [SerializeField] PlayerInputs playerInputs;
    [SerializeField] Canvas repairCanvas;
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
                if (equipment != null)
                {
                    repairCanvas.gameObject.SetActive(true);
                    if (Input.GetKeyDown(playerInputs.repairKey))
                    {
                        repairCanvas.gameObject.SetActive(false);
                        if(equipment.currentHealth != 5)
                        {
                            equipment.RepairEquipment(activeItemSlot.activeitem.yield); 
                            RemoveButtonFunctionality(); 
                        }
                                   
                    }
                }
                else if(equipment == null)
                {
                    repairCanvas.gameObject.SetActive(false);
                }
            }
        }
    }
    

    public void RemoveButtonFunctionality()
    {
    activeItemSlot.activeItemSprite.sprite = null;    
    Inventory.Instance.activeItem.Clear();
    activeItemSlot.activeitem = null;
    Inventory.Instance.uiChangeTriggered?.Invoke();
    }
}
