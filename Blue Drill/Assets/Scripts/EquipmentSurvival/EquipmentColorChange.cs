using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentColorChange : MonoBehaviour
{
    [SerializeField]Equipment equipment;
    [SerializeField] Color fullHealthColor;
    [SerializeField] Color lowHealthColor;
    private Renderer meshRenderer;


    void Start()
    {
         meshRenderer = GetComponent<Renderer>();
    }

    public void UpdateColor()
    {
        float healthPercentage = (float)equipment.currentHealth / equipment.maxHealth;
        Color lerpedColor = Color.Lerp(lowHealthColor,fullHealthColor, healthPercentage);
        meshRenderer.material.color = lerpedColor;
    }
}
