using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CombatSystem : MonoBehaviour
{
    [Header("Attacking")]
    [SerializeField] protected Transform attackPoint;
    [SerializeField] protected LayerMask attackMask;
    [SerializeField] protected float attackRange = 0.2f;
    public void Attack(float attackDamge)
    {
        Collider2D[] hitObjects = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, attackMask);
        foreach (Collider2D obj in hitObjects)
        {
            if (obj.TryGetComponent(out HealthSystem healthSystem))
            {
                healthSystem.TakeDamage(attackDamge);
            }
        }
    }
}
