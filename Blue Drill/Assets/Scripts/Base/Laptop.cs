using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class Laptop : MonoBehaviour
{
    [SerializeField] GameObject laptopCanvas;
    void OnTriggerStay(Collider collider)
    {
        if(collider.CompareTag("Player"))
        {
            if(Input.GetKey(KeyCode.P))
            laptopCanvas.SetActive(true);
        }
    }

    public void ExitLaptopUI()
    {
        laptopCanvas.SetActive(false);
    }
}
