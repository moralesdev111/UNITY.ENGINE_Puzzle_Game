using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] NavMeshAgent navMeshAgent;
    private GameObject target;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Equipment");
        
    }

    void Update(){
        navMeshAgent.destination = target.transform.position;
    }

}
