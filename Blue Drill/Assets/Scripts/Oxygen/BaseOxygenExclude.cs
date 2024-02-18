using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BaseOxygenExclude : MonoBehaviour
{
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] Animator animator;
    public bool exclude = true;
    [SerializeField] GameObject postProcessing;

     private FogMode defaultFogMode;
    private Color defaultFogColor;
    private float defaultFogDensity;

     private void Start()
    {
        // Store the default fog settings when the script starts
        defaultFogMode = RenderSettings.fogMode;
        defaultFogColor = RenderSettings.fogColor;
        defaultFogDensity = RenderSettings.fogDensity;
    }
    
    private void OnTriggerStay(Collider collider)
    {
        if(collider.CompareTag("Player"))
        {
            exclude = true;
            playerMovement.waterMovement = false;
            animator.SetBool("waterMovement",false);
            postProcessing.SetActive(false); 

             RenderSettings.fog = false;
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.CompareTag("Player"))
        {
            AudioManager.Instance.StopMusic(1);
            AudioManager.Instance.PlayMusic("base",0);
        }
    }
    private void OnTriggerExit(Collider collider)
    {
        if(collider.CompareTag("Player"))
        {
            exclude = false;
            playerMovement.waterMovement = true;
            animator.SetBool("waterMovement",true);
            AudioManager.Instance.StopMusic(0);
            AudioManager.Instance.PlayMusic("underwater",1);

            postProcessing.SetActive(true);

             RenderSettings.fog = true;
            RenderSettings.fogMode = defaultFogMode;
            RenderSettings.fogColor = defaultFogColor;
            RenderSettings.fogDensity = defaultFogDensity;
        }
    }
    
}
