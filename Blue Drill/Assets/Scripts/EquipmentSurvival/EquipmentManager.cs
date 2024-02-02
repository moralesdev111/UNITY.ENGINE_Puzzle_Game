using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    public bool canDrill = true;
    private Equipment[] childEquipment;

    void Start()
    {
        GetChildEquipment();
    }

    void Update()
    {
        CheckArrayHealth();
    }

    private void CheckArrayHealth()
    {
        canDrill = true;
        for (int i = 0; i < childEquipment.Length; i++)
        {
            if (childEquipment[i].currentHealth == 0)
            {
                canDrill = false;
                break;
            }
        }
    }

    private Equipment[] GetChildEquipment()
    {
        childEquipment = new Equipment[4];
        for(int i = 0; i < 4;i++)
        {
            childEquipment[i] = transform.GetChild(i).GetComponent<Equipment>();
        }
        return childEquipment;
    }
}
