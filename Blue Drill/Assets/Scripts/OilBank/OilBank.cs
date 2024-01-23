using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OilBank : MonoBehaviour
{
    public int currentOil;
    public int basereward = 15;
    
    [Header("References")]
    [SerializeField] TextMeshProUGUI oilText;
    


    void Start()
    {
        currentOil = 0;
    }

    void Update()
    {
        oilText.text = "Oil: " + currentOil.ToString();
    }

    public int AddOil(int amount)
    {
        return currentOil+= amount;
    }

    public int ResetOil()
    {
        return currentOil = 0;
    }
}
