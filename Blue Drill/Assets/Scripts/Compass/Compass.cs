using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compass : MonoBehaviour
{
    [SerializeField] Transform cameraTransform;
    private Vector3 direction;
    void Start()
    {
        
    }

    void Update()
    {
        direction.z = cameraTransform.eulerAngles.y;
        transform.localEulerAngles = direction;
    }
}
