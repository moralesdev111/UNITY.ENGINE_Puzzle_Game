using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OilPerHour : MonoBehaviour
{
    [SerializeField] OilBank oilBank;
    [SerializeField] TextMeshProUGUI oilPerHourUIText;
    public bool canStartOilRatePerHour = false;


    public float minutes = 0;
    public float hours = 0;
    public float oilPerHour;
   
    void Update()
    {
        oilPerHourUIText.text = "Oil Rate/Hour: " + oilPerHour.ToString("F1");
        minutes += Time.deltaTime;
        hours = MinuteToHours();
        

        if(canStartOilRatePerHour)
        {
            oilPerHour = OilPerHourCalculations();
            if(oilPerHour >= 200)
            {
                oilPerHourUIText.color = Color.blue;
            }
            else if(oilPerHour >150 && oilPerHour <200)
            {
                oilPerHourUIText.color = Color.black;
            }
            else if (oilPerHour <=150)
            {
                oilPerHourUIText.color= Color.red;
            }
        }       
    }

    private float MinuteToHours()
    {
        return minutes / 60;
    }

    private float OilPerHourCalculations()
    {
        return oilBank.currentBalance / hours;
    }
}
