using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Minigame : MonoBehaviour
{
    [Header("References")]
    
    [SerializeField] Oil oil;
    [SerializeField] Drill drill;

    [Header("Setting MiniGame")]
    public Transform topPivot;
    public Transform bottomPivot;
    public float failTimer = 12f;
    public bool gameInprogress = false;
    public bool cantStartFirstGame = true;
  
    [SerializeField] ProgressCheck progressCheck;


    void Update()
    {
        oil.Move();
        drill.Move();
        progressCheck.ProgressChecking();
    }
}
