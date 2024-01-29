using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] NavMeshAgent navMeshAgent;
    private Equipment[] targets;
    private Equipment target;


    void OnEnable()
    {
        targets = FindObjectsOfType<Equipment>();
        if(targets.Length > 0)
        {
            navMeshAgent.destination = AssignTarget().transform.position;
        }   
    }

     private Equipment AssignTarget()
    {
        int randomIndex = GetRandomTarget();
        return target = targets[randomIndex];
    }

    private int GetRandomTarget()
    {
        return Random.Range(0,targets.Length);
    }
}
