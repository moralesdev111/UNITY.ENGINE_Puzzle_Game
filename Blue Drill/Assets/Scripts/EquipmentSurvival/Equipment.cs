using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    
    public int maxHealth = 5;
    public int currentHealth;
    [SerializeField] EquipmentColorChange equipmentColorChange;
 
    

    void Start()
    {
        currentHealth = maxHealth;
        maxHealth = Mathf.Clamp(maxHealth,0,5);
    }

    private void Update()
    {
        equipmentColorChange.UpdateColor();
    }

    private int TakeDamage(int damageAmount)
    {
        return currentHealth -= damageAmount;
    }

    public int RepairEquipment(int healthRepairAmount)
    {
        if(currentHealth < maxHealth)
        {
            currentHealth += healthRepairAmount;
        }            
       return currentHealth;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(1);
        }
    }
   
}
