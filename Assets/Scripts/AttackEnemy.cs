using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemy : MonoBehaviour
{
    float radious = 5f;
    float distance;
    float shootTimer = 1.5f;
    bool enemyOnTarget = false;
    [SerializeField] EnemyController[] enemys;
    EnemyController enemyTarget;
    void Update()
    {
        foreach (EnemyController enemy in enemys)
        {
            if (enemy != null)
            {
                distance = Vector3.Distance(transform.position, enemy.transform.position);
                if (distance < radious)
                {
                    AddToTarget(enemy);
                }
            }
        }
    }
    void Attack()
    {
        distance = Vector3.Distance(transform.position, enemyTarget.transform.position);
        if (enemyTarget.Health > 0)
        {
            enemyTarget.Health--;
        }
        if (enemyTarget.Health > 0 && distance < radious)
            Invoke("Attack", shootTimer);
        else
        {
            enemyOnTarget = false;
        }
    }
    void AddToTarget(EnemyController enemy)
    {
        if (!enemyOnTarget || enemyTarget.Health <= 0)
        {
            enemyTarget = enemy;
            Attack();
            enemyOnTarget = true;
        }
    }
}
