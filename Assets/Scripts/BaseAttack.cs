using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public abstract class BaseAttack : MonoBehaviour
{
    protected float radius = 5f;
    protected float fireRate = 1.5f;
    protected float _fireRate;
    public int attackDamage = 1;
    public int cost;
    public float updateTargetRate;
    protected float distance;
    [SerializeField] protected EnemyController enemyTarget;
    protected GameObject shootRadiousCircle;

    protected bool IsCorrectDistance(EnemyController enemy)
    {
        if (enemy != null)
            distance = Vector2.Distance(transform.position, enemy.transform.position);
        //Debug.Log(distance);
        if (distance < radius + 0.4f)
        {
            return true;
        }
        return false;
    }
    protected void CheckRadius()
    {
        var hit = Physics2D.CircleCast(transform.position, radius, Vector2.zero, LayerMask.NameToLayer("CollisionArea"));
        if (hit.collider != null)
            enemyTarget = hit.collider.gameObject.GetComponent<EnemyController>();
    }

    /// <summary>
    /// Устанавливает размер дочернего объекта строения
    /// </summary>
    protected void SetVisibleAttackRadious()
    {
        shootRadiousCircle = gameObject.transform.GetChild(0).gameObject;
        shootRadiousCircle.transform.localScale = new Vector2(radius * 2, radius * 2);
    }
    protected abstract void Attack();
    protected void ClearTarget()
    {
        enemyTarget = null;
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
    private void OnEnable()
    {
        SetVisibleAttackRadious();
        updateTargetRate = 1;
        _fireRate = fireRate;
        //InvokeRepeating(nameof(CheckRadius), updateTargetRate, updateTargetRate);
    }
}

