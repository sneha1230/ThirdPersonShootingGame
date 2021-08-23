using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    AggroDetection aggroDetection;
    private Health healthTarget;
    [SerializeField]
    private float attackTimer;
    [SerializeField]
    private float attackRefreshRate=1.0f;
    private void Awake()
    {
        aggroDetection = GetComponent<AggroDetection>();
        aggroDetection.OnAggro += AggroDetection_OnAggro;
    }
    private void AggroDetection_OnAggro(Transform target)
    {
        Health health = target.GetComponent<Health>();
        if (health != null)
        {
            healthTarget = health;
        }
    }
    private void Update()
    {
        if (healthTarget != null)
        {
            attackTimer += Time.deltaTime;
            if (CanAttack())
            {
                Attack();
            }
        }
    }
    private void Attack()
    {
        attackTimer = 0;
        healthTarget.TakeDamage(1);
    }
    private bool CanAttack()
    {
        return attackTimer >= attackRefreshRate;
    }
}
