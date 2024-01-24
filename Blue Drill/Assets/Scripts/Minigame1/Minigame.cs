using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Minigame : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Drill drill;
    [SerializeField] Oil oil;
    [SerializeField] Slider progressBarContainer;
    [SerializeField] OilBank oilBank;
    [SerializeField] MoneyBank moneyBank;
 

    [Header("Setting MiniGame")]
    public Transform topPivot;
    public Transform bottomPivot;
    [SerializeField] float failTimer = 12f;
    private float drillProgress;    
    private PlayerStates playerStates; 
    public bool gameInprogress = false;
    [SerializeField] Item drillItem;

    void Start()
    {
        playerStates = FindObjectOfType<PlayerStates>();
    }

    void Update()
    {
        oil.Move();
        drill.Move();
        ProgressCheck();
    }

    private void ProgressCheck()
    {
        progressBarContainer.value = drillProgress;

        float min = drill.drillPosition - 0.1f / 1.7f; // Adjusted minimum based on drill dimensions
        float max = drill.drillPosition + 0.1f / 1.3f; // Adjusted maximum based on drill dimensions

        if (min < oil.oilPosition && oil.oilPosition < max)
        {
            drillProgress += drill.drillPower * Time.deltaTime;
        }
        else
        {
            drillProgress -= drill.drillProgressDegradationPower * Time.deltaTime;
            failTimer -= Time.deltaTime;
            if(failTimer < 0f)
            {
                gameInprogress = false;
                this.gameObject.SetActive(false);
                playerStates.currentState = PlayerStates.States.idle;
                failTimer = 12f;
                drillProgress = 0;
                return;
            }
        }
        if(drillProgress >= 1f)
        {
            gameInprogress = false;
            this.gameObject.SetActive(false);
            playerStates.currentState = PlayerStates.States.idle;
            drillProgress = 0;
            moneyBank.AddToBank(drillItem.yield);
            oilBank.AddToBank(drillItem.yield);
            return;
        }
        drillProgress = Mathf.Clamp(drillProgress, 0f, 1f);
    }
    
    

    /*private void SuccessfullDrill()
    {
        Debug.Log("You win! Closing Soon.");
    }
    private void Lose()
    {
        Debug.Log("You lose!! Closing Soon.");
    }
    IEnumerator ExitMiniGameSuccessFul()
    {
        SuccessfullDrill();
        yield return new WaitForSeconds(3f);
        
        this.gameObject.SetActive(false);
    }
    IEnumerator ExitMiniGameFail()
    {
        Lose();
        yield return new WaitForSeconds(3);
        this.gameObject.SetActive(false);
    }*/
}
