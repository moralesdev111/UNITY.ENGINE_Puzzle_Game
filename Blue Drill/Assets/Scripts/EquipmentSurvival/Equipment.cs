using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Equipment : MonoBehaviour
{
    
    public int maxHealth = 5;
    public int currentHealth;
    [SerializeField] EquipmentColorChange equipmentColorChange;
    [SerializeField] GameObject parentPosition;
    [SerializeField] EnemyWave enemyWave;

 
    

    void Start()
    {
        currentHealth = maxHealth;
        
    }

    private void Update()
    {
        currentHealth = Mathf.Clamp(currentHealth,0,5);
        equipmentColorChange.UpdateColor();
        if(currentHealth < 1)
        {
            enemyWave.canSpawn = false;
        }
        else{
            enemyWave.canSpawn = true;
        }
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
            collision.gameObject.SetActive(false);
            if(currentHealth > 1)
            {
                AudioManager.Instance.PlaySFX("oilCrash");
            }
            else{
                AudioManager.Instance.PlaySFX("crash"); 
            }
            

            collision.gameObject.transform.position = parentPosition.transform.position;
            TakeDamage(1);
            
        }
    }
   
}
