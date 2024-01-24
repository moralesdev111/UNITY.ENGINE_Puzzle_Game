using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oil : MonoBehaviour, IMoveable
{
    [SerializeField] Minigame minigame;
    [Header("Oil Speed Controls")]
    [SerializeField] Transform oil;
    [SerializeField] float timerMultiplicator = 3f;
    [SerializeField] float smoothMotion = 1f;
    private float oilSpeed;
    public float oilPosition;
    private float oilDestination;
    private float oilTimer;

    
    public void Move()
    {
        oilTimer -= Time.deltaTime;
        if (oilTimer < 0f)
        {
            oilTimer = Random.value * timerMultiplicator;

            oilDestination = Random.value;
        }
        oilPosition = Mathf.SmoothDamp(oilPosition, oilDestination, ref oilSpeed, smoothMotion);
        oil.position = Vector3.Lerp(minigame.bottomPivot.position, minigame.topPivot.position, oilPosition);
    }
}
