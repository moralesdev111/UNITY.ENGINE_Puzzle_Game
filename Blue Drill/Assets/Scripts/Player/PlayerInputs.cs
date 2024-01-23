using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    [HideInInspector] public Vector3 direction;   
    private float horizontalInput;
    private float verticalInput;      


    void Update()
    {
        Inputting();        
    }

    public void Inputting()
    {
        horizontalInput =Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        direction = new Vector3(horizontalInput, 0f, verticalInput).normalized;
    }
}
