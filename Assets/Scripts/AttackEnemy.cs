using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemy : MonoBehaviour
{
    float radious = 5f;
    float shootRate = 1.5f;

    float distance;
    bool hasEnemyOnTarget = false;
    EnemyController enemyTarget;
    GameManager gameManager;
    GameObject shootRadiousCircle;
    private void Start()
    {
        shootRadiousCircle = gameObject.transform.GetChild(0).gameObject;
        shootRadiousCircle.transform.localScale = new Vector2(radious * 2, radious * 2);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void Update()
    {
        if (gameManager != null && gameManager.enemys != null)
            foreach (EnemyController enemy in gameManager.enemys)
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
        if (enemyTarget != null)
        {
            distance = Vector3.Distance(transform.position, enemyTarget.transform.position);
            if (enemyTarget.Health > 0 && distance < radious)
            {
                enemyTarget.Health--;
                Invoke(nameof(Attack), shootRate);
            }
            else
            {
                hasEnemyOnTarget = false;
            }
        }
        else
        {
            hasEnemyOnTarget = false;
        }
    }
    void AddToTarget(EnemyController enemy)
    {
        if (!hasEnemyOnTarget || enemyTarget.Health <= 0)
        {
            enemyTarget = enemy;
            Attack();
            hasEnemyOnTarget = true;
        }
    }
    private void OnMouseDown()
    {
        //gameManager.SetToTarget(gameObject);
    }
}
