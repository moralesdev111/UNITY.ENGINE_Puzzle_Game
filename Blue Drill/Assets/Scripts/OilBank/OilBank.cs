using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OilBank : Bank
{
    [Header("References")]
    [SerializeField] TextMeshProUGUI oilText;
    

    void Start()
    {
        currentBalance = 0;
    }

    void Update()
    {
        oilText.text = "Oil: " + currentBalance.ToString();
    }

    public override int AddToBank(int amount)
    {
        return currentBalance+= amount;
    }

    
}
