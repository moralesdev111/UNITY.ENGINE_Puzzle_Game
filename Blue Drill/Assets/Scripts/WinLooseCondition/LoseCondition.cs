using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCondition : MonoBehaviour
{
    [SerializeField] SceneLoader sceneLoader;
    [SerializeField] OilPerHour oilPerHour;
    [SerializeField] Canvas loseConditionCanvas;
    [SerializeField] int loseCondition = 100;


    void Update()
    {
        if(oilPerHour.canStartOilRatePerHour)
        {
            if(oilPerHour.oilPerHour < loseCondition)
                {
                    loseConditionCanvas.gameObject.SetActive(true);
                    StartCoroutine(RestartGame());
                }
        }
     }

     IEnumerator RestartGame()
     {
        yield return new WaitForSeconds(3f);
        loseConditionCanvas.gameObject.SetActive(false);
        sceneLoader.ChangeScene(0);
     }
     
}
