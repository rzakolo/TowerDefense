using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionAttackType : BaseAttack
{
    [SerializeField] Bullet bulletPrefab;

    private void OnValidate()
    {
        cost = 100;
        attackDamage = 5;
    }

    private void Update()
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
            if (enemyTarget == null || enemyTarget.Health <= 0)
            {
                ClearTarget();
                return;
            }
            Fire();
        }
    }
    void Fire()
    {
        if (enemyTarget != null)
        {
            transform.right = enemyTarget.transform.position - transform.position;
            Vector2 position = transform.position;
            Bullet temp = Instantiate(bulletPrefab, position, transform.rotation);
            Vector2 direction = transform.position - enemyTarget.transform.position;
            temp.SetDirection(direction);
            temp.SetDamage(attackDamage);
        }
    }
}
