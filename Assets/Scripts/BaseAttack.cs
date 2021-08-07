using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public abstract class BaseAttack : MonoBehaviour
{
    protected float radious = 5f;
    protected float shootRate = 1.5f;
    protected int attackDamage = 1;
    protected float distance;
    protected bool hasEnemyOnTarget = false;
    protected EnemyController enemyTarget;

    protected GameManager gameManager;
    protected GameObject shootRadiousCircle;
    protected void AddToTarget(EnemyController enemy)
    {
        if (enemyTarget == null)
            ClearTarget();
        if (!hasEnemyOnTarget)
        {
            enemyTarget = enemy;
            hasEnemyOnTarget = true;
            Attack();
        }
    }
    protected abstract void Attack();
    protected void ClearTarget()
    {
        hasEnemyOnTarget = false;
        enemyTarget = null;
        CancelInvoke();
    }
}

