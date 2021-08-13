using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetAttackType : BaseAttack
{
    private void Start()
    {
        SetVisibleAttackRadious();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void Update()
    {
        if (gameManager != null && gameManager.enemys != null)
            foreach (EnemyController enemy in gameManager.enemys)
            {
                if (enemy != null)
                {
                    if (CorrectDistance(enemyTarget))
                    {
                        AddToTarget(enemy);
                    }
                }
            }
    }
    protected override void Attack()
    {
        if (enemyTarget != null)
        {
            if (enemyTarget.Health > 0 && CorrectDistance(enemyTarget))
            {
                enemyTarget.Health -= attackDamage;
                BulletTracer();
                if (enemyTarget.Health <= 0 || enemyTarget == null)
                {
                    ClearTarget();
                    return;
                }
                Invoke(nameof(Attack), shootRate);
            }
            else
            {
                ClearTarget();
            }
        }
    }
}
