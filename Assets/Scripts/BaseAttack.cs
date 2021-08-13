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
    public int attackDamage = 1;

    protected float distance;
    protected bool hasEnemyOnTarget = false;
    protected EnemyController enemyTarget;

    protected GameManager gameManager;
    protected GameObject shootRadiousCircle;
    protected void AddToTarget(EnemyController enemy)
    {
        if (enemyTarget == null)
            Invoke(nameof(ClearTarget), shootRate);
        if (!hasEnemyOnTarget)
        {
            enemyTarget = enemy;
            hasEnemyOnTarget = true;
            Attack();
        }
    }
    protected bool CorrectDistance(EnemyController enemy)
    {
        if (enemy != null)
            distance = Vector3.Distance(transform.position, enemy.transform.position);
        if (distance < radious)
        {
            return true;
        }
        return false;
    }
    /// <summary>
    /// Устанавливает размер дочернего объекта строения
    /// </summary>
    protected void SetVisibleAttackRadious()
    {
        shootRadiousCircle = gameObject.transform.GetChild(0).gameObject;
        shootRadiousCircle.transform.localScale = new Vector2(radious * 2, radious * 2);
    }
    protected abstract void Attack();
    protected void ClearTarget()
    {
        hasEnemyOnTarget = false;
        enemyTarget = null;
        CancelInvoke();
    }
    protected virtual void BulletTracer()
    {
        LineRenderer tracer = GetComponent<LineRenderer>();
        tracer.startWidth = 0.05f;
        tracer.endWidth = 0.05f;
        tracer.positionCount = 2;
        tracer.SetPosition(1, transform.position);
        tracer.SetPosition(0, enemyTarget.transform.position);
    }
}

