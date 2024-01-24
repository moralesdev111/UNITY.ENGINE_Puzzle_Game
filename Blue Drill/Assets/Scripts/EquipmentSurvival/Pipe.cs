using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    
    public int maxHealth = 5;
    public int currentHealth;


    void Start()
    {
        currentHealth = maxHealth;
    }

    private int TakeDamage(int damageAmount)
    {
        return currentHealth -= damageAmount;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(1);
        }
    }
}
