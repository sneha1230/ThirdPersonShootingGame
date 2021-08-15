using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    AggroDetection aggro;
    Animator anim;
    private NavMeshAgent navMeshAgent;
    Transform enemyTarget;
    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
        aggro = GetComponent<AggroDetection>();
        aggro.OnAggro += Aggro_OnAggro;
    }
    private void Aggro_OnAggro(Transform target)
    {
        this.enemyTarget = target;
    }
    private void Update()
    {
        if (enemyTarget != null)
        {
            navMeshAgent.SetDestination(enemyTarget.position);
            float enemyCurrentSpeed = navMeshAgent.velocity.magnitude;
            anim.SetFloat("Speed", enemyCurrentSpeed);
        }
    }
}
