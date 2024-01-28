using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressCheck : MonoBehaviour
{
    [SerializeField] Slider progressBarContainer;
    [SerializeField] Drill drill;
    public float drillProgress;    
    [SerializeField] Minigame minigame;
    [SerializeField] Oil oil;
    [SerializeField] Status1 status1;


    public void ProgressChecking()
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
            minigame.failTimer -= Time.deltaTime;
            if(minigame.failTimer < 0f)
            {
                status1.Fail();
                return;
            }
        }
        if(drillProgress >= 1f)
        {
            status1.Succeed();
            return;
        }
        drillProgress = Mathf.Clamp(drillProgress, 0f, 1f);
    }
}
