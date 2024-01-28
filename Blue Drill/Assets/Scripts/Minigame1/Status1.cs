using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status1 : MonoBehaviour
{
      [SerializeField] Item drillItem;
      [SerializeField] ProgressCheck progressCheck;
      [SerializeField] Minigame minigame;
      [SerializeField] OilBank oilBank;
      [SerializeField] MoneyBank moneyBank;
      private PlayerStates playerStates;

    private void Start()
    {
        playerStates = FindObjectOfType<PlayerStates>();
    }


    public void Succeed()
    {
        minigame.gameInprogress = false;
        this.gameObject.SetActive(false);
        playerStates.currentState = PlayerStates.States.idle;
        progressCheck.drillProgress = 0;
        moneyBank.AddToBank(drillItem.yield);
        oilBank.AddToBank(drillItem.yield);
        this.gameObject.SetActive(false);
    }

    public void Fail()
    {
        minigame.gameInprogress = false;
        this.gameObject.SetActive(false);
        playerStates.currentState = PlayerStates.States.idle;
        minigame.failTimer = 12f;
        progressCheck.drillProgress = 0;
        this.gameObject.SetActive(false);
    }
}
