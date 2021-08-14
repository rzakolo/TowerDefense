using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionAttackType : BaseAttack
{
    [SerializeField] GameObject bulletPrefab;
    private void Start()
    {
        cost = 100;
        SetVisibleAttackRadious();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    private void Update()
    {
        foreach (EnemyController enemy in gameManager.enemys)
        {
            if (CorrectDistance(enemy))
            {
                AddToTarget(enemy);
            }
        }
    }
    protected override void Attack()
    {
        if (CorrectDistance(enemyTarget))
        {
            if (enemyTarget.Health <= 0 || enemyTarget == null)
            {
                ClearTarget();
                return;
            }
            Fire();
            Invoke(nameof(Attack), shootRate);
        }
        else
            Invoke(nameof(ClearTarget), shootRate);
    }
    void Fire()
    {
        if (enemyTarget != null)
        {
            transform.right = enemyTarget.transform.position - transform.position;
            Vector2 position = new Vector2(transform.position.x, transform.position.y);
            GameObject temp = Instantiate(bulletPrefab, position, transform.rotation);
            Vector2 direction = new Vector2(transform.position.x - enemyTarget.transform.position.x, transform.position.y - enemyTarget.transform.position.y);
            temp.GetComponent<Bullet>().SetDirection(direction);
            temp.GetComponent<Bullet>().SetParentGameObject(gameObject);
        }
    }
}
