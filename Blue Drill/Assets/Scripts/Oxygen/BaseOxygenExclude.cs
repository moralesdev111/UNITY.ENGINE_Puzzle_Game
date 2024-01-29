using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseOxygenExclude : MonoBehaviour
{
    public bool exclude = false;

    
    private void OnTriggerStay(Collider collider)
    {
        if(collider.CompareTag("Player"))
        {
            exclude = true;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if(collider.CompareTag("Player"))
        {
            exclude = false;
        }
    }
    
}
