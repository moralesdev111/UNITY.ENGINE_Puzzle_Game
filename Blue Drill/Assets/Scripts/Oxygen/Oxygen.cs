using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Oxygen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI oxygenValue;
    [SerializeField] BaseOxygenExclude baseOxygenExclude;
    [SerializeField] HandleDeath handleDeath;
    public float maxOxygen = 50;
    public float currentOxygen;


    void Start()
    {
        currentOxygen = maxOxygen;
        currentOxygen = Mathf.Clamp(currentOxygen, 0, 50);
    }

    void Update()
    {
        ManageOxygen();
        handleDeath.Die();
    }

    private void ManageOxygen()
    {
        if (!baseOxygenExclude.exclude)
        {
            if (currentOxygen > 0 && currentOxygen <= maxOxygen)
            {
                currentOxygen -= Time.deltaTime / 5;
                oxygenValue.text = "Oxygen " + currentOxygen.ToString("F1");
            }
        }
        else if (baseOxygenExclude.exclude)
        {
            if (currentOxygen < maxOxygen)
            {
                RefillOxygen();
            }
        }
    }

    private void RefillOxygen()
    {
        currentOxygen += Time.deltaTime / 10;
        currentOxygen = Mathf.Clamp(currentOxygen, 0, maxOxygen);
        oxygenValue.text = "Oxygen " + currentOxygen.ToString("F1");
    }

    
}
