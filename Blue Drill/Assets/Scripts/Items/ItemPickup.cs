using UnityEngine;

public class ItemPickup: MonoBehaviour
{
    public Item item;

    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(!Inventory.Instance.Add(item))
            {
                Debug.Log("Inventory FULL");
                return;
            }            
            Destroy(gameObject);
        }        
    }
}
