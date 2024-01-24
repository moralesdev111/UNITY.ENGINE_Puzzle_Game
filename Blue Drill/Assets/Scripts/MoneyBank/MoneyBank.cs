using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoneyBank : Bank
{
    [Header("References")]
    [SerializeField] TextMeshProUGUI moneyText;
    [SerializeField] TextMeshProUGUI laptopMoneyText;
    [SerializeField] TextMeshProUGUI pendingTransactionsText;
    [SerializeField] Image moneyBankCanvas;
    [SerializeField] OilBank oilBank;
    

    public int pendingBalance = 0;

    private void Awake()
    {    
        moneyBankCanvas.gameObject.SetActive(true);
    }

    private void Start()
    {
        currentBalance = 0;
    }

    private void Update()
    {
        moneyText.text = "Coin: " + currentBalance.ToString();
        pendingTransactionsText.text = " One Pending Transaction of Net Value: " + pendingBalance.ToString();
        laptopMoneyText.text = currentBalance.ToString();
    }

    public override int AddToBank(int amount)
    {
        return pendingBalance += amount;
    }

    public void ResetPendingBalanceAndAddToNormalBalance()
    {
        currentBalance += pendingBalance;
        pendingBalance = 0;
        oilBank.currentBalance = 0;
    }

}
