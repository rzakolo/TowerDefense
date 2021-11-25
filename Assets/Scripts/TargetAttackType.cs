using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetAttackType : BaseAttack
{

    private void OnValidate()
    {
        cost = 500;
    }
    void Update()
    {
        fireRate -= Time.deltaTime;
        if (fireRate < 0)
        {
            CheckRadius();
            fireRate = _fireRate;
            Attack();
        }
    }

    protected override void Attack()
    {
        if (IsCorrectDistance(enemyTarget))
        {
            enemyTarget.Health -= attackDamage;
            BulletTracer();
            if (enemyTarget.Health <= 0 || enemyTarget == null)
            {
                ClearTarget();
                return;
            }
        }
        else
        {
            ClearTarget();
        }
    }
}
