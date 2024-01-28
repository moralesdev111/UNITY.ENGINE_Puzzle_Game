using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status1 : MonoBehaviour
{
    [SerializeField] Status status;
    [SerializeField] PlayerStates playerStates;
    [SerializeField] ProgressCheck progressCheck;
    [SerializeField] Minigame minigame;
     

    private void Start()
    {
        playerStates = FindObjectOfType<PlayerStates>();
    }

    public void Succeed()
    {
        minigame.gameInprogress = false;
        this.gameObject.SetActive(false);
        progressCheck.drillProgress = 0;
        this.gameObject.SetActive(false);
        playerStates.currentState = PlayerStates.States.minigame2;
        status.canStart = true;
        status.StartGame();
    }

    public void Fail()
    {
        minigame.cantStartFirstGame = true;
        minigame.gameInprogress = false;
        this.gameObject.SetActive(false);
        playerStates.currentState = PlayerStates.States.idle;
        minigame.failTimer = 12f;
        progressCheck.drillProgress = 0;
        this.gameObject.SetActive(false);
    }
}
