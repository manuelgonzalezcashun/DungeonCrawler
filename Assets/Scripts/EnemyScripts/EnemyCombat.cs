using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : CombatSystem
{
    [SerializeField] float attackCooldown;
    private float lastAttackTime = 0.0f;
    void Update()
    {
        if (Time.time - lastAttackTime > attackCooldown)
        {
            Attack(stats.attack);
            lastAttackTime = Time.time;
        }
    }
}
