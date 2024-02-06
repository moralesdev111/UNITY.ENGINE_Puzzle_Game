using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    [SerializeField] SceneLoader sceneLoader;
    [SerializeField] MoneyBank moneyBank;
    [SerializeField] int winCondition = 500;
    

    void Update()
    {
        if(moneyBank.currentBalance >= winCondition){
            Debug.Log("You win");
        }
    }
}
