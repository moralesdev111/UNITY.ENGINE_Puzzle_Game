using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnTutorialCanvasAtStart : MonoBehaviour
{
    [SerializeField] Canvas tutorialCanvas;

    
    void Start()
    {
        tutorialCanvas.gameObject.SetActive(true);
    }
}
