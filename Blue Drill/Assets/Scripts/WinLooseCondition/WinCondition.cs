using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    [SerializeField] SceneLoader sceneLoader;
    [SerializeField] MoneyBank moneyBank;
    [SerializeField] Canvas winCanvas;
    [SerializeField] int winCondition = 500;
    

    void Update()
    {
        if(moneyBank.currentBalance >= winCondition)
        {
            winCanvas.gameObject.SetActive(true);
            StartCoroutine(BackToMainMenu());
        }
    }

    IEnumerator BackToMainMenu()
     {
        yield return new WaitForSeconds(3f);
        winCanvas.gameObject.SetActive(false);
        sceneLoader.ChangeScene(0);
     }
}
