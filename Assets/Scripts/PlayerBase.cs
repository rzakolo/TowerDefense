using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    public int Health = 100;
    float radious = 1;
    float distance;

    GameManager gameManager;
    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        InvokeRepeating(nameof(CheckEnemys), 1, 1);
    }
    void CheckEnemys()
    {
        foreach (var enemy in gameManager.enemys)
        {
            if (enemy != null)
            {
                distance = Vector3.Distance(transform.position, enemy.transform.position);
                if (distance < radious)
                    enemy.MakeDamage();
            }
        }

    }
}
