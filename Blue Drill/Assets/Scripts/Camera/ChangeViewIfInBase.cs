using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ChangeViewIfInBase : MonoBehaviour
{
    [SerializeField] BaseOxygenExclude baseOxygenExclude;
    private CinemachineFreeLook cinemachineVirtualCamera;

    void Start()
    {
        cinemachineVirtualCamera = GetComponent<CinemachineFreeLook>();
    }

    void LateUpdate()
    {
        // Check if you need to change the rig angling
        if (baseOxygenExclude.exclude)
        {
            
            ChangeRigAngling();
        }
    }

    private void ChangeRigAngling()
{
    // Check if the CinemachineFreeLook is assigned
    if (cinemachineVirtualCamera != null)
    {
        // Access the individual rigs
        CinemachineFreeLook.Orbit topRigOrbit = cinemachineVirtualCamera.m_Orbits[0];
        CinemachineFreeLook.Orbit middleRigOrbit = cinemachineVirtualCamera.m_Orbits[1];
        CinemachineFreeLook.Orbit bottomRigOrbit = cinemachineVirtualCamera.m_Orbits[2];

        // Set the new values using public properties
        cinemachineVirtualCamera.GetComponent<CinemachineFreeLook.Orbit>();
        topRigOrbit.m_Radius = 6f;

        middleRigOrbit.m_Height = 6f;
        middleRigOrbit.m_Radius = 6f;

        bottomRigOrbit.m_Height = 6f;
        bottomRigOrbit.m_Radius = 6f;

        Debug.Log("Adios");
    }
}

}
