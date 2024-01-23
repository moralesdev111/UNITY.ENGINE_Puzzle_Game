using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Minigame : MonoBehaviour
{
    [Header("Setting MiniGame")]
    [SerializeField] Transform topPivot;
    [SerializeField] Transform bottomPivot;
    [SerializeField] Transform oil;
    
    [Header("Oil Speed Controls")]
    [SerializeField] float timerMultiplicator = 3f;
    [SerializeField] float smoothMotion = 1f;
    private float oilSpeed;
    private float oilPosition;
    private float oilDestination;
    private float oilTimer;
    
    [Header("Drill Controls")]
    [SerializeField] Transform drill;
    private float drillPosition;
    [SerializeField] float drillPower = 0.5f;
    private float drillProgress;
    private float drillPullVelocity;
    [SerializeField] float drillPullPower = 0.01f;
    [SerializeField] float drillGravityPower = 0.005f;
    [SerializeField] float drillProgressDegradationPower = 0.1f;
    [SerializeField] Slider progressBarContainer;
    [SerializeField] float failTimer = 15f;


    void Update()
    {
        Oil();
        Drill();
        ProgressCheck();
    }

    private void ProgressCheck()
{
    progressBarContainer.value = drillProgress;

    float min = drillPosition - 0.1f / 1.7f; // Adjusted minimum based on drill dimensions
    float max = drillPosition + 0.1f / 1.3f; // Adjusted maximum based on drill dimensions

    if (min < oilPosition && oilPosition < max)
    {
        drillProgress += drillPower * Time.deltaTime;
    }
    else
    {
        drillProgress -= drillProgressDegradationPower * Time.deltaTime;
        failTimer -= Time.deltaTime;
        if(failTimer < 0f)
        {
            Lose();
        }
    }
    if(drillProgress >= 1f){
        SuccessfullDrill();
    }

    drillProgress = Mathf.Clamp(drillProgress, 0f, 1f);
}
    private void Drill()
    {

        if(Input.GetMouseButton(0))
        {
            drillPullVelocity += drillPullPower * Time.deltaTime;
        }
        drillPullVelocity -= drillGravityPower * Time.deltaTime;

        drillPosition += drillPullVelocity;

        if(drillPosition - 0.1f / 1.7f<= 0f && drillPullVelocity <0f)
        {
            drillPullVelocity = 0f;
        }
        if(drillPosition + 0.1f / 1.7f>= 1f && drillPullVelocity >0f)
        {
            drillPullVelocity = 0f;
        }
        drillPosition = Mathf.Clamp(drillPosition, 0.1f / 1.7f, 1 - 0.1f / 1.3f);
        drill.position = Vector3.Lerp(bottomPivot.position,topPivot.position,drillPosition);
    }
    private void Oil()
    {
        oilTimer -= Time.deltaTime;
        if (oilTimer < 0f)
        {
            oilTimer = Random.value * timerMultiplicator;

            oilDestination = Random.value;
        }
        oilPosition = Mathf.SmoothDamp(oilPosition, oilDestination, ref oilSpeed, smoothMotion);
        oil.position = Vector3.Lerp(bottomPivot.position, topPivot.position, oilPosition);
    }

    private void SuccessfullDrill()
    {
        Debug.Log("You win!");
    }
    private void Lose()
    {
        Debug.Log("You lose");
    }
}
