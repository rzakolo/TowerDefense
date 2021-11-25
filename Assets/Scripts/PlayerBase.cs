using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour, IHealth, IDamageable
{
    private int minHealth, maxHealth, currentHealth;
    public event Action<int> OnHealthChanged;

    float radious = 1;
    float distance;

    [SerializeField] GameManager gameManager;
    private void Init()
    {
        minHealth = 0;
        maxHealth = 100;
    }

    public void ApplyDamage(int damage)
    {
        if (currentHealth - damage < 0)
        {
            //todo: не дописано
        }
        OnHealthChanged?.Invoke(damage);
    }
}
