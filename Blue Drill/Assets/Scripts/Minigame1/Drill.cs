using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drill : MonoBehaviour, IMoveable
{
    [SerializeField] Minigame minigame;

    [Header("Drill Controls")]
    public Transform drill;
    public float drillPosition;
    public float drillPower = 0.5f;
    public float drillProgressDegradationPower = 0.1f;
    [SerializeField] float drillPullPower = 0.01f;
    [SerializeField] float drillGravityPower = 0.005f;
    private float drillPullVelocity;
  
    
    public void Move()
    {

        if(Input.GetMouseButton(0))
        {
            drillPullVelocity += drillPullPower * Time.deltaTime;
        }
        drillPullVelocity -= drillGravityPower * Time.deltaTime;

        drillPosition += drillPullVelocity;

        if(drillPosition - 0.1f / 1.7f<= 0f && drillPullVelocity <0f)
        {
            drillPullVelocity = 0f;
        }
        if(drillPosition + 0.1f / 1.7f>= 1f && drillPullVelocity >0f)
        {
            drillPullVelocity = 0f;
        }
        drillPosition = Mathf.Clamp(drillPosition, 0.1f / 1.7f, 1 - 0.1f / 1.3f);
        drill.position = Vector3.Lerp(minigame.bottomPivot.position,minigame.topPivot.position,drillPosition);
    }
}
